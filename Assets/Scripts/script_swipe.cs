using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_swipe : MonoBehaviour {

    public bool useRightPaw		= true;
    public bool readyToSwing	= true;
    public Animator paws;
    public AnimationClip pawsIdle;
    public AnimationClip rightHook;
    public AnimationClip leftHook;
    public GameObject self;

    // Use this for initialization
    void Start () {

        useRightPaw = true;
        readyToSwing = true;
        paws.Play(pawsIdle.name);

    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetButtonDown("P1 Swipe") && self.GetComponent<script_playerMovement>().playerNumber == 1)
        {
            if (readyToSwing == true)
            {

                if (useRightPaw == true)
                {

                    paws.Play(rightHook.name);
                    useRightPaw = false;

                }
                else
                {

                    paws.Play(leftHook.name);
                    useRightPaw = true;

                }

            }
        }

        if (Input.GetButtonDown("P2 Swipe") && self.GetComponent<script_playerMovement>().playerNumber == 2)
        {
            if (readyToSwing == true)
            {

                if (useRightPaw == true)
                {

                    paws.Play(rightHook.name);
                    useRightPaw = false;

                }
                else
                {

                    paws.Play(leftHook.name);
                    useRightPaw = true;

                }

            }
        }

    }
}
