using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimTestClass : MonoBehaviour {

    Button Achievement;
    Button leaderBoard;

    Button CloudSave;
    Button CloudLoad;
    Text CloudText;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("로그인");

        CloudSave = GameObject.Find("CloudSave").GetComponent<Button>();
        CloudSave.onClick.AddListener(CloudSaveFunc);
        CloudLoad = GameObject.Find("CloudLoad").GetComponent<Button>();
        CloudLoad.onClick.AddListener(CloudLoadFunc);
        CloudText = GameObject.Find("CloudText").GetComponent<Text>();
        Achievement = GameObject.Find("Achievement").GetComponent<Button>();
        Achievement.onClick.AddListener(ShowAchievementFunc);
        leaderBoard = GameObject.Find("LeaderBoard").GetComponent<Button>();
        leaderBoard.onClick.AddListener(ShowleaderBoardFunc);

        GoogleManager.GetInstance.InitializeGPGS();

        if (!Social.localUser.authenticated)
        {
            GoogleManager.GetInstance.LoginGPGS();
        }
    }
    void CloudSaveFunc()
    {
        GoogleManager.GetInstance.SaveToCloud();
    }
    void CloudLoadFunc()
    {
        GoogleManager.GetInstance.LoadFromCloud();
    }
    void ShowAchievementFunc()
    {
        GoogleManager.GetInstance.ShowAchievement();
    }
    void ShowleaderBoardFunc()
    {
        GoogleManager.GetInstance.ShowLeaderboard();
    }
}
