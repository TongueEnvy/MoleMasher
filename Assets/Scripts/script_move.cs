using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_move : MonoBehaviour {

    public string actorName;
    public int playerNumber;
    public float moveSpeed;
    Rigidbody movement;
    public Animator body;
    public AnimationClip bodyShuffle;
    public GameObject hands;
    public GameObject spawner;

	// Use this for initialization
	void Start () {

        gameObject.name = actorName;
        movement = gameObject.GetComponent<Rigidbody>();
        body.Play(bodyShuffle.name);
        body.speed = .25f;

	}
	
	// Update is called once per frame
	void Update () {

        if (playerNumber == 1)
        {

            var getInput = new Vector3(Input.GetAxisRaw("P1 Move Horizontal"), 0, Input.GetAxisRaw("P1 Move Vertical") * moveSpeed);

            movement.velocity = new Vector3(getInput.x * moveSpeed, movement.velocity.y, getInput.z);

            body.speed = Mathf.Abs(getInput.magnitude);

            body.speed = Mathf.Clamp(body.speed, .25f, 1);

        }
        else if (playerNumber == 2)
        {

            var getInput = new Vector3(Input.GetAxisRaw("P2 Move Horizontal"), 0, Input.GetAxisRaw("P2 Move Vertical") * moveSpeed);

            movement.velocity = new Vector3(getInput.x * moveSpeed, movement.velocity.y, getInput.z);

            body.speed = Mathf.Abs(getInput.magnitude);

            body.speed = Mathf.Clamp(body.speed, .25f, 1);

        }

        

    }
}
