using UnityEngine;

public class NetworkBallLook: MonoBehaviour {
    private GameObject ball;

    void Start() {
        ball = GameObject.Find("NetworkBall(Clone)");
	}
	
	void Update() {
        transform.LookAt(ball.transform);
	}
}
