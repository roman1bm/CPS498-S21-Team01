//|---------------------------------------------------------------------------|
//|    FILE NAME: SimToolsSend.cs                                             |
//|                                                                           |
//|    AUTHOR   : Alexander Redei                                             |
//|                                                                           |
//|    PURPOSE  : Sends telemetry and game status data to SimTools via UDP    |
//|                                                                           |
//|               Most important is the Pitch and Roll telemetry as those are |
//|                 what's primarily used by the flight simualtor. The        |
//|                 additional telemetry such as Surge may be used in the     |
//|					future to create a more complete motion profile.		  |
//|                                                                           |
//|               This asset :                                                |
//|                 1) Forwards Pitch, Roll, and Yaw telemetry                |
//|                 2) Intercept packets from Game                            |
//|                 3) Replace and inject packets from Game with packets from |
//|                     simtools and forward to the motion console            |
//|                                                                           |
//|    NOTES    : The UDP datagram is not very robust. Needs rewriting.       |
//|                                                                           |
//|    REVISIONS:                                                             |
//|			   11/30/19 - Claudio C. - Original code http://bit.ly/2YZMORI    |
//|            5/11/20 - Alex R. - 6+ new telemetry params & comments added	  |
//|			   5/11/20 - Alex R. - Added serialized Player GameObject         |
//|            9/1/20 - Alex R. - Added EulerValues from UnityEditor          |
//|---------------------------------------------------------------------------|

using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine.TextCore.LowLevel;
using System.IO;
using UnityEditor;


//|---------------------------------------------------------------------------|
//|    CLASS    : SimToolsSend                                                |
//|                                                                           |
//|    PURPOSE  : See comment above                                           |
//|                                                                           |
//|    NOTES    : I think we should pass the Player GameObject to collect     |
//|					telemetry and dashboard information more gracefully.	  |
//|                                                                           |
//|---------------------------------------------------------------------------|
public class SimToolsSend : MonoBehaviour
{
    #region Public Members
    // The IP to send to
    public string IP = "127.0.0.1";

    // Port to send to
    public int port = 4123;

	//The GameObject to monitor
	public GameObject player;

	[SerializeField]
	string stat1 = "";

    // the end point to send to
    IPEndPoint remoteEndPoint;

    // udp client
    static UdpClient client;

    // the simtools data
    static SimtoolsTelemetry simtools;


	// Previous frame rotation
	[System.NonSerialized]
	public static Quaternion OldRotation = Quaternion.identity;
	[System.NonSerialized]
	public static float RollAngle;

	Quaternion lastRot;
	Vector3 lastPos;
	Vector3 lastVel;

	float lastRoll;
	float lastPitch;
	float lastYaw;
    #endregion

    #region Start
    // initialization
    void Start()
    {
        // create an endpoint
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);

        // create a udp client
        client = new UdpClient();

        // create a simtools object
        simtools = new SimtoolsTelemetry();

		//Initialize rotation
		OldRotation = transform.rotation;

