using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public GameObject cameraOne;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayCutScene());
    }

    IEnumerator PlayCutScene()
    {
        yield return new WaitForSeconds(32f);
        SceneManager.LoadScene("Intro-Tutorial-Scene");
        cameraOne.SetActive(false);
        /*
        cameraTwo.SetActive(true);
        yield return new WaitForSeconds(5f);
        cameraTwo.SetActive(false);
        cameraThree.SetActive(true);
        yield return new WaitForSeconds(6f);
        */
        //cameraThree.SetActive(false);

    }
}
