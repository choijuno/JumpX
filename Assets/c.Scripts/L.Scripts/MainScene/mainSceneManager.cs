using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainSceneManager : MonoBehaviour {

    Button startBtn;
    Button faceBookBtn;

    public Canvas Canvas;
    CanvasGroup canvasGroup;
    bool fadeIn;
    bool fadeOut;
    void Start ()
    {
        fadeIn = true;
        fadeOut = true;
        startBtn = GameObject.Find("startBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(startBtnFunc);

        faceBookBtn = GameObject.Find("facebookBtn").GetComponent<Button>();
        faceBookBtn.onClick.AddListener(faceBookBtnFunc);
        canvasGroup = Canvas.GetComponent<CanvasGroup>();
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        while(fadeIn)
        {
            canvasGroup.alpha += Time.deltaTime * 2;
            if (canvasGroup.alpha >= 1)
                fadeIn = false;
            yield return null;
        }
        canvasGroup.interactable = true;
        yield return null;
    }

    IEnumerator FadeOut()
    {
        while (fadeOut)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            if (canvasGroup.alpha <= 0)
                fadeOut = false;
            yield return null;
        }
        canvasGroup.interactable = false;
        SceneManager.LoadScene(1);
        yield return null;
    }
	void startBtnFunc()
    {
        StartCoroutine(FadeOut());
    }
    void faceBookBtnFunc()
    {
        GoogleManager.GetInstance.InitializeGPGS();

        if(!Social.localUser.authenticated)
            GoogleManager.GetInstance.LoginGPGS();
    }
}