		// start the simtools coroutine
		StartCoroutine("SimtoolStart");
    }
    #endregion

    //Need to figure out Quaternion -> Euler conversion
    //these functions are in here for legacy support
    // ********************************************* UNIT TEST RESULTS *********************************************
    //CheckPitch360_OriginState_PitchOnly                       [PASSED]
    //CheckPitch90Roll360_OriginState_AllYaw                    [PASSED] 
    //CheckPitchRollYawWithNoMovement_OriginState_NoMovement    [PASSED] 
    //CheckRoll360_OriginState_RollOnly                         [PASSED] 
    //CheckRoll90Pitch360_OriginState_AllYaw                    [FAILED] - After the first 90-degree roll & pitch, reports (0,90,90) when it should be (90,90,0)
    //CheckRoll90Yaw360_OriginState_AllPitch                    [FAILED] - After the first 90 Roll & Yaw, reports (270,90,0) when it should be (90,90,0)
    //CheckYaw360_OriginState_RollOnly                          [PASSED] 
    //link:https://answers.unity.com/questions/1589025/how-to-get-inspector-rotation-values.html
    #region Get Telemetry Data
    public static float GetPitch(Transform player)
	{
		float pitch = player.rotation.eulerAngles.x;
		if (pitch > 180f)
		{
			pitch -= 360f;
		}
		return pitch;
		//return UnityEditor.TransformUtils.GetInspectorRotation(player).x;
	}

    public static float GetYaw(Transform player)
	{
		return player.rotation.eulerAngles.y;
		//return UnityEditor.TransformUtils.GetInspectorRotation(player).y;
	}

	public static float GetRoll(Transform player)
	{
		float roll = player.rotation.eulerAngles.z;
		if (roll > 180f)
        {
			roll -= 360f;
        }
		return roll;
		//return UnityEditor.TransformUtils.GetInspectorRotation(player).z;
	}
	#endregion

	//these functins actually retrieve the telemetry data
	#region Retreve Telemetry Data
	public void FixedUpdate()
	{
		//don't do anything if the gameobject is null because that will throw exceptions
		if (player != null)
		{

            //start OLD CODE
			Quaternion deltaRot = Quaternion.Inverse(lastRot) * player.transform.localRotation;

			float roll = lastRoll + deltaRot.eulerAngles.z;
			if (roll > 180)
				roll = roll - 360;

			float realPitch = deltaRot.eulerAngles.x;
			if (realPitch > 180)
				realPitch = realPitch - 360;

			float pitch = lastPitch + realPitch * Mathf.Cos(Mathf.Deg2Rad * roll);// (deltaRot.eulerAngles.x * player.transform.up.y);
			float yaw = lastYaw + deltaRot.eulerAngles.y;

			// ---------------------------------- OVER-RIDE PITCH, ROLL, and YAW VALUES ---------------------------------------------------
			// To Do: clean up old code above
			//end OLD CODE

			pitch = GetPitch(player.transform);
            yaw = GetYaw(player.transform);
			roll = GetRoll(player.transform);

			//attempt to calculate the delta quaternion for angular velocity...
			Vector3 deltaPos = player.transform.position - lastPos;
			Vector3 deltaV = deltaPos - lastVel;

			float heave = transform.InverseTransformDirection(deltaV).y;
			float sway = transform.InverseTransformDirection(deltaV).z;
			float surge = transform.InverseTransformDirection(deltaV).x;

			float deltaPitch = (float)Math.Round(deltaRot.eulerAngles.x, 2);
			float deltaRoll = (float)Math.Round(deltaRot.eulerAngles.z, 2);
			float deltaYaw = (float)Math.Round(deltaRot.eulerAngles.y, 2);


			lastRot = player.transform.rotation;
			lastPos = player.transform.position;
			lastVel = deltaPos;

			simtools = new SimtoolsTelemetry(pitch, roll, yaw, heave, sway, surge, deltaPitch, deltaRoll, deltaYaw);
		}
		return;
	}
	#endregion

	#region Send Telemetry Data
	public static void SimToolSendData(Transform player)
	{
		var roll = GetRoll(player);
		var pitch = GetPitch(player);
		var yaw = GetYaw(player);

		//Debug.Log("Roll " + roll);
		//Debug.Log("Pitch " + pitch);

		simtools = new SimtoolsTelemetry(pitch, roll, yaw);
	}

	// this function handles sending data
	public static void SimToolSendData(float roll, float pitch, float yaw)
    {
		simtools = new SimtoolsTelemetry(pitch, roll, yaw);
    }

	/// <summary>
	/// Sends the telemetry data in a UDP packet to the SimTools GamePlugin. The GamePlugin is called "Paragalactic_GamePlugin.dll" and is located in teh %APPDATA%/local/SimTools folder.
	/// </summary>
	/// <returns>Null</returns>
	/// <remarks>This UDP packet is not very robust. The order of the parameters must be matched. This needs to be re-written.</remarks>
    IEnumerator SimtoolStart()
    {
        while (true)
        {
            string info = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", simtools.Pitch, simtools.Roll, simtools.Yaw, simtools.Heave, simtools.Sway, simtools.Surge, simtools.Extra1, simtools.Extra2, simtools.Extra3);
            byte[] data = Encoding.Default.GetBytes(info);
            client.Send(data, data.Length, remoteEndPoint);
            yield return null;
        }
    }
	#endregion
}

