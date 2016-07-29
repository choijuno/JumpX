using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// end game Check
	public static int gameSet; //0:play 1:win 2:lose 3:wait

	public static int TestNum;

	public static bool tiltCheck;
	public GameObject tiltOn;
	public GameObject tiltOff;
	void Start(){
		


	}

	void Awake () {
		if (Application.loadedLevelName == "TestGame") {
			if (tiltCheck) {
				tiltOn.SetActive (true);
				tiltOff.SetActive (false);
			}
		}
		gameSet = 3;
	}


	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit ();
		}
	}
}
