using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// ui win, lose texts
	//public GameObject gameover;
	//public GameObject gameclear;

	// status use
	public Transform StartPos;

	public Bouncy bounce = Bouncy.Down;
	public float readyTime;

	public GameObject deadEffect;
	public GameObject deadBody;
	public GameObject bumpEffect;

	//MaxHeight
	public float MaxHeight;
	float MaxHeight_in;

	//up
	public float UpKey = 1111111;

	public float UpLerp;
	float UpLerp_in;
	public float UpBounceSpeed;
	float UpBounceSpeed_in;

	//down
	public float DownKey = 1111111;

	public float DownLerp;
	float DownLerp_in;
	//public float DownBounceSpeed;
	//float DownBounceSpeed_in;


	void Awake () {
		transform.position = StartPos.position;
		bounce = Bouncy.Ready;

		//RESET height
		MaxHeight_in = transform.position.y + MaxHeight;

		//up
		UpLerp_in = UpLerp * 0.1f;
		UpBounceSpeed_in = UpBounceSpeed;

		//down
		DownLerp_in = DownLerp * 0.1f;
		//DownBounceSpeed_in = -DownBounceSpeed;

		StartCoroutine ("GameReady");


	}

	IEnumerator GameReady(){
		
		while (true) {
			yield return new WaitForSeconds (readyTime);

			bounce = Bouncy.Up;
			GameManager.gameSet = 0;
			//Debug.Log (bounce);
			StopCoroutine ("GameReady");

		}
	}




	void Update () {
		// status equal to bounce
		if (bounce != Bouncy.Not) {
			switch (bounce) {

			case Bouncy.Down:
				BDown ();
				break;

			case Bouncy.Up:
				BUp ();
				break;

			}
				
			if (transform.position.y >= MaxHeight_in) {
				bumpEffect.SetActive (false);
				DownLerp_in = 0;
				bounce = Bouncy.Down;
				transform.position = new Vector3 (transform.position.x, MaxHeight_in, transform.position.z);
			} 

		} else {
			BNot ();
		}

	}

	void BDown(){
		//Debug.Log ("Down : " + DownLerp_in);

		DownLerp_in = Mathf.Lerp (DownLerp_in, DownLerp * 0.5f, 0.001f);

		if (DownLerp_in >= DownLerp * 0.1f) {
			DownLerp_in = DownLerp * 0.1f;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y - DownLerp_in * 0.1f, transform.position.z);
	}

	void BUp(){
		//Debug.Log ("Up : " + lerpSpeed);
		UpLerp_in = Mathf.Lerp (UpLerp_in, 0, 0.1f);


		if (UpLerp_in <= 0) {
			UpLerp_in = 0;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y + (UpBounceSpeed_in * Time.deltaTime) + UpLerp_in, transform.position.z);
	}

	void BNot(){
		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f * Time.deltaTime, transform.position.z);
	}

	// onTrigger Grounds ?
	void OnTriggerEnter(Collider Ground) {

		if (Ground.CompareTag("ground")) {
			if (bounce == Bouncy.Down) {
				if (!Ground.CompareTag ("Untagged")) {
					if(GameManager.gameSet == 0)
						bumped ();
				}
				UpLerp_in = UpLerp * 0.1f;
				bounce = Bouncy.Up;

				//bouncySpeed *= -1f;
				MaxHeight_in = transform.position.y + MaxHeight;
			}
		}

		if (Ground.CompareTag("dead")) {
			Debug.Log ("dead");
			//gameover.SetActive (true);
			deadBody.SetActive(false);
			deadEffect.SetActive(true);
			Invoke ("resetgame", 2f);
			bounce = Bouncy.Not;
		}

		if (Ground.CompareTag("clear")) {
			//gameclear.SetActive (true);
			Invoke ("resetgame", 2f);
			bounce = Bouncy.Not;
		}



	}

	// hit Ground Effect
	void bumped() {
			bumpEffect.transform.position = this.transform.position;
			bumpEffect.SetActive (true);
	}


	//resetGame
	void resetgame(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
