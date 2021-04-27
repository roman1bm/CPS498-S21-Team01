/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: TempThreeToOne.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 5, 2021
    
    DESCRIPTION: Display a text & image animation for when the player reaches a checkpoint.
                 During the animation, balance the submarine flat.
                 This script imcludes starting fade-in and fade-out animations.
                 After the fade-out, go to next checkpoint/scene.

    NOTES: Do note that this is a "Temp" script, used for testing purposes.
           In current development, each checkpoint has their own script. It may be possible
           to merge each script into one single script once testing is complete.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempThreeToOne : MonoBehaviour
{
    public string TrackerID;
    public Animator FadeIn;
    public Animator FadeOut;
    public Animator CPImageAni;
    public Animator CPTextAni;

    /*
     *  FUNCTION NAME: Start
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: When starting, play the fade in animation.
     */

    IEnumerator Start()
    {
        FadeIn.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        FadeIn.SetTrigger("End");
    }

    /*
     *  FUNCTION NAME: OnTriggerEnter
     *  RECEIVES: Collider game object
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: On collision, display a text & image animation notifying of checkpoint reach.
     *               Display for a set amount of time, then stop animating.
     *               During animation, balance the submarine flat.  (Not present)
     *               At the end of text & image animation, play fade-out animation.
     *               At the end of fade-out enimation, go to next checkpoint.
     */

    IEnumerator OnTriggerEnter(Collider col)
    {
        Debug.Log("Collider pass 1/5. " + col.name + " - " + col.gameObject.tag);

        if (col.gameObject.tag == TrackerID)
        {
            Debug.Log("Collider pass 2/5.");
            CPImageAni.SetTrigger("Start");
            Debug.Log("Collider pass 3/5.");
            CPTextAni.SetTrigger("Start");
            Debug.Log("Collider pass 4/5.");
            yield return new WaitForSeconds(5.0f);
            CPImageAni.SetTrigger("End");
            CPTextAni.SetTrigger("End");
            yield return new WaitForSeconds(1.0f);
            FadeOut.SetTrigger("Start");
            yield return new WaitForSeconds(1.0f);
            FadeOut.SetTrigger("End");
            SceneManager.LoadScene("TempOne");      // Change the LoadScene(" ") to appropriate scene.
        }

        Debug.Log("Collider pass 5/5.");
        yield return new WaitForSeconds(0.5f);

    }

}
