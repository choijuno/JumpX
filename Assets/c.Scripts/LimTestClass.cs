using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimTestClass : MonoBehaviour {

    Button GoogleLoginBtn;
    Text LoginCallBack;
    Text LogInOut;
	// Use this for initialization
	void Start () {

        GoogleLoginBtn = GameObject.Find("GoogleLoginBtn").GetComponent<Button>();
        GoogleLoginBtn.onClick.AddListener(GoogleLoginBtnFunc);

        LoginCallBack = GameObject.Find("LoginCallBack").GetComponent<Text>();
        LogInOut = GameObject.Find("LogInOut").GetComponent<Text>();

        GoogleManager.GetInstance.InitializeGPGS();
        LoginCallBack.text = "로그인 : " + GoogleManager.GetInstance.bLogin.ToString();
    }
    void Update()
    {
        LoginCallBack.text = "로그인 : " + GoogleManager.GetInstance.bLogin.ToString();
    }
	void GoogleLoginBtnFunc()
    {
        if (GoogleManager.GetInstance.bLogin == false)
        {
            GoogleManager.GetInstance.LoginGPGS();
            LogInOut.text = "로그아웃";
            Debug.Log("로그아웃");
        }
        else
        {
            GoogleManager.GetInstance.LogoutGPGS();
            LogInOut.text = "로그인";
            Debug.Log("로그인");
        }
    }
}
