using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_autoDestroy : MonoBehaviour {

    public float countdown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {

            Destroy(gameObject);

        }

	}
}
