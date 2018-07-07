using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_playerDeath: MonoBehaviour {
    public GameObject scoreKeeper;
    public GameObject bloodDrop;
    public GameObject bloodStainFloor;
    public GameObject bloodStainBall;
    public GameObject model;
    public GameObject ghost;
    public float dropletHorSpeed;
    public float dropletVertSpeed;
    public AudioClip die;

    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ball") {
            collision.gameObject.GetComponent<AudioSource>().clip = die;
            collision.gameObject.GetComponent<AudioSource>().Play();

            var newSplatter = Instantiate<GameObject>(bloodStainFloor);
            newSplatter.transform.parent = gameObject.transform;
            newSplatter.transform.localPosition = Vector3.zero;
            newSplatter.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            newSplatter.transform.parent = null;

            newSplatter = Instantiate<GameObject>(bloodStainBall);
            newSplatter.transform.parent = collision.gameObject.transform;
            newSplatter.transform.localPosition = Vector3.zero;
            newSplatter.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);

            var dropletCount = (int)Random.Range(0, 3);
            
			for(var i = 0; i <= dropletCount; i += 1) {
                var newDroplet = Instantiate<GameObject>(bloodDrop);
                newDroplet.transform.parent = gameObject.transform;
                newDroplet.transform.localPosition = new Vector3(0, .5f, 0);
                var dropScaleFactor = Random.Range(.1f, .5f);
                newDroplet.transform.parent = null;
                newDroplet.transform.localScale = new Vector3(dropScaleFactor, dropScaleFactor, dropScaleFactor);
                newDroplet.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-dropletHorSpeed, dropletHorSpeed), Random.Range(0, dropletVertSpeed), Random.Range(-dropletHorSpeed, dropletHorSpeed));
                var vectorCheck = new Vector3(newDroplet.GetComponent<Rigidbody>().velocity.x, 0, newDroplet.GetComponent<Rigidbody>().velocity.z);
                
				if(vectorCheck.magnitude > dropletHorSpeed) {
                    vectorCheck.Normalize();
                    vectorCheck = vectorCheck * Random.Range(-dropletHorSpeed, dropletHorSpeed);
                    newDroplet.GetComponent<Rigidbody>().velocity = new Vector3(vectorCheck.x, newDroplet.GetComponent<Rigidbody>().velocity.y, vectorCheck.z);
                }
            }

            gameObject.GetComponent<script_playerMovement>().isAlive = false;
            gameObject.GetComponent<script_playerMovement>().reviveCounter = gameObject.GetComponent<script_playerMovement>().reviveTimer;
            gameObject.GetComponent<script_playerMovement>().movementEnabled = true;
            gameObject.GetComponent<script_playerMovement>().isSwinging = false;
            gameObject.layer = 15;
            model.SetActive(false);
            ghost.SetActive(true);
        }
    }
}
