using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_attractBall : MonoBehaviour {

    public float pullForce;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        
        if(other.tag == "Ball")
        {

            other.transform.position = Vector3.Lerp(other.transform.position, transform.position, pullForce * Time.deltaTime);

        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
