using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {



	// status use
	MovePosition playerState = MovePosition.Stay;
	GameSet gameset = GameSet.play;
	PlayerMove playerMove;
	// move, bounce speeds
	public float MoveSpeed = 0f;
	float movespeed;



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
			movespeed = 0;
			break;
		case MovePosition.Left:
			transform.rotation = new Quaternion (0, 180, 0, 0);
			movespeed = -MoveSpeed;
			break;
		case MovePosition.Right:
			transform.rotation = new Quaternion (0, 0, 0, 0);
			movespeed = Mathf.Abs(MoveSpeed);
			break;
		}

		// only run playing
		if (gameset == GameSet.play) {
			transform.position = new Vector3 (transform.position.x + movespeed * 0.01f, transform.position.y, transform.position.z);
		}
	}

	// onTrigger Grounds ?
	void OnTriggerEnter(Collider Ground) {

		if (Ground.CompareTag("dead")) {
			GameManager.gameset = true;
			gameset = GameSet.lose;
		}

		if (Ground.CompareTag("clear")) {
			GameManager.gameset = true;
			gameset = GameSet.win;
		}
	}


}
