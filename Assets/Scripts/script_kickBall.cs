using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_kickBall : MonoBehaviour {

    Rigidbody movement;

    public GameObject player;

    float kickForce;
    float kickFactor;

	// Use this for initialization
	void Start () {

        movement = player.GetComponent<Rigidbody>();
        kickForce = player.GetComponent<script_stats>().kickforce;

	}

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ball")
        {

            var finalKickPower = kickForce * kickFactor;
            other.GetComponent<Rigidbody>().velocity = movement.transform.forward * finalKickPower;
            other.GetComponent<Rigidbody>().velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x, 4, other.GetComponent<Rigidbody>().velocity.z);

        }

    }

    // Update is called once per frame
    void Update () {

        kickFactor = player.GetComponent<script_stats>().kickFactor;

    }
}
