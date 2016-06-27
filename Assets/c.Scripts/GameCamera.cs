using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	public Transform playerPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerPosition.transform.position.x + 7f, transform.position.y, transform.position.z);
	}
}
