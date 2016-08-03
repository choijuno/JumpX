using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class GoogleManager : GoogleSingleton<GoogleManager> {
    
    public class TestScore
    {
        public int test;
    }

    TestScore TS = new TestScore();
    Text CloudText;

    void Start()
    {
        
    }
    public bool bLogin
    {
        get;
        set;
    }
    
    public void InitializeGPGS()
    {
        TS.test = 100;
        bLogin = false;
        CloudText = GameObject.Find("CloudText").GetComponent<Text>();
        //PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);

        PlayGamesPlatform.Activate();
    }
    public bool CheckLogin()
    {
        return Social.localUser.authenticated;
    }
    public void SaveToCloud()
    {
        CloudText.text = "첫번째 세이브";
        OpenSavedGame("SaveTest", true);
    }
    void OpenSavedGame(string filename, bool bSave)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        if (bSave)
        {
            CloudText.text = "두번째 세이브";
            Debug.Log("========> 두번째 저장");
            savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpenedToSave);
        }
        else
        {
            Debug.Log("=======> 두번째 로드");
            savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpenedToRead);
        } 
    }
    void OnSavedGameOpenedToSave(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            b.Serialize(m, TS.test);
            byte[] bytes = m.GetBuffer();
       
            Debug.Log("=====1=> : "+bytes.Length);

            //파일이 준비되었으므로, 실제 게임 저장을 수행.
            //저장할데이터바이트배열에 저장하실 바이트 배열을 지정합니다.
            SaveGame(game, bytes, DateTime.Now.TimeOfDay);
        }
        else
        {
            CloudText.text = "실패";
            //파일 열기에 실패
        }
    }
    void SaveGame(ISavedGameMetadata game, byte[] savedData, TimeSpan totalPlaytime)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

        SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();

        builder = builder
            .WithUpdatedPlayedTime(totalPlaytime)
            .WithUpdatedDescription("Saved game at " + DateTime.Now);

        SavedGameMetadataUpdate updateMetadata = builder.Build();
        savedGameClient.CommitUpdate(game, updateMetadata, savedData, OnSavedGameWritten);
    }
    void OnSavedGameWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            CloudText.text = "완료";
            //저장완료.
        }
        else
        {
            //저장실패.
            CloudText.text = "실패";
        }
    }

    public void LoadFromCloud()
    {
        if (Social.localUser.authenticated)
        {
            OpenSavedGame("SaveTest", false);
        }
    }
    void OnSavedGameOpenedToRead(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            Debug.Log("======로드 성공");
            CloudText.text = "성공";
            LoadGameData(game);
        }
        else
        {
            Debug.Log("======로드 실패");
            CloudText.text = "실패";
            //파일열기 실패 오류메세지.
        }
    }
    void LoadGameData(ISavedGameMetadata game)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.ReadBinaryData(game, OnSaveGameDataRead);
    }
    void OnSaveGameDataRead(SavedGameRequestStatus status, byte[] data)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            //데이터 읽기에 성공했습니다.
            //data 배열을 복구해서 적절하게 사용.
            Debug.Log("=====2=> : " + data.Length);
        }
        else
        {
            CloudText.text = "실패";
            //읽기 실패 했다. 오류출력.
        }
    }
    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }
    public void ShowAchievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }
    public void LoginGPGS()
    {
        if (!Social.localUser.authenticated)
            Social.localUser.Authenticate(LoginCallBackGPGS);
    }

    public void LoginCallBackGPGS(bool result)
    {
        bLogin = result;
    }

    public void LogoutGPGS()
    {
        if(Social.localUser.authenticated)
        {
            ((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
            bLogin = false;
        }
    }

    public Texture2D GetImageGPGS()
    {
        if (Social.localUser.authenticated)
            return Social.localUser.image;
        else
            return null;
    }
    
    public string GetNameGPGS()
    {
        if (Social.localUser.authenticated)
            return Social.localUser.userName;
        else
            return null;
    }
}
