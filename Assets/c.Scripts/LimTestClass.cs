using UnityEngine;
using System.Collections;

public class LimTestClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GoogleManager.GetInstance.InitializeGPGS();
        if(GoogleManager.GetInstance.bLogin == false)
        {
            GoogleManager.GetInstance.LoginGPGS();
        }
        else
        {
            GoogleManager.GetInstance.LogoutGPGS();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
