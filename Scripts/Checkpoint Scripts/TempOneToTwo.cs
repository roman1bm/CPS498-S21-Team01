/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: TempOneToTwo.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 10, 2021
    
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

public class TempOneToTwo : MonoBehaviour
{

    public string TrackerID;
    public Animator FadeIn;
    public Animator FadeOut;
    public Animator CPImageAni;
    public Animator CPTextAni;
    public GameObject Sub;

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
     *  **NOTES: Some obsolete code. May need to use as reference during further development.
     */

    /*    void Start()
        {
    *//*        CPImageAni = GetComponent<Animator>();
            CPTextAni = GetComponent<Animator>();*//*
        }*/

    /*    IEnumerator Update()
        {
            FadeIn.SetTrigger("Start");
            yield return new WaitForSeconds(1.0f);
            FadeIn.SetTrigger("End");
        }*/

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
        Debug.Log("Collider pass 1/5. " + col.name + " - " + col.gameObject.tag);

        if (col.gameObject.tag == TrackerID)
        {
            Debug.Log("Collider pass 2/5.");
            CPImageAni.SetTrigger("Start");
            Debug.Log("Collider pass 3/5.");
            CPTextAni.SetTrigger("Start");

            StartCoroutine(DisableMove());

            StartCoroutine(BalanceFlat(Sub.transform, Quaternion.identity, 5f));        // Change float value to change duration of balance.

            Debug.Log("Collider pass 4/5.");
            yield return new WaitForSeconds(5.0f);
            CPImageAni.SetTrigger("End");
            CPTextAni.SetTrigger("End");
            yield return new WaitForSeconds(1.0f);

            FadeOut.SetTrigger("Start");
            yield return new WaitForSeconds(3.0f);
            FadeOut.SetTrigger("End");
            SceneManager.LoadScene("TempTwo");      // Change the LoadScene(" ") to appropriate scene.
        }

        Debug.Log("Collider pass 5/5.");
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
        Sub.GetComponent<submarine>().enabled = false;
        yield return new WaitForSeconds(0.5f);
    }

    /*
     *  FUNCTION NAME: BalanceFlat
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
            target.rotation = Quaternion.Slerp(startBalance, rot, time / dur);
            yield return null;
            time += Time.deltaTime;
            Debug.Log("Balance pass 4/5");
        }

        target.rotation = rot;
        Debug.Log("Balance pass 5/5");
        yield return new WaitForSeconds(0.5f);
    }

    /*
     * **NOTES: Some obsolete code. Different approach to balance, yet not smooth but instant.
     */

    /*
            Debug.Log("Balance pass 1/5");
            float epsilon = 0.1f;
            float currentAngle = Sub.transform.localEulerAngles.y;
            if (currentAngle< 360 - epsilon && currentAngle> epsilon)
            {
                Debug.Log("Balance pass 2/5");
                float angleDelta = Time.deltaTime * 1;
                int rotMultiplier = (currentAngle > 100) ? 1 : -1;
                float resultAngle = Mathf.Clamp(currentAngle + rotMultiplier * angleDelta, 0, 360);
                Debug.Log("Balance pass 3/5");
                Vector3 rotation = Sub.transform.localEulerAngles;
                   rotation.x = resultAngle;
                Debug.Log("Balance pass 4/5");
                Sub.transform.localEulerAngles = rotation;
            }
            Debug.Log("Balance pass 5/5");
            yield return new WaitForSeconds(0.5f);
    */

}
