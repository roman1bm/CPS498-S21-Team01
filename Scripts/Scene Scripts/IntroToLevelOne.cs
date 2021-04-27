using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToLevelOne : MonoBehaviour
{
    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "PlayerSub")
        {

            Debug.Log("here");

            if (SceneManager.GetActiveScene().name == "Intro-Tutorial-Scene")
            {
               
                SceneManager.LoadScene("LevelOne");
            }


        }

    }
}
