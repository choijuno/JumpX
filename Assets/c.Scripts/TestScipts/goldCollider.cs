using UnityEngine;
using System.Collections;

public class goldCollider : MonoBehaviour {

	public GameObject model;
	public GameObject modelDestroy;
	public AudioClip goldSound;


	void OnTriggerEnter(Collider player){
		if (player.CompareTag ("player")) {
			AudioSource.PlayClipAtPoint(goldSound, new Vector3(this.transform.position.x + 4f, this.transform.position.y, -10f));
			model.SetActive (false);
			modelDestroy.SetActive (true);
			this.GetComponent<BoxCollider> ().enabled = false;
		}

	}
}
