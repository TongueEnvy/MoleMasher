using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove: NetworkBehaviour {
    public string actorName;
    public int playerNumber;
    public float moveSpeed;
    public Animator body;
    public AnimationClip bodyShuffle;
    public GameObject hands;
    //public GameObject spawner;
	
	public bool useRightPaw		= true;
    public bool readyToSwing	= true;
    //public Animator paws;
    public AnimationClip pawsIdle;
    public AnimationClip rightHook;
    public AnimationClip leftHook;
    public GameObject self;

	private Animator paws;
	private Rigidbody movement;
	
	void Start() {
        gameObject.name = actorName;
        movement = gameObject.GetComponent<Rigidbody>();
		paws = self.GetComponent<Animator>();
        body.Play(bodyShuffle.name);
        body.speed = .25f;
		paws.Play(pawsIdle.name);
	}
	
	void Update() {
        if(!isLocalPlayer) {
            return;
        }
		
		var getInput = new Vector3(Input.GetAxisRaw("P1 Move Horizontal"), 0, Input.GetAxisRaw("P1 Move Vertical") * moveSpeed);
        movement.velocity = new Vector3(getInput.x * moveSpeed, movement.velocity.y, getInput.z);
        body.speed = Mathf.Abs(getInput.magnitude);
        body.speed = Mathf.Clamp(body.speed, .25f, 1);

        if(Input.GetButtonDown("P1 Swipe")) {
            Swipe();
        }
    }
	
	// This [Command] code is called on the Client …
    // … but it is run on the Server!
	//[Command]
    void Swipe() {
        if(readyToSwing == true) {
            if (useRightPaw == true) {
                paws.Play(rightHook.name);
                useRightPaw = false;
            }
				
            else {
                paws.Play(leftHook.name);
                useRightPaw = true;
            }
        }
    }
}
