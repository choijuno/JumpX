using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimTestClass : MonoBehaviour {

    Button Achievement;
    Button leaderBoard;
	// Use this for initialization
	void Start ()
    {
        Achievement = GameObject.Find("Achievement").GetComponent<Button>();
        Achievement.onClick.AddListener(ShowAchievementFunc);
        leaderBoard = GameObject.Find("LeaderBoard").GetComponent<Button>();
        leaderBoard.onClick.AddListener(ShowleaderBoardFunc);
        
        if (!Social.localUser.authenticated)
        {
            GoogleManager.GetInstance.InitializeGPGS();
            GoogleManager.GetInstance.LoginGPGS();
        }
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
