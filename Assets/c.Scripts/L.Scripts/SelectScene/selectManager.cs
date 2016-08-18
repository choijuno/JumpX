using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class selectManager : MonoBehaviour {
    
    public GameObject ScrollPanel;
    public GameObject allBtnPanel;

    Button shopBtn;
    Button MyBtn;
    Button rangkingBtn;
    Button tropyBtn;
    Button setupBtn;
    
	void Start ()
    {
        selectInit();
    }
    void selectInit()
    {
        shopBtn = allBtnPanel.transform.FindChild("shopBtn").GetComponent<Button>();
        MyBtn = allBtnPanel.transform.FindChild("MyBtn").GetComponent<Button>();
        rangkingBtn = allBtnPanel.transform.FindChild("rangkingBtn").GetComponent<Button>();
        tropyBtn = allBtnPanel.transform.FindChild("tropyBtn").GetComponent<Button>();
        setupBtn = allBtnPanel.transform.FindChild("setupBtn").GetComponent<Button>();

        shopBtn.onClick.AddListener(shopBtnFunc);
        MyBtn.onClick.AddListener(MyBtnFunc);
        rangkingBtn.onClick.AddListener(rangkingBtnFunc);
        tropyBtn.onClick.AddListener(tropyBtnFunc);
        setupBtn.onClick.AddListener(setupBtnFunc);

        for (int i = 0; i < ScrollPanel.transform.childCount - 1; i++)
        {
            Button stageBtn = ScrollPanel.transform.GetChild(i + 1).gameObject.GetComponent<Button>();
            stageBtn.onClick.AddListener(() => SceneGo(stageBtn.name));
        }
    }
    void loadTest()
    {
        string[] test = new string[3]; 
        test  = ES2.LoadArray<string>("keyValue1");
        
        Debug.Log("======stageIndex====" + test[0]);
        Debug.Log("======starcount====" + test[1]);
        Debug.Log("======stagerecord====" + test[2]);
    }
    void SceneGo(string name) //게임씬으로 넘기자
    {
        GameManager.TestNum = System.Convert.ToInt32(name);
        SceneManager.LoadScene("TestGame");
    }
    void shopBtnFunc() //상점 버튼 눌렀을때.
    {

    }
    void MyBtnFunc() //인벤토리 버튼 눌렀을때.
    {

    }
    void rangkingBtnFunc() //랭킹 버튼 눌렀을때.
    {
        GoogleManager.GetInstance.ShowLeaderboard();
    }
    void tropyBtnFunc() //업적 버튼 눌렀을때.
    {
        GoogleManager.GetInstance.ShowAchievement();
    }
    void setupBtnFunc() //설정 버튼 눌렀을때.
    {
        loadTest();
    }
}
