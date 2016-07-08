using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public int breakgroundHp;
	public int breakgroundHp_in;


	// Use this for initialization
	void Start () {
		//StartCoroutine (bress());

		switch (this.name) {
		case "ground_Collider":
			break;

		case "breakground_Collider":

			breakgroundHp_in = breakgroundHp;
			//StartCoroutine(breakground());
			break;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*IEnumerator bress() {
		while (true) {
			yield return new WaitForSeconds (0.006f);


		}
	}*/

	/*IEnumerator breakground() {
		while (true) {
			yield return new WaitForSeconds (0.006f);


		}
	}*/

	void OnTriggerExit(Collider player) {

		Debug.Log ("hit");
		if (this.name == "breakground_Collider") {
			Debug.Log ("hit");
			if (player.tag == "player") {
				breakgroundHp_in -= 1;
				if (breakgroundHp_in <= 0) {
				Destroy (this.transform.parent.gameObject);
				}
			}
		}


	}
}
