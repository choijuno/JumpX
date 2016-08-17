using UnityEngine;
using System.Collections;

public class BtnController : MonoBehaviour {

	public GameObject OpenPanel_1;
	public GameObject OpenPanel_2;

	public GameObject ClosePanel_1;
	public GameObject ClosePanel_2;



	public void pauseBtn() {
		Time.timeScale = 0.0001f;
		GameManager.pauseCheck = true;
		justOpen ();
		justClose ();
	}

	public void pauseClose(){
		Time.timeScale = 1f;
		GameManager.pauseCheck = false;
		justOpen ();
		justClose ();
	}

	public void pauseReset(){
		Time.timeScale = 1f;
		GameManager.pauseCheck = false;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void pauseHome(){
		Time.timeScale = 1f;
		GameManager.pauseCheck = false;
		Application.LoadLevel ("TestMain");
	}

	public void Bgm_OnOff(){
		switch (this.name) {
		case "On":
			openClose ();
			ClosePanel_2.SetActive (false);
			break;
		case "Off":
			openClose ();
			OpenPanel_2.SetActive (true);
			break;
		}
	}

	public void Sound_OnOff(){
		switch (this.name) {
		case "On":
			openClose ();
			break;
		case "Off":
			openClose ();
			break;
		}
	}

	void openClose() {
		OpenPanel_1.SetActive (true);
		ClosePanel_1.SetActive (false);
	}

	void justOpen() {
		OpenPanel_1.SetActive (true);
	}
	void justClose() {
		ClosePanel_1.SetActive (false);
	}
}
