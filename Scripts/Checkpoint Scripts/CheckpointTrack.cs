/*
    ----------------------------------------------------------------------------------------------
    FILE NAME: CheckpointTrack.cs
    AUTHOR: Nathan Wisniewski
    LAST REVISION DATE: March 24, 2021
    
    DESCRIPTION: Initial version of a checkpoint system. The script uses a tracker object
                 that keeps track on what checkpoint is active in a given scene. Dependent
                 on the checkpoint, each checkpoint will advance to a different scene.

    NOTES: This script is obsolete!
           This script is only to be used as a reference, remove before final upload.
           Multiple scripts for each individual scene is being developed instead,
           for simplicity and labeling each individual checkpoint during testing.
           Additionally, a tracker is not recommended if there is only one checkpoint
           in a level. Implement a tracker if multiple checkpoints in a scene is present.
    ----------------------------------------------------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrack : MonoBehaviour
{

    public GameObject Tracker;
    public GameObject Waypoint00;
    public GameObject Waypoint01;
    public GameObject Waypoint02;
    public string TrackerID;
    //public GameObject Sub;
    public GameObject CP1Image;
    public GameObject CP2Image;
    public GameObject CP3Image;
    public GameObject CP4Image;
    public GameObject CP5Image;

    /*
     *  FUNCTION NAME: Update
     *  
     *  DESCRIPTION: With each frame, update the state of the game.
     *               If the Player's last checkpoint is a certain checkpoint,
     *               then place tracker to the next checkpoint's location.
     */

    void Update()
    {

        CP1Image.SetActive(false);
        CP2Image.SetActive(false);
        CP3Image.SetActive(false);
        CP4Image.SetActive(false);
        CP5Image.SetActive(false);

        if (PlayerPrefs.GetInt("CP1") == 1)
        {
            Tracker.transform.position = Waypoint01.transform.position;
            Tracker.transform.rotation = Waypoint01.transform.rotation;
            Debug.Log("Pref read 1/5.");
        }

        if (PlayerPrefs.GetInt("CP2") == 1)
        {
            Tracker.transform.position = Waypoint02.transform.position;
            Tracker.transform.rotation = Waypoint02.transform.rotation;
            Debug.Log("Pref read 2/5.");
        }

        if (PlayerPrefs.GetInt("CP3") == 1)
        {
            Tracker.transform.position = Waypoint01.transform.position;
            Tracker.transform.rotation = Waypoint01.transform.rotation;
            Debug.Log("Pref read 3/5.");
        }

        if (PlayerPrefs.GetInt("CP4") == 1)
        {
            Tracker.transform.position = Waypoint02.transform.position;
            Tracker.transform.rotation = Waypoint02.transform.rotation;
            Debug.Log("Pref read 4/5.");
        }

        if (PlayerPrefs.GetInt("CP5") == 1)
        {
            Tracker.transform.position = Waypoint00.transform.position;
            Tracker.transform.rotation = Waypoint00.transform.rotation;
            Debug.Log("Pref read 5/5.");
        }

    }

    /*
     *  FUNCTION NAME: ImageWait
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: Display time of an checkpoint image.
     */

    IEnumerator ImageWait()
    {
        yield return new WaitForSeconds(3f);
    }

    /*
     *  FUNCTION NAME: OnTriggerEnter
     *  RECEIVES: Collider game object
     *  RETURNS: IEnumerator (Wait for time)
     *  
     *  DESCRIPTION: On collision, check if the collision comes from the player.
     *               Then, disable the tracker until the function is ending,
     *               placing the tracker at the next chekcpoint. Then, dependent
     *               on the checkpoint, update the player's last checkpoint reached
     *               and display an image for said checkpoint.
     *               **Then, balance the submarine flat.
     */

    IEnumerator OnTriggerEnter(Collider col)
    {
        Debug.Log("Collider pass 1/5.");

        if (col.gameObject.tag == TrackerID)
        {
            this.GetComponent<BoxCollider>().enabled = false;

            Debug.Log("Collider pass 2/5.");

            if (PlayerPrefs.GetInt("CP1") == 1)
            {
                Update();
                PlayerPrefs.SetInt("CP1", 0);
                PlayerPrefs.SetInt("CP2", 1);
                Debug.Log("Collider pass 3/5.");
                CP1Image.SetActive(true);
                ImageWait();
                Debug.Log("Collider pass 4/5.");
                CP1Image.SetActive(false);
            }

            else if (PlayerPrefs.GetInt("CP2") == 1)
            {
                Update();
                PlayerPrefs.SetInt("CP2", 0);
                PlayerPrefs.SetInt("CP3", 1);
                CP2Image.SetActive(true);
                ImageWait();
                CP2Image.SetActive(false);
            }

            else if (PlayerPrefs.GetInt("CP3") == 1)
            {
                Update();
                PlayerPrefs.SetInt("CP3", 0);
                PlayerPrefs.SetInt("CP4", 1);
                CP3Image.SetActive(true);
                ImageWait();
                CP3Image.SetActive(false);
            }

            else if (PlayerPrefs.GetInt("CP4") == 1)
            {
                Update();
                PlayerPrefs.SetInt("CP4", 0);
                PlayerPrefs.SetInt("CP5", 1);
                CP4Image.SetActive(true);
                ImageWait();
                CP4Image.SetActive(false);
            }

            else if (PlayerPrefs.GetInt("CP5") == 1)
            {
                Update();
                PlayerPrefs.SetInt("CP5", 0);
                CP5Image.SetActive(true);
                ImageWait();
                CP5Image.SetActive(false);
            }

            Debug.Log("Collider pass 5/5.");

            /*
             *  **NOTES: Did not work as indended during initial tests.
             *           Requires re-work, use commented section as reference.
             */

            /*
            
                while (Sub.transform.rotation.x >= 1)
                        {
                            yield return new WaitForSeconds(0.1f);
                            Sub.transform.rotation.x.Equals(Sub.transform.rotation.x - 1);
                        }

                        while (Sub.transform.rotation.x <= 0)
                        {
                            yield return new WaitForSeconds(0.1f);
                            Sub.transform.rotation.x.Equals(Sub.transform.rotation.x + 1);
                        }

                        while (Sub.transform.rotation.y >= 1)
                        {
                            yield return new WaitForSeconds(0.1f);
                            Sub.transform.rotation.y.Equals(Sub.transform.rotation.y - 1);
                        }

                        while (Sub.transform.rotation.y <= 0)
                        {
                            yield return new WaitForSeconds(0.1f);
                            Sub.transform.rotation.y.Equals(Sub.transform.rotation.y + 1);
                        }

                        while (Sub.transform.rotation.z >= 1)
                        {
                            yield return new WaitForSeconds(0.1f);
                            Sub.transform.rotation.z.Equals(Sub.transform.rotation.z - 1);
                        }

                        while (Sub.transform.rotation.z <= 0)
                        {
                            yield return new WaitForSeconds(0.1f);
                            Sub.transform.rotation.z.Equals(Sub.transform.rotation.z + 1);
                        }

                        yield return new WaitForSeconds(3f);
            
             */

            yield return new WaitForSeconds(0.5f);
            this.GetComponent<BoxCollider>().enabled = true;

        }

    }

}
