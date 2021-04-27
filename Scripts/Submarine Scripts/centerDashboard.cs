using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class centerDashboard : MonoBehaviour
{
    public TextMeshProUGUI depthText;
    public GameObject attitude;


    public void setDepthText(float depth)
    {
        depthText.text = "Depth\n" + depth.ToString("f0");
    }
    public void setAttitude(float rot)
    {
        attitude.transform.localRotation = Quaternion.Euler(0f, 0f, rot);
    }


}