//|---------------------------------------------------------------------------|
//|    CLASS    : SimToolsTelemetry                                           |
//|                                                                           |
//|    PURPOSE  : Encapsulate SimTools telemetry Data                         |
//|                                                                           |
//|    NOTES    : Why is this a class and not a struct?                       |
//|                                                                           |
//|---------------------------------------------------------------------------|
class SimtoolsTelemetry
{
	#region Public Members
	// pitch and roll data
	public float Pitch;
	public float Roll;
	public float Yaw;
	public float Heave;
	public float Sway;
	public float Surge;
	public float Extra1; //pitch velocity
	public float Extra2; //roll velocity
	public float Extra3; //yaw velocity
	#endregion

	#region Constructors
	// basic no-parameter consturctor
	public SimtoolsTelemetry()
	{
		this.Pitch = 0;
		this.Roll = 0;
		this.Yaw = 0;
		this.Heave = 0;
		this.Surge = 0;
		this.Sway = 0;
		this.Extra1 = 0;
		this.Extra2 = 0;
		this.Extra3 = 0;
	}

	//|---------------------------------------------------------------------------|
	//|    FUNCTION : Constructor                                                 |
	//|                                                                           |
	//|    NOTES    : Limited functionality.  Here for backwards compabitility	  |
	//|---------------------------------------------------------------------------|
	/// <summary>
	/// Here for backwards compatibility. Please use new fully-defined constructor.
	/// </summary>
	/// <param name="Pitch"></param>
	/// <param name="Roll"></param>
	/// <param name="Yaw"></param>
	public SimtoolsTelemetry(float Pitch, float Roll, float Yaw)
	{
		this.Roll = Roll;
		this.Pitch = Pitch;
		this.Yaw = Yaw;
		this.Heave = 0.0f;
		this.Sway = 0.0f;
		this.Surge = 0.0f;
		this.Extra1 = 0.0f;
		this.Extra2 = 0.0f;
		this.Extra3 = 0.0f;
	}

	//|---------------------------------------------------------------------------|
	//|    FUNCTION : Constructor                                                 |
	//|                                                                           |
	//|    NOTES    : Please use this constructor								  |
	//|---------------------------------------------------------------------------|
	/// <summary>
	/// Fully-Defined Constructor
	/// </summary>
	/// <param name="Pitch">The pitch of the space craft (in degrees)</param>
	/// <param name="Roll">The roll of the space craft (in degrees)</param>
	/// <param name="Yaw">The yaw of the space craft (in degrees)</param>
	/// <param name="Heave">The heave (up/down) of the space craft (expressed in g-forces)</param>
	/// <param name="Surge">The surve (forward/backward) of the space craft (expressed in g-forces)</param>
	/// <param name="Sway">The sway (left/right) of the space craft (expressed in g-forces)</param>
	/// <param name="Extra1">The pitch velocity of the space craft (expressed as angular g-forces)</param>
	/// <param name="Extra2">The roll velocity of the space craft (expressed as angular g-forces)</param>
	/// <param name="Extra3">The yaw velocity of the space craft (expressed as angular g-forces)</param>
	public SimtoolsTelemetry(float Pitch, float Roll, float Yaw, float Heave, float Surge, float Sway, float Extra1, float Extra2, float Extra3)
	{
		this.Pitch = Pitch;
		this.Roll = Roll;
		this.Yaw = Yaw;
		this.Heave = Heave;
		this.Sway = Sway;
		this.Surge = Surge;
		this.Extra1 = Extra1;
		this.Extra2 = Extra2;
		this.Extra3 = Extra3;
	}

	#endregion
}
