using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class MonsterSoundScript : MonoBehaviour
{
    public GameObject monster;
    private AudioSource noise;
    private float timer = 0.0f;
    private int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        noise = monster.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("timer sound + " + seconds);

        timer += Time.deltaTime;

        seconds = (int)(timer % 60);

        if (seconds == 6)
        {
            noise.Play();
            timer = 0;
            seconds = 0;
        }

    }
}
