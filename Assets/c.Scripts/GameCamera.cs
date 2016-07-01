using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	// player position
	MovePosition playerState;
	public float MoveSpeed;
	float movespeed;

	public GameObject midleBackGround;
	public Transform playerPosition;
	public float CameraCenterPosition;
	void Start () {
		movespeed = MoveSpeed;
	}


	void Update () {
		
		// camera move(lerp)
		transform.position = new Vector3 (Mathf.Lerp(transform.position.x,playerPosition.transform.position.x + CameraCenterPosition ,0.1f), transform.position.y, transform.position.z);

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

		switch (playerState) {
		case MovePosition.Stay:
			movespeed = 0;
			break;
		case MovePosition.Left:
			movespeed = Mathf.Abs(MoveSpeed);
			break;
		case MovePosition.Right:
			movespeed = -MoveSpeed;
			break;
		}

		midleBackGround.transform.position = new Vector3 (midleBackGround.transform.position.x + movespeed * 0.001f, midleBackGround.transform.position.y, midleBackGround.transform.position.z);
	}


}
