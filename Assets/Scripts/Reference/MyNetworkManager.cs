using UnityEngine;
using System.Collections;
 
public class MyNetworkManager: MonoBehaviour {
    public HostData[] hostData;

	private float clearTime;
   
    void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;      
        MasterServer.ClearHostList();
        MasterServer.RequestHostList( "yourFVName" );
        hostData = MasterServer.PollHostList();
    }
   
    IEnumerator DelayedConnection() {
        yield return new WaitForSeconds( 0.0f );
       
        string connectionResult = "";
        if( hostData.Length > 0 ) {
            connectionResult = "" + Network.Connect( hostData[ 0 ] );
            Debug.Log("\nConnect to Server @ " + hostData[ 0 ].gameName + " " + hostData[ 0 ].gameType + " " + hostData[ 0 ].guid + " " + hostData[ 0 ].ip + " " + hostData[ 0 ].useNat + " " + connectionResult);
        }
            
		else
			connectionResult = "";
	}  
   
    void OnDisconnectedFromServer() {
        DelayedConnection();  
    }
   
    void Update() {
        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();
			
        if((Network.peerType == NetworkPeerType.Disconnected) || (Network.peerType != NetworkPeerType.Disconnected && Network.connections.Length < 1 ) )
            return;
			
        print(hostData[0].ip);
    }
   
    void OnPlayerDisconnected( NetworkPlayer player ) {
        Network.RemoveRPCs( player );
    }
 
 
    public void StartServer() {
        Network.InitializeServer( 50, 2301, true );
        MasterServer.RegisterHost( "yourFVName", "Test" );
        foreach (GameObject GameobjectsInGame in FindObjectsOfType(typeof(GameObject)))
        {
            GameobjectsInGame.SendMessage("OnLoaded",SendMessageOptions.DontRequireReceiver);
        }
    }
    public void ConnectServer () {
        if( hostData.Length == 0 )
            hostData = MasterServer.PollHostList();
			
        StartCoroutine( "DelayedConnection" );
    }
}