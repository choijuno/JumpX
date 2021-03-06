﻿using UnityEngine;
using System.Collections;

public class Tree_R : MonoBehaviour {

	public GameObject fruit;
	public GameObject fruit_image;

	public bool StopCheck;

	public float waitTime;
	float waitTime_in;
	public float attSpeed;
	float attSpeed_in;
	public float stunTime;
	float Xbase;
	float Ybase;

	float turnSpeed_in;
	// Use this for initialization
	void Start () {
		Xbase = fruit.transform.position.x;
		Ybase = fruit.transform.position.y;
		//waitTime_in = waitTime;
		//attSpeed_in = attSpeed * 0.001f;
		waitTime_in = Random.Range (2, 3);
		attSpeed_in = Random.Range (60, 100);
		turnSpeed_in = attSpeed_in / 4;
		attSpeed_in = attSpeed_in * 0.001f;
		if (!StopCheck) {
			StartCoroutine ("wait");
			StartCoroutine ("att");
		}
	}

	// Update is called once per frame
	IEnumerator wait(){
		while (true) {
			yield return new WaitForSeconds (0.006f);
			waitTime_in = waitTime_in - Time.deltaTime;
			if (waitTime_in <= 0) {
				waitTime_in = Random.Range (2f, 4f);
				Debug.Log (waitTime_in);
				attSpeed_in = Random.Range (60, 100);
				turnSpeed_in = attSpeed_in / 4;
				attSpeed_in = attSpeed_in * 0.001f;
				fruit.transform.position = new Vector3(Xbase, Ybase, 0);
				fruit.SetActive (true);
			}
		}
	}

	IEnumerator att(){
		while (true) {
			yield return new WaitForSeconds (0.006f);
			fruit.transform.position = new Vector3 (fruit.transform.position.x, fruit.transform.position.y - attSpeed_in, 0);
			fruit_image.transform.Rotate (0, 0, turnSpeed_in);
		}
	}


}
