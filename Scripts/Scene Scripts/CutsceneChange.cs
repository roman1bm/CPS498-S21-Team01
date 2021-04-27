using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutsceneChange : MonoBehaviour
{

    void Start()
    {
        Animator start = this.gameObject.GetComponent<Animator>();
        start.Play("FadeOutCutscene", 0);
    }

    public void toSinkCutscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
