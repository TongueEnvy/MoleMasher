﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_respawnPlayers : MonoBehaviour {

    public float respawnTimer;
    [HideInInspector] public float respawnCounter;
    [HideInInspector] public bool respawning;
    public GameObject ball;

    private void Start()
    {

        ball = GameObject.Find("Ball");

    }

    private void Update()
    {
        if (respawning == true)
        {
            respawnCounter -= Time.deltaTime;
            if(respawnCounter <= 0 && respawning)
            {

                respawning = false;
                if(GameObject.Find("Player1"))
                {

                    Destroy(GameObject.Find("Player1"));

                }

                if (GameObject.Find("Player2"))
                {

                    Destroy(GameObject.Find("Player2"));

                }

                foreach(GameObject item in gameObject.GetComponent<script_spawnPlayers>().spawners)
                {

                    item.GetComponent<script_spawn>().OnSpawn();

                }

                ball.transform.position = new Vector3(0, .5f, 0);
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

                respawnCounter = 0;

            }
        }

    }
}