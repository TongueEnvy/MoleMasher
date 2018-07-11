using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_summonElegy : MonoBehaviour {

    Animator anim;

    public AnimationClip summon;

    string specialButton2;

    bool manualMove;
    bool hasSpawnedBird;

    public GameObject elegy;
    public GameObject model;

    public float staminaCost;
    public float pullForce;
    public float birdSpeed;
    public float birdLifeSpan;
    public float spellTimer;
    float spellCounter;
    public float birdDelay;

	// Use this for initialization
	void Start () {

        specialButton2 = gameObject.GetComponent<script_stats>().specialButton2;
        anim = gameObject.GetComponent<script_stats>().anim;
        hasSpawnedBird = true;

    }
	
	// Update is called once per frame
	void Update () {

        spellCounter -= 1;

        if(spellCounter <= (spellTimer - birdDelay) && hasSpawnedBird == false)
        {

            var newBird = Instantiate<GameObject>(elegy);
            newBird.transform.position = transform.position + new Vector3(0, .5f, 0);
            newBird.transform.rotation = model.transform.rotation;
            newBird.GetComponent<Rigidbody>().velocity = (newBird.transform.forward * birdSpeed);
            newBird.GetComponent<script_attractBall>().pullForce = pullForce;
            newBird.GetComponent<script_autoDestroy>().countdown = birdLifeSpan;
            hasSpawnedBird = true;

        }

        if (spellCounter <= 0)
        {

            spellCounter = 0;
            gameObject.GetComponent<script_stats>().manualMove = true;
            manualMove = true;

        }

        if (Input.GetButtonDown(specialButton2))
        {

            if (manualMove == true && gameObject.GetComponent<script_stats>().currentStamina > staminaCost)
            {

                hasSpawnedBird = false;
                spellCounter = spellTimer;
                gameObject.GetComponent<script_stats>().manualMove = false;
                manualMove = false;
                anim.Play(summon.name);
                anim.speed = 1;
                gameObject.GetComponent<script_stats>().currentStamina -= staminaCost;


            }

        }

    }
}
