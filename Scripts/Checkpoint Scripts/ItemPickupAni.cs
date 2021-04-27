/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: ItemPickupAni.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 20, 2021

    DESCRIPTION: Display a text animation for when an item is picked up by the submarine.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupAni : MonoBehaviour
{

    public string TrackerID;
    public Animator PUTextAni;

    /*
     *  FUNCTION NAME: OnTriggerEnter
     *  RECEIVES: Collider game object
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: On collision, display a text animation notifying of item pickup. 
     *               Display for a set amount of time, then stop animating.
     */
    IEnumerator OnTriggerEnter(Collider col)
    {

        Debug.Log("Collider pass 1/3. " + col.name + " - " + col.gameObject.tag);

        if (col.gameObject.tag == TrackerID)
        {
            PUTextAni.SetBool("Start", true);       // Start animation.
            Debug.Log("Collider pass 2/3.");
            yield return new WaitForSeconds(5.0f);      // Animation time length.
            PUTextAni.SetBool("Start", false);      // End animation.

            Debug.Log("Collider pass 3/3.");
            yield return new WaitForSeconds(0.5f);
        }

    }
}
