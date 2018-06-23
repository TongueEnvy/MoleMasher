using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_limitVelocity : MonoBehaviour {

    public float minHorizontalSpeed;
    public float maxHorizontalSpeed;
    float minVerticalSpeed;
    public float maxVerticalSpeed;
    public bool hasBeenServed;

	// Use this for initialization
	void Start () {

        minVerticalSpeed = Physics.gravity.y;

	}

    // Update is called once per frame
    void Update()
    {

        if (hasBeenServed == true)
        {
            var getVelocity = gameObject.GetComponent<Rigidbody>().velocity;

            getVelocity.y = Mathf.Clamp(getVelocity.y, minVerticalSpeed, maxVerticalSpeed);

            var newHorVelocity = new Vector3(getVelocity.x, 0, getVelocity.z);

            if (newHorVelocity.magnitude > maxHorizontalSpeed)
            {

                newHorVelocity.Normalize();
                newHorVelocity = (newHorVelocity * maxHorizontalSpeed);

            }

            if (newHorVelocity.magnitude < minHorizontalSpeed)
            {

                newHorVelocity.Normalize();
                newHorVelocity = (newHorVelocity * minHorizontalSpeed);

            }

            getVelocity.x = newHorVelocity.x;
            getVelocity.z = newHorVelocity.z;


            gameObject.GetComponent<Rigidbody>().velocity = getVelocity;

        }
        else
        {

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
}
