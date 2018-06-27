using UnityEngine;
using UnityEngine.Networking;

public class NetworkBallSpawn: NetworkBehaviour {
    public GameObject ballPrefab;
	public Transform ballSpawn;
	
    public override void OnStartServer() {
		var ballObject = (GameObject)Instantiate(
			ballPrefab,
			ballSpawn.position,
			ballSpawn.rotation
		);
        NetworkServer.Spawn(ballObject);
    }
}