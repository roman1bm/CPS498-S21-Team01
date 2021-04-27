using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script copies the real-life joystick movements to the joysticks inside the sub
public class JoystickMover : MonoBehaviour
{
    //cockpit joysticks to move
    public Transform leftThrust;
    public Transform leftStick;
    public Transform rightThrust;
    public Transform rightStick;

    private float angleAdjust = -25f;

    //left thruster + stick
    private float lt;
    private float lsx;
    private float lsy;
    //right thruster + stick
    private float rt;
    private float rsx;
    private float rsy = 0f;

    //inputs come in as range (-1 to 1)
    public void getMovements(float lt, float lsy, float lsx, float rt, float rsx)
    {
        this.lt = lt * angleAdjust;
        this.lsy = lsy * angleAdjust;
        this.lsx = lsx * angleAdjust;
        this.rt = rt * angleAdjust;
        this.rsx = rsx * angleAdjust;
    }

    // Update is called once per frame
    void Update()
    {
        leftThrust.localRotation = Quaternion.Euler(0f, lt, 0f);
        leftStick.localRotation = Quaternion.Euler(0f, lsy, lsx);

        rightThrust.localRotation = Quaternion.Euler(0f, rt, 0f);
        rightStick.localRotation = Quaternion.Euler(0f, rsy, rsx);
    }

    private Vector3 getVec(float x, float y, float z)
    {
        Vector3 v = new Vector3(x, y, z);
        return v;
    }
}
