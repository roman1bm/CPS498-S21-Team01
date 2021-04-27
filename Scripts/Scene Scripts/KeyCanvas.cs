using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCanvas : MonoBehaviour
{
    [SerializeField]
    public GameObject target;
    private bool state = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (state)
                target.SetActive(true);
            else
                target.SetActive(false);
            state = !state;
        }
      
    }
}
