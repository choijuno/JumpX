using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// enemy speed
	public float speed = 1f;

	void Start () {
	
	}


	void Update () {
		//only run playing
		if (!GameManager.gameset) {
			transform.position = new Vector3 (transform.position.x + speed * 0.01f, transform.position.y, transform.position.z);
		}
	}
}
