using UnityEngine;
using System.Collections;

public class Cage : MonoBehaviour {
	public GameObject standCage;
	public GameObject breakCage;


	void OnTriggerEnter(Collider player) {
		if (player.CompareTag ("player")) {
			standCage.SetActive (false);
			breakCage.SetActive (true);
		}
	}
}
