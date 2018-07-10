using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_stats : MonoBehaviour {

    public Animator anim;
    public AnimationClip run;
    public AnimationClip stand;

    public Rigidbody movement;

    public GameObject model;

    public Image barBlocker;

    public string horAxis;
    public string vertAxis;
    public string specialButton1;
    public string specialButton2;

    public float runspeed;
    public float kickforce;
    public float kickFactor;
    public float maxStamina;
    public float currentStamina;

    public bool manualMove;

	// Use this for initialization
	void Start () {

        manualMove = true;

	}
	
	// Update is called once per frame
	void Update () {

        currentStamina += .1f;

        if (currentStamina > maxStamina)
        {

            currentStamina = maxStamina;

        }

        if (barBlocker != null)
        {
            barBlocker.rectTransform.localPosition = new Vector3((480 * (maxStamina - (maxStamina - currentStamina)) / 100), 0, 0);
        }

    }
}
