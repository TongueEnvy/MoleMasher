using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_limitVelocity : MonoBehaviour {

    public float minHorizontalSpeed;
    public float maxHorizontalSpeed;
    float minVerticalSpeed;
    public float maxVerticalSpeed;

	// Use this for initialization
	void Start () {

        minVerticalSpeed = Physics.gravity.y;

	}
	
	// Update is called once per frame
	void Update () {

        var getVelocity = gameObject.GetComponent<Rigidbody>().velocity;

        getVelocity.y = Mathf.Clamp(getVelocity.y ,minVerticalSpeed, maxVerticalSpeed);
        
        if(getVelocity.x > 0)
        {

            getVelocity.x = Mathf.Clamp(getVelocity.x ,minHorizontalSpeed, maxHorizontalSpeed);

        }
        else if (getVelocity.x < 0)
        {

            getVelocity.x = Mathf.Clamp(getVelocity.x , -minHorizontalSpeed, -maxHorizontalSpeed);

        }

        if (getVelocity.z > 0)
        {

            getVelocity.z = Mathf.Clamp(getVelocity.z, minHorizontalSpeed, maxHorizontalSpeed);

        }
        else if (getVelocity.z < 0)
        {

            getVelocity.z = Mathf.Clamp(getVelocity.z, -minHorizontalSpeed, -maxHorizontalSpeed);

        }


        gameObject.GetComponent<Rigidbody>().velocity = getVelocity;

    }
}
