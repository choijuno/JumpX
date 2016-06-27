using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {




	MovePosition playerState = MovePosition.Stay;

	public float MoveSpeed = 0f;
	public float bounceSpeed = -1f;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (MoveSpeed);

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
			MoveSpeed = 0f;
			break;
		case MovePosition.Left:
			MoveSpeed = -1f;
			break;
		case MovePosition.Right:
			MoveSpeed = 1f;
			break;
		}


		transform.position = new Vector3 (transform.position.x + MoveSpeed*0.1f, transform.position.y, transform.position.z);
	
	}


}
