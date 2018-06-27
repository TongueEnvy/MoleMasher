using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_launchBall: MonoBehaviour {
    public float launchForce;
    public GameObject body;
    public AudioClip struck;

    // Use this for initialization
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Ball") {
            other.gameObject.GetComponent<script_limitVelocity>().hasBeenServed = true;
            other.gameObject.GetComponent<Rigidbody>().velocity = ((other.transform.position - body.transform.position).normalized * launchForce);
            other.gameObject.GetComponent<AudioSource>().clip = struck;
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
