using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainSceneManager : MonoBehaviour {

    Button startBtn;
    Button faceBookBtn;

	void Start ()
    {
        startBtn = GameObject.Find("startBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(startBtnFunc);

        faceBookBtn = GameObject.Find("facebookBtn").GetComponent<Button>();
        faceBookBtn.onClick.AddListener(faceBookBtnFunc);
    }

	void startBtnFunc()
    {
        SceneManager.LoadScene(1);
    }
    void faceBookBtnFunc()
    {
        GoogleManager.GetInstance.InitializeGPGS();

        if(!Social.localUser.authenticated)
            GoogleManager.GetInstance.LoginGPGS();
    }
}
