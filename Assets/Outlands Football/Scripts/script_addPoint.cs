using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_addPoint : MonoBehaviour {

    public GameObject scoreKeeper;

    public int teamNumber;

    public bool roundIsDecided;

    public void OnTriggerEnter(Collider other)
    {

        if (roundIsDecided == false && other.tag == "Ball")
        {

            if(teamNumber == 1)
            {

                scoreKeeper.GetComponent<script_trackScore>().visitorScore += 1;
                roundIsDecided = true;

            }

            if (teamNumber == 2)
            {

                scoreKeeper.GetComponent<script_trackScore>().homeScore += 1;
                roundIsDecided = true;

            }

        }

    }

    public void OnTriggerExit(Collider other)
    {

        roundIsDecided = false;

    }

}
