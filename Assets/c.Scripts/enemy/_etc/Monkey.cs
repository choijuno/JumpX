using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {

	public GameObject banana;
	public float waitTime;
	float waitTime_in;
	public float attSpeed;
	float attSpeed_in;

	// Use this for initialization
	void Start () {
		waitTime_in = waitTime;
		attSpeed_in = attSpeed * 0.001f;
		StartCoroutine ("wait");
		StartCoroutine ("att");
	}
	
	// Update is called once per frame
	IEnumerator wait(){
		while (true) {
			yield return new WaitForSeconds (0.006f);
			waitTime_in = waitTime_in - Time.deltaTime;
			if (waitTime_in <= 0) {
				waitTime_in = waitTime;
				banana.SetActive (true);
				banana.transform.position = transform.position;
			}
		}
	}

	IEnumerator att(){
		while (true) {
			yield return new WaitForSeconds (0.006f);
			banana.transform.position = new Vector3 (banana.transform.position.x - attSpeed_in, banana.transform.position.y - attSpeed_in, banana.transform.position.z);
		}
	}
}
