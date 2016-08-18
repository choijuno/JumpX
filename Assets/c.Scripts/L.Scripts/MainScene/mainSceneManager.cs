using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainSceneManager : MonoBehaviour {

    Button startBtn;
    Button faceBookBtn;

    public Image fade;
    float fades = 1.0f;
    float time = 0;
    bool fadeChk = false;

    void Start ()
    {
        startBtn = GameObject.Find("startBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(startBtnFunc);

        faceBookBtn = GameObject.Find("facebookBtn").GetComponent<Button>();
        faceBookBtn.onClick.AddListener(faceBookBtnFunc);
        
    }
    void Update()
    {
        time += Time.deltaTime * 2.0f;
        if (fades > 0.0f && time >= 0.1f)
        {
            if(fadeChk == false)
            {
                fades -= 0.2f;
                fade.color = new Color(0, 0, 0, fades);
            }
            else
            {
                fades += 0.2f;
                fade.color = new Color(0, 0, 0, fades);
                SceneManager.LoadScene(1);
            }
            time = 0;
        }
        else if (fades <= 0.0f)
        {
            time = 0;
            fade.gameObject.SetActive(false);
        }
    }
	void startBtnFunc()
    {
        fade.gameObject.SetActive(true);
        fadeChk = true;
    }
    void faceBookBtnFunc()
    {
        GoogleManager.GetInstance.InitializeGPGS();

        if(!Social.localUser.authenticated)
            GoogleManager.GetInstance.LoginGPGS();
    }
}
