/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: SceneOneToTwo.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 20, 2021
    
    DESCRIPTION: Display a text & image animation for when the player reaches a checkpoint.
                 This script imcludes the fade-out animation.
                 After the fade-out, go to next checkpoint/scene.

    NOTES: In current development, each checkpoint has their own script. 
           It is best to create a new copy for each individual checkpoint
           and change the appropriate "LoadScene" value.

    SCENE FOR: LevelOne
    SCENE TO:  LevelTwo
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOneToTwo : MonoBehaviour
{

    public string TrackerID;
    public Animator FadeOut;
    public Animator CPImageAni;
    public Animator CPTextAni;

    /*
     *  FUNCTION NAME: OnTriggerEnter
     *  RECEIVES: Collider game object
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: On collision, display a text & image animation notifying of checkpoint reach.
     *               Display for a set amount of time, then stop animating.
     *               Before animation, disable the Submarine movement script.
     *               During animation, balance the submarine flat.
     *               At the end of text & image animation, play fade-out animation.
     *               At the end of fade-out enimation, go to next checkpoint.
     */
    IEnumerator OnTriggerEnter(Collider col)
    {
        Debug.Log("Collider pass 1/5. " + col.name + " - " + col.gameObject.tag);       // See what is colliding.

        if (col.gameObject.tag == TrackerID)
        {
            Debug.Log("Collider pass 2/5.");        // Start of text & image animation.
            CPImageAni.SetTrigger("Start");
            CPTextAni.SetTrigger("Start");

            Debug.Log("Collider pass 3/5.");        // End of text & image animation.
            yield return new WaitForSeconds(5.0f);      // Length of text & image animation.
            CPImageAni.SetTrigger("End");
            CPTextAni.SetTrigger("End");
            yield return new WaitForSeconds(1.0f);      // Short pause before fade-out.

            Debug.Log("Collider pass 4/5.");      // Short pause before fade-out.
            FadeOut.SetTrigger("Start");
            yield return new WaitForSeconds(3.0f);      // Length of fade-out animation.
            FadeOut.SetTrigger("End");
            SceneManager.LoadScene("LevelTwo");      // *** Change the LoadScene(" ") to appropriate scene. *** //
        }

        Debug.Log("Collider pass 5/5.");
        yield return new WaitForSeconds(0.5f);

    }
}
