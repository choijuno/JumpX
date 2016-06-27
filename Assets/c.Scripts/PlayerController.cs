using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {



	// status use
	MovePosition playerState = MovePosition.Stay;
	GameSet gameset = GameSet.play;

	// move, bounce speeds
	public float MoveSpeed = 0f;



	void Start () {
		

	}


	void Update () {
		//Debug.Log (MoveSpeed);

		// raycast hit to gameObject in click point. change to MovePosition(status)
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.gameObject.CompareTag ("left")) {
						playerState = MovePosition.Left;
					}
					if (hit.collider.gameObject.CompareTag ("right")) {
						playerState = MovePosition.Right;
					}
				}

		} else {
			playerState = MovePosition.Stay;
		}

		// status equal change speed
		switch (playerState) {
		case MovePosition.Stay:
			MoveSpeed = 0f;
			break;
		case MovePosition.Left:
			MoveSpeed = -1f;
			break;
		case MovePosition.Right:
			MoveSpeed = 1f;
			break;
		}

		// only run playing
		if (gameset == GameSet.play) {
			transform.position = new Vector3 (transform.position.x + MoveSpeed * 0.1f, transform.position.y, transform.position.z);
		}
	}

	// onTrigger Grounds ?
	void OnTriggerEnter(Collider Ground) {

		if (Ground.tag == "dead") {
			GameManager.gameset = true;
			gameset = GameSet.lose;
		}

		if (Ground.tag == "clear") {
			GameManager.gameset = true;
			gameset = GameSet.win;
		}
	}


}
