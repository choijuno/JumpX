using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class selectManager : MonoBehaviour {

    public GameObject ScrollPanel;
    
	void Start ()
    {
        selectInit();
    }
    void selectInit()
    {
        for (int i = 0; i < ScrollPanel.transform.childCount - 1; i++)
        {
            Button TestA = ScrollPanel.transform.GetChild(i + 1).gameObject.GetComponent<Button>();
            TestA.onClick.AddListener(() => SceneGo(TestA.name));
        }
    }
    void SceneGo(string name) //게임씬으로 넘기자
    {
        GameManager.TestNum = System.Convert.ToInt32(name);
        SceneManager.LoadScene("TestGame");
    }
}
