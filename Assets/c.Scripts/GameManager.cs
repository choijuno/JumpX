using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	// end game Check
	public static int gameSet; //0:play 1:win 2:lose 3:wait

	void Awake () {
		gameSet = 3;
	}


	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit ();
		}
	}
}
