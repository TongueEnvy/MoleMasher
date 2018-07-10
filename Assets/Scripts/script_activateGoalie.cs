using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_activateGoalie : MonoBehaviour {

    public GameObject goalie;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ball")
        {
            goalie.GetComponent<script_goalieAI>().active = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            goalie.GetComponent<script_goalieAI>().active = false;
        }

    }
}
