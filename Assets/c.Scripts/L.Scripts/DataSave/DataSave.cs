using UnityEngine;
using System;
using System.Collections.Generic;

public class SaveData
{
    float stageIndex;
    float starCount;
    float stageRecord;

    public SaveData(float stageIndex, float starCount, float stageRecord)
    {
        this.stageIndex = stageIndex;
        this.starCount = starCount;
        this.stageRecord = stageRecord;
    }
    public void showData(ref float stageIndex, ref float starCount, ref float stageRecord)
    {
        this.stageIndex = stageIndex;
        this.starCount = starCount;
        this.stageRecord = stageRecord;
    }
}

public class DataSave : MonoBehaviour {

    public static DataSave Instance;
    private float gameMoney;
    private float cashMoney;
    public float CashMoney
    {
        get
        {
            return cashMoney;
        }
        set
        {
            cashMoney = value;
        }
    }
    public float GameMoney
    {
        get
        {
            return gameMoney; //es2로드
        }
        set
        {
            this.gameMoney = value; //es2세이브
        }
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
		DataSave.Instance.GameMoney = 123;
        Instance = this;
        DontDestroyOnLoad(this);
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
