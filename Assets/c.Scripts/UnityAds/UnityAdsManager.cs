using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour {

    Button unityAds;
    // Use this for initialization
    ShowOptions _ShowOpt = new ShowOptions();
    int _test = 0;

	void Start ()
    {
        unityAds = GameObject.Find("unityAds").GetComponent<Button>();
        unityAds.onClick.AddListener(unityAdsFunc);

        Advertisement.Initialize("124147", true); // true인이유는 테스트광고를 시청하겠다.
        _ShowOpt.resultCallback = OnAdsShowResultCallBack;
        UpdateButton();

    }
    void OnAdsShowResultCallBack(ShowResult result) //광고 보기후 호출되는 콜백함수. finished 다봤다는의미.
    {
        if (result == ShowResult.Finished)
            _test += 100;
    }

    void UpdateButton() //광고 준비가 되있다면 활성화.
    {
        unityAds.interactable = Advertisement.IsReady();
        unityAds.GetComponentInChildren<Text>().text = "보상형광고 테스트입니다! \r\nTest = " + _test.ToString();
    }


    void unityAdsFunc()
    {
        Advertisement.Show(null, _ShowOpt);
    }
}
