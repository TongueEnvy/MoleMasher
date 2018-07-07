using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_playerLandShot: MonoBehaviour {
    public float launchForce;
    public GameObject body;
    public AudioClip struck;

    // Use this for initialization
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Ball") {
            other.gameObject.GetComponent<script_limitVelocity>().hasBeenServed = true;

            other.transform.rotation = body.transform.rotation;

            other.gameObject.GetComponent<Rigidbody>().velocity = (other.transform.forward * launchForce);

            other.gameObject.GetComponent<AudioSource>().clip = struck;
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
