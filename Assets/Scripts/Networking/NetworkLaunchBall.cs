using UnityEngine;
using UnityEngine.Networking;

public class NetworkLaunchBall: MonoBehaviour {
    public float launchForce	= 40f;
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
