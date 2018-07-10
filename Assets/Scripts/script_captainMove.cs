using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_captainMove : MonoBehaviour {

    Animator anim;

    AnimationClip run;
    AnimationClip stand;

    string horAxis;
    string vertAxis;

    bool manualMove;

    Rigidbody movement;

    GameObject model;

    float runSpeed;

	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<script_stats>().anim;
        run = gameObject.GetComponent<script_stats>().run;
        stand = gameObject.GetComponent<script_stats>().stand;
        horAxis = gameObject.GetComponent<script_stats>().horAxis;
        vertAxis = gameObject.GetComponent<script_stats>().vertAxis;
        movement = gameObject.GetComponent<script_stats>().movement;
        model = gameObject.GetComponent<script_stats>().model;
        runSpeed = gameObject.GetComponent<script_stats>().runspeed;

    }
	
	// Update is called once per frame
	void Update () {

        manualMove = gameObject.GetComponent<script_stats>().manualMove;

        var measureInput = new Vector3();
        measureInput.x = Input.GetAxisRaw(horAxis);
        measureInput.z = Input.GetAxisRaw(vertAxis);

        if (manualMove == true)
        {

            if (measureInput != Vector3.zero)
            {

                model.transform.LookAt(transform.position + measureInput);
                anim.Play(run.name);
                anim.speed = measureInput.magnitude;

            }
            else
            {

                anim.Play(stand.name);
                anim.speed = 1;

            }

            movement.velocity = new Vector3(measureInput.x * runSpeed, 0, measureInput.z * runSpeed);

        }


    }
}
