using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnLevelTwo : MonoBehaviour
{

    //public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //DontDestroyOnLoad(other.gameObject);
            SceneManager.LoadScene("LevelTwo");

        }

    }
}

