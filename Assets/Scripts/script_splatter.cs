using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_splatter : MonoBehaviour {

    public GameObject splatter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        var newSplatter = Instantiate<GameObject>(splatter);
        newSplatter.transform.parent = gameObject.transform;
        newSplatter.transform.localPosition = Vector3.zero;
        newSplatter.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        newSplatter.transform.localScale = new Vector3(1,1,1);
        newSplatter.transform.parent = null;

        Destroy(gameObject);
    }
}
