using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_respawnBall : MonoBehaviour {

    public float respawnTimer;
    [HideInInspector] public float respawnCounter;
    [HideInInspector] public bool respawning;
    public GameObject ball;

    private void Start()
    {

        ball = GameObject.Find("newBall");

    }

    private void Update()
    {
        if (respawning == true)
        {

            gameObject.GetComponent<script_trackScore>().roundIsDecided = false;
            respawnCounter -= Time.deltaTime;
            if(respawnCounter <= 0 && respawning)
            {

                ball.GetComponent<script_limitVelocity>().hasBeenServed = false;
                ball.transform.position = new Vector3(0, .5f, 0);
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

                respawnCounter = 0;
                respawning = false;

            }
        }
    }
}
