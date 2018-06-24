using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_trackScore : MonoBehaviour {

    public int roundsPerMatch;
    public int currentRound;
    public int player1Score;
    public int player2Score;

    public string player1Name;
    public string player2Name;
    public string victoryQuote;

    public Text header;
    public Text p1ScoreCounter;
    public Text p2ScoreCounter;

    public int victor;

    public bool roundIsDecided;

	// Use this for initialization
	void Start () {

        currentRound = 0;

	}

    public void BeginMatch()
    {

        currentRound = 0;
        player1Score = 0;
        player2Score = 0;
        header.text = " ";
        roundIsDecided = false;

    }

    public void EndMatch() {

        if(victor == 1)
        {

            header.text = (player1Name + victoryQuote);

        }
        else if (victor == 2)
        {

            header.text = (player2Name + victoryQuote);

        }
        gameObject.GetComponent<script_newMatch>().isCounting = true;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (player1Score > player2Score)
        {

            victor = 1;

        }
        else if(player2Score > player1Score)
        {

            victor = 2;

        }

        p1ScoreCounter.text = player1Name + ":" + player1Score.ToString();
        p2ScoreCounter.text = player2Name + ":" + player2Score.ToString();

        if(currentRound >= roundsPerMatch)
        {

            roundIsDecided = true;
            EndMatch();

        }

    }
}
