using UnityEngine;
using System.Collections;

public class enemy_fish : MonoBehaviour {

	fishMove move = fishMove.wait;

	public Transform fish_image;


	public float WaitTime;
	float waitTime_in;

	public float MaxHeight;
	float maxHeight_in;
	float baseHeight_in;


	public float UpSpeed;
	float upSpeed_in;

	public float UpLerp;
	float upLerp_in;

	public float DownSpeed;
	float downSpeed_in;


	void Start () {
		waitTime_in = WaitTime;
		maxHeight_in = transform.position.y + MaxHeight;
		baseHeight_in = transform.position.y;
		upSpeed_in = UpSpeed;
		upLerp_in = UpLerp * 0.1f;
		downSpeed_in = DownSpeed * 0.1f;




	}


	void Update () {
		
		switch (move) {

		case fishMove.wait:
			mwait ();
			break;

		case fishMove.up:
			mup ();
			break;

		case fishMove.down:
			mdown ();
			break;

		case fishMove.bite:
			mbite ();
			break;

		}





	}

	void mwait(){
		fish_image.transform.rotation = Quaternion.Euler (0, 0, 0);

		if (waitTime_in >= 0) {
			waitTime_in -= Time.deltaTime;
			//Debug.Log (waitTime_in);

			if (waitTime_in < 0) {
				waitTime_in = WaitTime;
				move = fishMove.up;
				fish_image.transform.rotation = Quaternion.Euler (0, 0, -70);

			}
		}
	}

	void mup(){
		//fish_image.transform.Rotate (0, 0, -10);

		upLerp_in = Mathf.Lerp (upLerp_in, 0, 0.1f);

		if (upLerp_in <= 0) {
			upLerp_in = 0;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y + (upSpeed_in * Time.deltaTime) + upLerp_in, transform.position.z);

		if (transform.position.y >= maxHeight_in) {
			downSpeed_in = 0;
			move = fishMove.down;
			fish_image.transform.rotation = Quaternion.Euler (0, 0, 90);
			transform.position = new Vector3 (transform.position.x, maxHeight_in, transform.position.z);
		}
	}

	void mdown(){
		//fish_image.transform.rotation = new Quaternion (0,0,90,0);

		downSpeed_in = Mathf.Lerp (downSpeed_in, DownSpeed * 2f, 0.9f);

		if (downSpeed_in >= DownSpeed * 0.1f) {
			downSpeed_in = DownSpeed * 0.1f;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y - downSpeed_in * 0.1f, transform.position.z);

		if (transform.position.y <= baseHeight_in) {
			transform.position = new Vector3 (transform.position.x, baseHeight_in, transform.position.z);

			upLerp_in = UpLerp * 0.1f;
			move = fishMove.wait;
		}
	}

	void mbite(){

	}
}
