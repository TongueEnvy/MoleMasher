using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_kickBall : MonoBehaviour {

    Rigidbody movement;

    public GameObject player;

    float kickForce;

	// Use this for initialization
	void Start () {

        movement = player.GetComponent<Rigidbody>();
        kickForce = player.GetComponent<script_stats>().kickforce;

	}

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ball")
        {

            other.GetComponent<Rigidbody>().velocity = movement.velocity.normalized * kickForce;
            other.GetComponent<Rigidbody>().velocity += new Vector3(0, 4, 0);

        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
