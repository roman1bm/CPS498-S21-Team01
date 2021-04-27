using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeTutorial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Col!");
        if (other.tag == "PlayerSub")
        {
            //DontDestroyOnLoad(other.gameObject);
            SceneManager.LoadScene("LevelOne");

        }
    }
}
