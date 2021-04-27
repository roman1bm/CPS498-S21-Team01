using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    
    public void ChangeToCutScene()
    {

        //Changes from the main menu to the cut scene
        SceneManager.LoadScene("NavyOpenCutScene");

    }

    public void ChangeToLevelOne()
    {

        //Changes scene from the cut scene to the first level
        SceneManager.LoadScene("LevelOne");

    }

    public void ChangeToLevelTwo()
    {

        //Changes scene from level one to level two
        SceneManager.LoadScene("LevelTwo");

    }

    public void ChangeToCredits()
    {

        //Changes scene from main menu to the credits
        SceneManager.LoadScene("Credits");

    }

    public void ChangeToMainMenu()
    {

        //Changes scene from training or credits to the main menu
        SceneManager.LoadScene("MainMenu");

    }

    public void ChangeToTraining()
    {

        //Changes scene from main menu to the training
        SceneManager.LoadScene("Training");

    }

}
