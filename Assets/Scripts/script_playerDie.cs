using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_playerDie : MonoBehaviour {

    public GameObject scoreKeeper;

	// Use this for initialization
	void Start () {

        scoreKeeper = GameObject.Find("ScoreKeeper");

	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            if (scoreKeeper.GetComponent<script_trackScore>().roundIsDecided == false)
                {

                    if(gameObject.GetComponent<script_move>().playerNumber == 1)
                    {

                        scoreKeeper.GetComponent<script_trackScore>().player2Score += 1;
                        scoreKeeper.GetComponent<script_trackScore>().roundIsDecided = true;

                    }
                    else if (gameObject.GetComponent<script_move>().playerNumber == 2)
                    {

                        scoreKeeper.GetComponent<script_trackScore>().player1Score += 1;
                        scoreKeeper.GetComponent<script_trackScore>().roundIsDecided = true;

                    }

                }
            scoreKeeper.GetComponent<script_respawnPlayers>().respawning = true;
            scoreKeeper.GetComponent<script_respawnPlayers>().respawnCounter = GameObject.Find("Scorekeeper").GetComponent<script_respawnPlayers>().respawnTimer;

            Destroy(gameObject);

        }

    }
}
