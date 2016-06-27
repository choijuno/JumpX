using UnityEngine;
using System.Collections;

public class PlayerMove : PlayerController {
	
	// ui win, lose texts
	public GameObject gameover;
	public GameObject gameclear;

	// status use
	Bouncy bounce = Bouncy.bounce;


	void Start () {
	}


	void Update () {
		
		// status equal to bounce
		if (bounce == Bouncy.bounce) {
			bounceSpeed = bounceSpeed - 0.08f;
			transform.position = new Vector3 (transform.position.x, transform.position.y + bounceSpeed * 0.1f, transform.position.z);
		}

	}

	// onTrigger Grounds ?
	void OnTriggerEnter(Collider Ground) {
		
		if (Ground.tag == "ground") {
			bounceSpeed = -2f;
			bounceSpeed = bounceSpeed * -1f;
		}

		if (Ground.tag == "dead") {
			gameover.SetActive (true);
			Invoke ("resetgame", 2f);
			bounce = Bouncy.not;
		}

		if (Ground.tag == "clear") {
			gameclear.SetActive (true);
			Invoke ("resetgame", 2f);
			bounce = Bouncy.not;
		}

	}

	//resetGame
	void resetgame(){
		Application.LoadLevel (0);
	}
}
