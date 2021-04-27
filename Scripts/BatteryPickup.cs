using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public AudioClip pickUpSound;
    [Range(0.0f, 1f)]
    public float volume = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "PlayerSub")
        {
            collision.transform.GetComponent<SubBattery>().addBattery();
            collision.transform.GetComponent<AudioSource>().PlayOneShot(pickUpSound, volume);
            Destroy(this.transform.gameObject);
        }
    }
}
