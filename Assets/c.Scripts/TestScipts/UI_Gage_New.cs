using UnityEngine;
using System.Collections;

public class UI_Gage_New : MonoBehaviour {

	public Transform loadParent;

	//gage
	public GameObject startPos;
	public GameObject endPos;
	float startPos_x;
	float endPos_x;
	float chaPos;


	public GameObject characterPos;
	public GameObject clearPos;



	//ingame
	public GameObject start_in;
	public GameObject end_in;
	public GameObject playerPos;

	// Use this for initialization
	void Start () {
		startPos_x = startPos.transform.position.x;
		endPos_x = endPos.transform.position.x;
		
		StartCoroutine ("posSet");
	}

	IEnumerator posSet(){
		
		float timer = 1f;

		while (true) {
			yield return new WaitForSeconds (0.006f);

			if (timer <= 0) {
				

				foreach (Transform child in loadParent) {
					if (child.name.Substring (0, 7) == "???????") {
						//startpos
					}

					if (child.name.Substring (0, 7) == "???????") {
						//endpos
					}

				}

				StopCoroutine ("posSet");
			} else {
				timer = timer - Time.deltaTime;
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		
		characterPos.transform.localPosition = new Vector3 (startPos.transform.localPosition.x + chaPos, characterPos.transform.localPosition.y, characterPos.transform.localPosition.z );
	
	}
}
