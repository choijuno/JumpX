using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class selectManager : MonoBehaviour {
    
    public GameObject ScrollPanel;
    public GameObject allBtnPanel;
    public GameObject ui_back_large;


    public Sprite clearSprite;
    public Sprite noneSprite; //자물쇠 이미지
    public Sprite newSprite; //새로열린 이미지
    public Sprite storeBtnClick;
    public Sprite myRoomBtnClick;
    public Sprite noneStoreBtn;
    public Sprite noneMyRoomBtn;

    public Canvas UiCanvas;
    public Canvas fadingCanvas;
    CanvasGroup canvasGroup;
    bool fadeOut;

    Button shopBtn;
    Button MyBtn;
    Button rangkingBtn;
    Button tropyBtn;
    Button setupBtn;

    Button myRoomBtn;
    Button storeBtn;
    //상점
    GameObject storeAndRoom;
    GameObject myRoom;
    GameObject store;
    Button storeRoomExit;

    EventSystem eventSystem;

    Text gameMoney;

	void Start ()
    {
        selectInit();
    }
    void selectInit()
    {
        fadingCanvas.gameObject.SetActive(false);
        gameMoney = GameObject.Find("gameMoney").GetComponent<Text>();

        if(ES2.Exists("Money_Game"))
            gameMoney.text = DataSave._instance.getMoney_Game().ToString(); //돈 출력

        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.pixelDragThreshold = (int)(0.5f * Screen.dpi / 2.54f);

        canvasGroup = UiCanvas.GetComponent<CanvasGroup>();

        fadeOut = true;
        shopBtn = allBtnPanel.transform.FindChild("shopBtn").GetComponent<Button>();
        MyBtn = allBtnPanel.transform.FindChild("MyBtn").GetComponent<Button>();
        rangkingBtn = allBtnPanel.transform.FindChild("rangkingBtn").GetComponent<Button>();
        tropyBtn = allBtnPanel.transform.FindChild("tropyBtn").GetComponent<Button>();
        setupBtn = allBtnPanel.transform.FindChild("setupBtn").GetComponent<Button>();

        storeAndRoom = UiCanvas.gameObject.transform.FindChild("StoreAndRoom").gameObject;
        ui_back_large = storeAndRoom.gameObject.transform.FindChild("ui_back_large").gameObject;
        storeAndRoom.SetActive(false);
        myRoom = ui_back_large.transform.FindChild("MyRoom").gameObject;
        store = ui_back_large.transform.FindChild("Store").gameObject;

        storeRoomExit = ui_back_large.transform.FindChild("StoreRoomExit").GetComponent<Button>();
        storeRoomExit.onClick.AddListener(storeRoomExitFunc);

        myRoomBtn = ui_back_large.transform.FindChild("myRoomBtn").GetComponent<Button>();
        myRoomBtn.onClick.AddListener(MyBtnFunc);
        storeBtn = ui_back_large.transform.FindChild("storeBtn").GetComponent<Button>();
        storeBtn.onClick.AddListener(shopBtnFunc);

        shopBtn.onClick.AddListener(shopBtnFunc);
        MyBtn.onClick.AddListener(MyBtnFunc);
        rangkingBtn.onClick.AddListener(rangkingBtnFunc);
        tropyBtn.onClick.AddListener(tropyBtnFunc);
        setupBtn.onClick.AddListener(setupBtnFunc);
		if (!ES2.Exists("stageCount"))
			ES2.Save(0,"stageCount");
		
		if (ES2.Exists ("stageCount")) {
			for (int i = 0; i < ScrollPanel.transform.childCount - 1; i++) {
				Button stageBtn = ScrollPanel.transform.GetChild (i + 1).gameObject.GetComponent<Button> (); //버튼들
				Image stageImg = stageBtn.GetComponent<Image> ();
				Text stageText = stageBtn.transform.GetChild (3).GetComponent<Text> ();


				if (i > ES2.Load<float> ("stageCount")) {
					stageText.text = "";
					stageImg.sprite = noneSprite;
					stageBtn.interactable = false;
				} else {
					stageText.text = (i + 1).ToString ();
					if (i == ES2.Load<float> ("stageCount"))
						stageImg.sprite = newSprite;
					else
						stageImg.sprite = clearSprite;

					stageBtn.interactable = true;
				}
               

				for (int j = 0; j < 3; j++) {
					stageBtn.transform.GetChild (j).gameObject.SetActive (false);
				}
				stageBtn.onClick.AddListener (() => SceneGo (stageBtn.name));
			}
		}

        loadStar(); //별 로드
        loadNoneStage();
    }
    IEnumerator FadeOut()
    {
        fadingCanvas.gameObject.SetActive(true);
        while (fadeOut)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            if (canvasGroup.alpha <= 0)
                fadeOut = false;
            yield return null;
        }
        canvasGroup.interactable = false;
        SceneManager.LoadScene(3);
        yield return null;
    }

    void loadStar()
    {
        string[] test = new string[3];
        GameObject[] star = new GameObject[3];
        Button stageBtn;
        if (ES2.Exists("stageCount"))
        {
            for (int i = 0; i < ES2.Load<float>("stageCount"); i++)
            {
                test = ES2.LoadArray<string>("ValueKey" + (i + 1));
                stageBtn = ScrollPanel.transform.GetChild(i + 1).gameObject.GetComponent<Button>();
                for (int j = 0; j < test.Length; j++)
                {
                    float[] stage = new float[3];
                    stage[j] = float.Parse(test[j]);

                    for (int k = 0; k < stage[1]; k++)
                    {
                        star[k] = stageBtn.transform.GetChild(k).gameObject;
                        star[k].SetActive(true);
                    }
                }
            }
        }
    }
    void loadNoneStage()
    {

    }
    void SceneGo(string name) //게임씬으로 넘기자
    {
        GameManager.TestNum = System.Convert.ToInt32(name);
        StartCoroutine(FadeOut());
    }
    void shopBtnFunc() //상점 버튼 눌렀을때.
    {
        storeBtn.GetComponent<Image>().sprite = storeBtnClick;
        storeBtn.GetComponent<Image>().SetNativeSize();
        myRoomBtn.GetComponent<Image>().sprite = noneMyRoomBtn;
        myRoomBtn.GetComponent<Image>().SetNativeSize();
        storeAndRoom.SetActive(true);
        store.SetActive(true);
        myRoom.SetActive(false);
    }
    void MyBtnFunc() //인벤토리 버튼 눌렀을때.
    {
        myRoomBtn.GetComponent<Image>().sprite = myRoomBtnClick;
        myRoomBtn.GetComponent<Image>().SetNativeSize();
        storeBtn.GetComponent<Image>().sprite = noneStoreBtn;
        storeBtn.GetComponent<Image>().SetNativeSize();
        storeAndRoom.SetActive(true);
        store.SetActive(false);
        myRoom.SetActive(true);
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
        
    }
    void storeRoomExitFunc() //상점 닫기
    {
        storeAndRoom.SetActive(false);
    }
}
