using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	// ui win, lose texts
	public GameObject gameover;
	public GameObject gameclear;

	// status use
	Bouncy bounce = Bouncy.Down;

	public float MaxHeight;
	float height;

	public float HeightSpeed;
	float lerpSpeed;

	public float bounceSpeed;
	float bouncySpeed;


	void Start () {
		height = transform.position.y + MaxHeight;
		lerpSpeed = HeightSpeed;
		bouncySpeed = bounceSpeed;
		bouncySpeed *= -1f;
	}


	void Update () {
		// status equal to bounce
		if (bounce != Bouncy.not) {
			


			switch (bounce) {
			case Bouncy.Down:
				Debug.Log ("Down : " + lerpSpeed);
				//lerpSpeed = lerpSpeed + lerpSpeed * 0.3f;
				lerpSpeed = Mathf.Lerp (lerpSpeed, HeightSpeed, 0.1f);

				if (lerpSpeed >= HeightSpeed) {
					lerpSpeed = HeightSpeed;
				}

				transform.position = new Vector3 (transform.position.x, transform.position.y + (bouncySpeed * Time.deltaTime) - lerpSpeed, transform.position.z);
				break;
			case Bouncy.Up:
				Debug.Log ("Up : " + lerpSpeed);
				//lerpSpeed = lerpSpeed - lerpSpeed * 0.3f;
				lerpSpeed = Mathf.Lerp (lerpSpeed, 0, 0.1f);
				if (lerpSpeed <= 0) {
					lerpSpeed = 0;
				}

				transform.position = new Vector3 (transform.position.x, transform.position.y + (bouncySpeed * Time.deltaTime) + lerpSpeed, transform.position.z);
				break;
			}



			//transform.position = new Vector3 (transform.position.x, transform.position.y + (bouncySpeed * Time.deltaTime) + (lerpSpeed * Time.deltaTime), transform.position.z);


			if (transform.position.y >= height) {
				bounce = Bouncy.Down;
				transform.position = new Vector3 (transform.position.x, height, transform.position.z);
				bouncySpeed *= -1f;
				lerpSpeed = 0;
			} 


			/*if (transform.position.y <= height) {
				bounceSpeed -= 0.1f ;
				transform.position = new Vector3 (transform.position.x, transform.position.y + bounceSpeed * Time.deltaTime, transform.position.z);
			} else {
				bounceSpeed = -1f;
				bounceSpeed -= 0.1f * Time.deltaTime;
				transform.position = new Vector3 (transform.position.x, transform.position.y + bounceSpeed * Time.deltaTime, transform.position.z);
			}*/
		}

	}

	// onTrigger Grounds ?
	void OnTriggerEnter(Collider Ground) {
		
		if (Ground.tag == "ground") {
			bounce = Bouncy.Up;
			bouncySpeed *= -1f;
			height = transform.position.y + MaxHeight;

			lerpSpeed = HeightSpeed;

			/*
			height = transform.position.y + MaxHeight;
			bounceSpeed = HeightSpeed;
			*/
		}

		if (Ground.tag == "dead") {
			gameover.SetActive (true);
			Invoke ("resetgame", 2f);
			bounce = Bouncy.not;
		}

		if (Ground.tag == "clear") {
			gameclear.SetActive (true);
			Invoke ("resetgame", 2f);
			bounce = Bouncy.not;
		}

	}

	//resetGame
	void resetgame(){
		Application.LoadLevel (0);
	}
}
