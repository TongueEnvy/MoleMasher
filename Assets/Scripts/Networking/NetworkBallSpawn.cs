using UnityEngine;
using UnityEngine.Networking;

public class NetworkBallSpawn: NetworkBehaviour {
    public GameObject ballPrefab;
	
    public override void OnStartServer() {
		GameObject ballObject = Instantiate(ballPrefab);
		ballObject.name = "NetworkBall";
        NetworkServer.Spawn(ballObject);
    }
}