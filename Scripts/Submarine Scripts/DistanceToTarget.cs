using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject submarine;
    [SerializeField] GameObject target;
    public TextMeshProUGUI distanceText;
    private string end = "m";
    public bool toggle = false;

    int distance;

    private void Start()
    {
        submarine = GameObject.FindGameObjectWithTag("PlayerSub");
    }

    void FixedUpdate()
    {
        if (target)
        {
            distance = (int)Vector3.Distance(submarine.transform.position, target.transform.position);
            distance = distance / 4; //ROUGH conversion to real-world meters based on sub size
            distanceText.text = distance.ToString() + end;
        }
        else distanceText.text = "Unknown";

        //this is just for testing purposes.
        //you can click the checkbox for this bool in the inspector to lose target
        if (toggle)
        {
            toggle = false;
            loseTarget();
        }
    }

    public void updateTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public void loseTarget()
    {
        target = null;
    }
}
