using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using GooglePlayGames.BasicApi;

public class GoogleManager : GoogleSingleton<GoogleManager> {
    
    public bool bLogin
    {
        get;
        set;
    }

    public void InitializeGPGS()
    {
        bLogin = false;
        PlayGamesPlatform.Activate();
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
