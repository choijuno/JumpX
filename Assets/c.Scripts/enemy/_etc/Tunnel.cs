using UnityEngine;
using System.Collections;

public class Tunnel : MonoBehaviour {
	public GameObject exit;
	public bool moveCheck;

	public float waitTime;
	public float Speed;
	public float exitTime;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator wait(){
		while (true) {
			yield return new WaitForSeconds (0.006f);

			if (moveCheck) {

			}
		}
	}


}
