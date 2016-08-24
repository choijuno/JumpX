using UnityEngine;
using System;
using System.Collections.Generic;
public class DataSave : MonoBehaviour {

    public static DataSave _instance;

    public void setMoney_Game(float game_Money)
    {
        ES2.Save<float>(ES2.Load<float>("Money_Game") + game_Money, "Money_Game");
    }
    public float getMoney_Game()
    {
        return ES2.Load<float>("Money_Game");
    }

    struct stageData
    {
        private float stageIndex;
        private float starCount;
        private float stageRecord;
        
        public stageData(float stageIndex, float starCount, float stageRecord)
        {
            this.stageIndex = stageIndex;
            this.starCount = starCount;
            this.stageRecord = stageRecord;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            DestroyImmediate(this.gameObject);
        }
    }
    public void saveData(float stageIndex, float starCount, float stageRecord)
    {
        Debug.Log("-------stageindex-----" + stageIndex);

        //stageData sd = new stageData(stageIndex, starCount, stageRecord);
        //ES2.Save(sd, "valueKeytest");

        string[] test = new string[3];
        test[0] = stageIndex.ToString();
        test[1] = starCount.ToString();
        test[2] = stageRecord.ToString();

        ES2.Save(test, "ValueKey" + stageIndex.ToString());


        if (ES2.Exists("stageCount"))
        {
            if (ES2.Load<float>("stageCount") < stageIndex)
            {
                ES2.Save(stageIndex, "stageCount");
            }
        }
        else
        {
            ES2.Save(stageIndex, "stageCount");
        }
    }
}
