/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: TempCPMenu.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: March 24, 2021
    
    DESCRIPTION: Script for a menu that allows loading to a specific checkpoint.

    NOTES: This script is obsolete!
           This script is only to be used as a reference, remove before final upload.
           Menu only used for the purposes of testing checkpoints.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TempCPMenu : MonoBehaviour
{

    public Button CP1;
    public Button CP2;
    public Button CP3;
    public Button CP4;
    public Button CP5;

    /*
     *  FUNCTION NAME: OnEnable
     *  
     *  DESCRIPTION: Adds on click listeners to each button.
     */

    void OnEnable()
    {
        CP1.onClick.AddListener(() => NextScene(CP1));
        CP2.onClick.AddListener(() => NextScene(CP2));
        CP3.onClick.AddListener(() => NextScene(CP3));
        CP4.onClick.AddListener(() => NextScene(CP4));
        CP5.onClick.AddListener(() => NextScene(CP5));
    }

    /*
     *  FUNCTION NAME: NextScene
     *  
     *  DESCRIPTION: On press, go to selected checkpoint located in a different scene.
     */

    public void NextScene(Button pressed)
    {

        if (pressed = CP1)
        {
            PlayerPrefs.SetInt("CP1", 1);
            SceneManager.LoadScene("MainLevelCopy");
        }

        if (pressed = CP2)
        {
            PlayerPrefs.SetInt("CP2", 1);
            SceneManager.LoadScene("MainLevelCopy");
        }

        if (pressed = CP3)
        {
            PlayerPrefs.SetInt("CP3", 1);
            SceneManager.LoadScene("LevelTwoCopy");
        }

        if (pressed = CP4)
        {
            PlayerPrefs.SetInt("CP4", 1);
            SceneManager.LoadScene("LevelTwoCopy");
        }

        if (pressed = CP5)
        {
            PlayerPrefs.SetInt("CP5", 1);
            SceneManager.LoadScene("MainLevelCopy");
        }

    }
}
