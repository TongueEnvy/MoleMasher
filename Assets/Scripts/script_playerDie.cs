using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_playerDie : MonoBehaviour {

	// Use this for initialization
	void Start () {

        

	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            GameObject.Find("Scorekeeper").GetComponent<script_respawnPlayers>().respawning = true;
            GameObject.Find("Scorekeeper").GetComponent<script_respawnPlayers>().respawnCounter = GameObject.Find("Scorekeeper").GetComponent<script_respawnPlayers>().respawnTimer;
            Destroy(gameObject);

        }

    }
}
