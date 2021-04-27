/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: FadeOut.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 20, 2021
    
    DESCRIPTION: Play a fade-out animation once a button is pressed.
                 After press, load next scene.

    NOTES: This is only used for the main menu.
           Fade-out animations are tied with checkpoint scripts.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{

    public Animator FadeOutAni;
    public GameObject FadeOutObj;

    /*
     *  FUNCTION NAME: Start
     *  
     *  DESCRIPTION: Ensure the fade-out object is disabled on start.
     */

    public void Start()
    {
        FadeOutObj.SetActive(false);
    }

    /*
     *  FUNCTION NAME: OnStartButtonPress
     *  
     *  DESCRIPTION: On a button press, play a fade-out animation.
     *               Button press will enable the object.
     *               After the animation, load the next scene.
     */

    public void OnStartButtonPress()
    {
        FadeOutObj.SetActive(true);     // Enable fade-out object.
        StartCoroutine(AnimationStart()); 
    }

    /*
     *  FUNCTION NAME: AnimationStart
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: Start the fade-out animation.
     */

    public IEnumerator AnimationStart()
    {
        FadeOutAni.SetTrigger("Start");
        yield return new WaitForSeconds(3.0f);      // Length of animation.
        FadeOutAni.SetTrigger("End");
        SceneManager.LoadScene("NavyOpenCutScene");     // Load Cut Scene after animation.
    }

}
