using UnityEngine;
using System.Collections;

public class TestBtn : MonoBehaviour {
	public GameObject OpenPanel;
	public GameObject ClosePanel;


	public void BtnClick(){
		GameManager.TestNum = int.Parse(this.name.Substring (0, 3));

		Application.LoadLevel ("TestGame");
	}

	public void TestHome() {
		Application.LoadLevel ("TestMain");
	}

	public void TestOn(){
		GameManager.tiltCheck = false;
		Debug.Log (GameManager.tiltCheck);
		openP ();
		closeP ();
	}

	public void TestOff(){
		GameManager.tiltCheck = true;
		Debug.Log (GameManager.tiltCheck);
		openP ();
		closeP ();
	}

	void openP(){
		OpenPanel.SetActive (true);
	}

	void closeP(){
		ClosePanel.SetActive (false);

	}
}
