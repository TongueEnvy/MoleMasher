using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_mouseCursor : MonoBehaviour {

    public GameObject point;
    public GameObject currentButton;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Button")
        {

            currentButton = collision.gameObject;

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        currentButton = null;

    }

    // Update is called once per frame
    void Update () {

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("P1 Move Horizontal"), Input.GetAxisRaw("P1 Move Vertical")) * 8;

        if (Input.GetButtonDown("Submit") && currentButton != null)
        {

            currentButton.GetComponent<Button>().onClick.Invoke();

        }

	}
}
