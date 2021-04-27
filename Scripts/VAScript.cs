using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VAScript : MonoBehaviour
{
    /*
     *  VAScript
     *  Used to play different voice lines during game via collision with game object
     * 
     * Variables:
     * lines: list of audioclips (if more than 1)
     * subaudio: audiosource in submarine
     * subtitles: strings with subtitles
     * textLine: text object in game
     * time: time used for subtitles
     */
    public AudioClip[] lines;
    private AudioSource subAudio;
    public string[] subtitles;
    public Text textLine;
    public float time;
    // Start is called before the first frame update

    // Update is called once per frame

    /*
     * VoiceLines
     * used to play sound lines in game
     * uses an array if there is more than 1 voice line for onTriggerEnter
     */
    IEnumerator VoiceLines()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (subAudio.isPlaying)
            {
                subAudio.Stop();
                textLine.text = "";
            }
            subAudio.PlayOneShot(lines[i]);
            yield return new WaitForSeconds(lines[i].length +1);
        }
        textLine.text = "";
        Destroy(transform.gameObject);
    }

    /*
     * Subtitles
     * controls subtitles when triggered
     * uses an array for multiple subtitles
     */
    IEnumerator Subtitles()
    {
        for(int i = 0; i < subtitles.Length; i++)
        {
            textLine.text = subtitles[i];
            yield return new WaitForSeconds(time);
        }
        textLine.text = "";
    }

    /*
     * OnTriggerEnter
     * if player sub hits voiceacting empties, sound and subtitles start
     */
    private void OnTriggerEnter(Collider other)
    {
        //print(other);
        if (other.transform.tag == "PlayerSub")
        {
            GetComponent<BoxCollider>().enabled = false;
            subAudio = other.transform.GetComponent<AudioSource>();
            StartCoroutine(VoiceLines());
            StartCoroutine(Subtitles());
            
            
        }
    }


}
