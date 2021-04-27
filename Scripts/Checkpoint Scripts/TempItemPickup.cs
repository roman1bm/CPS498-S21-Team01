/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: TempItemPickup.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 4, 2021
    
    DESCRIPTION: Display a text animation for when an item is picked up by the submarine.

    NOTES: Do note that this script currently is still being tested, hence the "Temp" name.
           This script may work with other item pickups, yet may misbehave.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempItemPickup : MonoBehaviour
{

    public Animator PUTextAni;

    /*
     *  Default functions are still present just in case if needed in future development.
     */

    void Start()
    {
        
    }

    void Update()
    {
        
    }

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

        PUTextAni.SetBool("Start", true);
        Debug.Log("Collider pass 2/3.");
        yield return new WaitForSeconds(5.0f);      // Animation time length.
        PUTextAni.SetBool("Start", false);

        Debug.Log("Collider pass 3/3.");
        yield return new WaitForSeconds(0.5f);

    }

}
