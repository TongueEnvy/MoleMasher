using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_trackScore : MonoBehaviour {

    public Text homeScoreCounter;
    public Text visitorScoreCounter;

    public float homeScore;
    public float visitorScore;

    public string homeCaptainName;
    public string visitorCaptainName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        homeScoreCounter.text = homeCaptainName + " : " + homeScore.ToString();
        visitorScoreCounter.text = visitorCaptainName + " : " + visitorScore.ToString();

    }
}
