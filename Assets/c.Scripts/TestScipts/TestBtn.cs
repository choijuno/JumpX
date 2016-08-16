using UnityEngine;
using System.Collections;

public class TestBtn : MonoBehaviour {
	public GameObject OpenPanel;
	public GameObject ClosePanel;


	public void BtnClick(){
		GameManager.TestNum = int.Parse(this.name.Substring (0, 3));
        /*
        if (GameManager.TestNum == 001)
        {
            Social.ReportProgress(GPGS.achievement_test1, 100.0f, (bool success) =>
            {

            });
        }
        if(GameManager.TestNum == 003)
        {
            Social.ReportProgress(GPGS.achievement_test1, 100.0f, (bool success) =>
            {

            });
        }*/
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
