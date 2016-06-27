using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	// player position
	public Transform playerPosition;

	void Start () {
	
	}


	void Update () {
		
		// camera move(lerp)
		transform.position = new Vector3 (Mathf.Lerp(transform.position.x,playerPosition.transform.position.x + 7f,0.1f), transform.position.y, transform.position.z);
	}
}
