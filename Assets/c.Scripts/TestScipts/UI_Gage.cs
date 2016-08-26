using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Gage : MonoBehaviour {

	public Image gage_bar;

	public GameObject gage_Character;

	public Transform loadParent;

	public GameObject playerBody;

	//
	public GameObject StartPos;
	//

	public float mapPos_S;
	public float mapPos_E;

	public float EndPos;

	float chaPos;
	float chaMax = 564f;

	public GameObject chaStart;
	public GameObject chaEnd;

	// Use this for initialization
	void Start () {
		EndPos = 20f;

		StartCoroutine ("posSet");


	}

	IEnumerator posSet(){
		float timer = 1f;
		while (true) {
			yield return new WaitForSeconds (0.006f);

			if (timer <= 0) {
				
				foreach (Transform child in loadParent) {
					if (child.name.Substring (0, 7) == "1990021") {
						EndPos = child.transform.position.x + 6.08f;
					}

					//start
					if (child.name.Substring (0, 7) == "1990051") {
						mapPos_S = child.transform.position.x;
					}
					//end
					if (child.name.Substring (0, 7) == "1990052") {
						mapPos_E = child.transform.position.x;
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
		
		gage_bar.fillAmount = (playerBody.transform.position.x)  / mapPos_E;
		chaPos = gage_bar.fillAmount * chaMax;
		gage_Character.transform.localPosition = new Vector3 (StartPos.transform.localPosition.x + chaPos -6f , gage_Character.transform.localPosition.y, gage_Character.transform.localPosition.z );
	}
}
