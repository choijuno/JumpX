using UnityEngine;
using System.Collections;

public class TestBtn : MonoBehaviour {

	public void BtnClick(){
		GameManager.TestNum = int.Parse(this.name.Substring (0, 3));

		Application.LoadLevel ("TestGame");
	}

	public void TestHome() {
		Application.LoadLevel ("TestMain");
	}
}
