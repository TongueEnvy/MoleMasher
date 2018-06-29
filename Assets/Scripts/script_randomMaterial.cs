using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_randomMaterial : MonoBehaviour {

    public List<Material> materials;

	// Use this for initialization
	void Start () {

        var newMat = (int)Random.Range(0, materials.Count);
        gameObject.GetComponent<MeshRenderer>().material = materials[newMat];


    }

    public void ChangeMaterial()
    {

        var newMat = (int)Random.Range(0, materials.Count);
        gameObject.GetComponent<MeshRenderer>().material = materials[newMat];

    }
}
