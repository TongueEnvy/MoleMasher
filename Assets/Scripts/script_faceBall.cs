using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_faceBall: MonoBehaviour {
    public GameObject ball;

    void Start() {
        ball = GameObject.Find("Ball");
	}
	
	void Update() {
        transform.LookAt(new Vector3 (ball.transform.position.x, transform.position.y, ball.transform.position.z));
	}
}
