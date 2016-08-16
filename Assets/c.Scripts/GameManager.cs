using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int gameGold = 0;
	public Text gameGold_txt;

	// end game Check
	public static int gameSet; //0:play 1:win 2:lose 3:wait

	public static int TestNum;

	public static bool tiltCheck;
	public GameObject tiltOn;
	public GameObject tiltOff;
	void Start()
    {
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Awake () {
		if (Application.loadedLevelName == "TestGame") {
			StartCoroutine ("GoldCheck");
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

	IEnumerator GoldCheck(){
		while (true) {
			yield return new WaitForSeconds (0.006f);

			gameGold_txt.text = "" + gameGold.ToString("n0");
		}
	}
}
