using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_scoreGoal : MonoBehaviour {

    public GameObject scoreKeeper;
    public int teamNumber;

	// Use this for initialization
	void Start () {
		


	}

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Ball" && scoreKeeper.GetComponent<script_trackScore>().roundIsDecided == false)
        {

            if(teamNumber == 1)
            {

                scoreKeeper.GetComponent<script_trackScore>().player1Score += 1;

            }
            else if(teamNumber == 2)
            {

                scoreKeeper.GetComponent<script_trackScore>().player2Score += 1;

            }

            scoreKeeper.GetComponent<script_trackScore>().roundIsDecided = true;
            scoreKeeper.GetComponent<script_trackScore>().currentRound += 1;
            scoreKeeper.GetComponent<script_respawnBall>().respawnCounter = scoreKeeper.GetComponent<script_respawnBall>().respawnTimer;
            scoreKeeper.GetComponent<script_respawnBall>().respawning = true;

        }

    }


    // Update is called once per frame
    void Update () {
		


	}
}
