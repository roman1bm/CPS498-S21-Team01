/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: BalanceSub.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 20, 2021
    
    DESCRIPTION: Balance the submarine flat and center once the submarine
                 reaches a checkpoint. The movement script for the submarine
                 will also be disabled until the next scene loads.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceSub : MonoBehaviour
{

    public string TrackerID;
    public GameObject Sub;
    public float AnimationDuration;

    /*
     *  FUNCTION NAME: OnTriggerEnter
     *  RECEIVES: Collider game object
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: On collision, start to balance the submarine.
     *               Before animation, disable the Submarine movement script.
     *               During animation, balance the submarine flat.
     */
    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == TrackerID)
        {
            StartCoroutine(DisableMove());      // Call function to disable movement script.

            StartCoroutine(BalanceFlat(Sub.transform, Quaternion.identity, AnimationDuration));        // Call function to balance the submarine, send the sub's transform values,
                                                                                        // Quaterniun rotation values, and the duration of the animation.
        }
        yield return new WaitForSeconds(0.5f);
    }

    /*
     *  FUNCTION NAME: DisableMove
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: Disables the submarine movement script.
     */
    IEnumerator DisableMove()
    {
        Debug.Log("Disable pass 1/2");
        Sub.GetComponent<submarine>().enabled = false;
        Debug.Log("Disable pass 2/2");
        yield return new WaitForSeconds(0.5f);
    }

    /*
     *  FUNCTION NAME: BalanceFlat
     *  RECEIVES: Transform target object (the sub)
     *            Quaternion rot values (the current rotation values of the sub)
     *            Float dur value (the duration of the animation)
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: Balance the submarine's rotation over time until the rotation values are around 0.
     */
    IEnumerator BalanceFlat(Transform target, Quaternion rot, float dur)
    {
        Debug.Log("Balance pass 1/5");
        float time = 0f;
        Quaternion startBalance = target.rotation;

        Debug.Log("Balance pass 2/5");
        while (time < dur)
        {
            Debug.Log("Balance pass 3/5");
            target.rotation = Quaternion.Slerp(startBalance, rot, time / dur);      // Function to smoothly rotate to around 0.
                                                                                    // Amount of movement per frame determined by
                                                                                    // current time / duration of animation.
            yield return null;
            time += Time.deltaTime;
            Debug.Log("Balance pass 4/5");
        }

        target.rotation = rot;
        Debug.Log("Balance pass 5/5");
        yield return new WaitForSeconds(0.5f);
    }

}
