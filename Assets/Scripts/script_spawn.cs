using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_spawn : MonoBehaviour {

    public GameObject actor;
    public bool actorIsDead;

    private void Start()
    {

        GameObject.Find("ScoreKeeper").GetComponent<script_spawnPlayers>().spawners.Add(gameObject);

    }

    public void OnSpawn()
    {

        var newActor = Instantiate<GameObject>(actor);
        newActor.transform.position = transform.position;
        actorIsDead = false;

        if (newActor.GetComponent<script_move>())
        {

            newActor.GetComponent<script_move>().spawner = gameObject;

        }

    }

}
