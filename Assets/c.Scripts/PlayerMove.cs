using UnityEngine;
using System.Collections;

public class PlayerMove : PlayerController {

	public GameObject gameover;
	public GameObject gameclear;

	Bouncy bounce = Bouncy.bounce;
	GameSet gameset = GameSet.play;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

		if (bounce == Bouncy.bounce) {
			bounceSpeed = bounceSpeed - 0.08f;
			transform.position = new Vector3 (transform.position.x, transform.position.y + bounceSpeed * 0.1f, transform.position.z);
		}

	}

	void OnTriggerEnter(Collider Ground) {
		if (Ground.tag == "ground") {
			bounceSpeed = -2f;
			bounceSpeed = bounceSpeed * -1f;
		}

		if (Ground.tag == "dead") {
			gameover.SetActive (true);
			Invoke ("resetgame", 2f);
			GameSet gameset = GameSet.lose;
			bounce = Bouncy.not;
		}

		if (Ground.tag == "clear") {
			gameclear.SetActive (true);
			GameSet gameset = GameSet.win;
			bounce = Bouncy.not;
		}
	}


	void resetgame(){
		Application.LoadLevel (0);
	}
}
