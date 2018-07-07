using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_anchor : MonoBehaviour {

    public GameObject destination;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {

        transform.position = destination.transform.position;

	}
}
