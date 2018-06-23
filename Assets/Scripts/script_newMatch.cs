using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_newMatch : MonoBehaviour {

    public float restartTimer;
    float restartCounter;

    public bool isCounting;

	// Use this for initialization
	void Start () {

        restartCounter = restartTimer;

	}
	
	// Update is called once per frame
	void Update () {
		
        if(isCounting == true)
        {

            restartCounter -= Time.deltaTime;

            if(restartCounter <= 0)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }

        }

	}
}
