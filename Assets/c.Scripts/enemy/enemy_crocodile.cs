using UnityEngine;
using System.Collections;

public class enemy_crocodile : MonoBehaviour {
	public int normalHp;
	public int normalHp_in;
	public int anglyHp;
	public int anglyHp_in;

	public GameObject normal;
	public GameObject angly;
	public GameObject angly_move;


	crocodileMove move = crocodileMove.normal;

	// Use this for initialization
	void Start () {
		normalHp_in = normalHp;
		anglyHp_in = anglyHp;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider player) {
		switch (move) {

		case crocodileMove.normal:
			if (player.tag == "player") {
				normalHp_in -= 1;
				if (normalHp_in <= 0) {
					//normal.SetActive (false);
					//angly.SetActive (true);

					move = crocodileMove.angly;
				}
			}
			break;
		case crocodileMove.angly:
			if (player.tag == "player") {
				anglyHp_in -= 1;
				if (anglyHp_in <= 0) {
					normal.SetActive (false);
					angly.SetActive (false);
					angly_move.SetActive (true);
				}
			}
			break;

		}

	}
}
