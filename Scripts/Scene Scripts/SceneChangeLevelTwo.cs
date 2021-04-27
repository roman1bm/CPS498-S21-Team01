using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeLevelTwo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerSub")
        {
            DontDestroyOnLoad(other.gameObject);
            SceneManager.LoadScene("Intro-Tutorial-Scene");

        }
    }
}
