using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_jakePowerSlide : MonoBehaviour {

    Animator anim;

    public AnimationClip powerSlide;

    Rigidbody movement;

    string specialButton2;

    bool manualMove;

    public float speedFactor;
    public float slideTimer;
    float slideCounter;
    public float fireIntensity;
    public float kickFactor;
    public float staminaCost;

    public GameObject foot;
    public ParticleSystem footFire;
    public ParticleSystem.EmissionModule emit;

    private void Awake()
    {
        footFire = foot.GetComponent<ParticleSystem>();
        emit = footFire.emission;

    }

    // Use this for initialization
    void Start () {
        
        movement = gameObject.GetComponent<script_stats>().movement;
        specialButton2 = gameObject.GetComponent<script_stats>().specialButton2;
        anim = gameObject.GetComponent<script_stats>().anim;


    }
	
	// Update is called once per frame
	void Update () {

        manualMove = gameObject.GetComponent<script_stats>().manualMove;


        slideCounter -= 1;

        if (slideCounter <= 0)
        {

            slideCounter = 0;
            gameObject.GetComponent<script_stats>().manualMove = true;
            emit.rateOverTime = 0;
            gameObject.GetComponent<script_stats>().kickFactor = 1;

        }

        if (Input.GetButtonDown(specialButton2))
        {

            if(manualMove == true && gameObject.GetComponent<script_stats>().currentStamina > staminaCost)
            {

                slideCounter = slideTimer;
                emit.rateOverTime = fireIntensity;
                gameObject.GetComponent<script_stats>().manualMove = false;
                manualMove = false;
                anim.Play(powerSlide.name);
                anim.speed = 1;
                movement.velocity = Vector3.zero;
                movement.AddRelativeForce(0, 0, speedFactor, ForceMode.Impulse);
                gameObject.GetComponent<script_stats>().kickFactor = kickFactor;
                gameObject.GetComponent<script_stats>().currentStamina -= staminaCost;

            }

        }

    }
}
