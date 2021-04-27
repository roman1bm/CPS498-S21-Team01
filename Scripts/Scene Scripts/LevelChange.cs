using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator fadeOutController;

    public GameObject submarine;

    private float collisionSleepTimerFloat = 0f;
    private int collisionSleepTimer = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "outer windshield")
        {

            Debug.Log("here");

            fadeOutController.Play("FadeOutLevel", 0);

            while (1 == 1)
            {
                collisionSleepTimerFloat += Time.deltaTime;

                collisionSleepTimer = (int)(collisionSleepTimerFloat % 60);

                if (collisionSleepTimer == 3)
                {
                    collisionSleepTimerFloat = 0f;
                    collisionSleepTimer = 0;
                    break;
                }
            }

            if (SceneManager.GetActiveScene().name == "LevelOne")
            {
                DontDestroyOnLoad(submarine);
                SceneManager.LoadScene("LevelTwo");
            }


        }

    }
}
