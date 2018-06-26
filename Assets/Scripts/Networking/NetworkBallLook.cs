using UnityEngine;

public class NetworkBallLook: MonoBehaviour {
    private GameObject ball;

    void Start() {
        ball = GameObject.Find("NetworkBall");
	}
	
	void Update() {
        transform.LookAt(new Vector3 (ball.transform.position.x, transform.position.y, ball.transform.position.z));
	}
}
