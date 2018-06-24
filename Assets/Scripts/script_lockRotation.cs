using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_lockRotation : MonoBehaviour {

    public Vector3 angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.eulerAngles = angle;

	}
}
