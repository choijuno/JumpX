using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour {
	Rigidbody mybody;
	// Use this for initialization
	void Start () {
		mybody = GetComponent<Rigidbody> ();
		mybody.AddForce (transform.forward * 500f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {

			mybody.AddForce (transform.forward * 500f);
		}
	
	}


}
