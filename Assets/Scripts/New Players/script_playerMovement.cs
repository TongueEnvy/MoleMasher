using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_playerMovement: MonoBehaviour {

    public bool isAlive;  //Is the player alive?
    public float reviveTimer;  //How long until player resurrects?
    public float reviveCounter;

    //These variable determine whether the player can run, swing, tackle, and dive
    public bool movementEnabled;  //Can the player run?
    public float diveTimer;  //Time after a dive until the player can run
    public float tackleTimer; //Time after a tackle until the player can run
    float moveCounter; //Time until the player can move again

    public bool isSwinging;  //Is the player swinging?
    public float swingTimer;  //Time after a swing until the player can dive or tackle
    float swingCounter;  //Time until swing concludes

    public string actorName;
    public int playerNumber;
    public float moveSpeed;
    Rigidbody movement;
    public Animator legs;
    public Animator arms;
    public AnimationClip legsRun;
    public AnimationClip legsStand;
    public AnimationClip legsDive;
    public AnimationClip armsRun;
    public AnimationClip armsStand;
    public AnimationClip armsSwing;
    public AnimationClip armsDive;
    public AnimationClip armsTackle;
    public GameObject spawner;

	void Start() {

        gameObject.name = actorName;
        movement = gameObject.GetComponent<Rigidbody>();
        legs.Play(legsStand.name);
        arms.Play(armsStand.name);
        isAlive = true;

	}

	void Update() {

        if (reviveCounter > 0)
        {

            reviveCounter -= Time.deltaTime;

        }
        else if (reviveCounter <= 0)
        {

            reviveCounter = 0;
            isAlive = true;
            gameObject.layer = 9;
            gameObject.GetComponent<script_playerDeath>().model.SetActive(true);
            gameObject.GetComponent<script_playerDeath>().ghost.SetActive(false);

        }

        if (moveCounter > 0)
        {

            moveCounter -= 1;

        }
        else if (moveCounter <= 0)
        {

            moveCounter = 0;
            movementEnabled = true;

        }

        if (swingCounter > 0)
        {

            swingCounter -= 1;

        }
        else if (swingCounter <= 0)
        {

            swingCounter = 0;
            isSwinging = false;

        }

        if (playerNumber == 1 && movementEnabled == true && isSwinging == false) {
            if (isAlive == true)
            {
                if (movementEnabled == true && Input.GetButtonDown("P1 Dive"))
                {

                    arms.speed = 1;
                    legs.speed = 1;
                    arms.Play(armsDive.name);
                    legs.Play(legsDive.name);
                    movementEnabled = false;
                    moveCounter = diveTimer;
                    movement.velocity = transform.forward * 10;

                }

                if (movementEnabled == true && Input.GetButtonDown("P1 Swing") && isSwinging == false)
                {

                    arms.speed = 1;
                    arms.Play(armsSwing.name);
                    isSwinging = true;
                    swingCounter = swingTimer;

                }

                if (movementEnabled == true && Input.GetButtonDown("P1 Tackle") && isSwinging == false)
                {

                    arms.speed = 1;
                    legs.speed = 2;
                    arms.Play(armsTackle.name);
                    legs.Play(legsRun.name);
                    movementEnabled = false;
                    moveCounter = tackleTimer;
                    movement.velocity = transform.forward * 15;

                }
            }

            if (movementEnabled)
            {
                var getInput = new Vector3(Input.GetAxisRaw("P1 Move Horizontal"), 0, Input.GetAxisRaw("P1 Move Vertical"));
                //getInput.Normalize();

                movement.velocity = new Vector3(getInput.x * moveSpeed, movement.velocity.y, getInput.z * moveSpeed);

                if (isAlive == true)
                {
                    if (getInput.magnitude != 0)
                    {

                        arms.Play(armsRun.name);
                        legs.Play(legsRun.name);
                        arms.speed = getInput.magnitude;
                        legs.speed = getInput.magnitude;
                        gameObject.transform.LookAt(new Vector3(transform.position.x + getInput.x, transform.position.y, transform.position.z + getInput.z));

                    }
                    else
                    {

                        arms.Play(armsStand.name);
                        legs.Play(legsStand.name);
                        arms.speed = 1;
                        legs.speed = 1;

                    }
                }

            }

        }
    }
}
