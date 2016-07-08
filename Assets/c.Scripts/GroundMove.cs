using UnityEngine;
using System.Collections;

public class GroundMove : MonoBehaviour {
	MovePosition movePos = MovePosition.Left;
	public objectStyle style;

	public bool move;

	public float leftmoveSpeed;
	float leftmoveSpeed_in;
	public float rightmoveSpeed;
	float rightmoveSpeed_in;


	public float minRange;
	float minRange_in;
	public float maxRange;
	float maxRange_in;

	void Awake () {
		leftmoveSpeed_in = leftmoveSpeed * 0.001f;
		rightmoveSpeed_in = rightmoveSpeed * 0.001f;

		minRange_in = transform.position.x - minRange;
		maxRange_in = transform.position.x + maxRange;

		if (move) {
			StartCoroutine ("moveStart");
		}
	
	}
	
	// Update is called once per frame
	IEnumerator moveStart(){
		while (true) {
			yield return new WaitForSeconds (0.006f);

			switch (movePos) {
			case MovePosition.Left:
				if (transform.position.x >= minRange_in) {
					transform.position = new Vector3 (transform.position.x - leftmoveSpeed_in, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3 (minRange_in, transform.position.y, transform.position.z);
					if (style == objectStyle.crocodile) {
						transform.localScale = new Vector3 (-2, 1, 1);
					}
					movePos = MovePosition.Right;
				}
				break;
			case MovePosition.Right:
				if (transform.position.x <= maxRange_in) {
					transform.position = new Vector3 (transform.position.x + rightmoveSpeed_in, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3 (maxRange_in, transform.position.y, transform.position.z);
					if (style == objectStyle.crocodile) {
						transform.localScale = new Vector3 (2, 1, 1);
					}
					movePos = MovePosition.Left;
				}
				break;
			}

		}
	}
}
