using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class script_goalieAI : MonoBehaviour {

    public GameObject ball;
    public GameObject tongueTip;

    public NavMeshAgent navAgent;

    Vector3 tongueTarget;
    Vector3 destination;

    public float walkSpeed;
    public float spitForce;
    public float lickSpeed;
    public float lickTimer;
    float lickCounter;

    public bool active;
    bool isLicking;
    bool readyToLick;

	// Use this for initialization
	void Start () {

        active = false;

	}
	
	// Update is called once per frame
	void Update () {
		
        if(navAgent.desiredVelocity != Vector3.zero)
        {

            gameObject.transform.LookAt(transform.position + navAgent.desiredVelocity);

        }

        if(active == true)
        {

            if(isLicking == false)
            {

                if(readyToLick == true)
                {

                    isLicking = true;
                    readyToLick = false;
                    lickCounter = lickTimer;

                }
                else
                {

                    navAgent.destination = ball.transform.position;
                    navAgent.speed = walkSpeed;

                }

            }

        }

	}
}
