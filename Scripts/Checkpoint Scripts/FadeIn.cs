/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: FadeIn.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: April 20, 2021
    
    DESCRIPTION: Play a fade-in animation once the scene is loaded.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    public Animator FadeInAni;
    public GameObject FadeInObj;

    /*
     *  FUNCTION NAME: Start
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: When starting, play the fade in animation.
     *               Disable the object afterwards.
     */

    IEnumerator Start()
    {
        FadeInObj.SetActive(true);     // Enable fade-in object.
        FadeInAni.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);      // Length of animation.
        FadeInAni.SetTrigger("End");
        FadeInObj.SetActive(false);     // Disable fade-in object.
    }
}
