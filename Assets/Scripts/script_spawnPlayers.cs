using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_spawnPlayers : MonoBehaviour {

    public List<GameObject> spawners;

	// Use this for initialization
	void Start () {
		
        foreach (GameObject item in spawners)
        {

            item.GetComponent<script_spawn>().OnSpawn();

        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
