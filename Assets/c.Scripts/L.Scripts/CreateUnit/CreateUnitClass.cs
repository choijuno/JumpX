using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateUnitClass : MonoBehaviour {

    public GameObject fireWorkParticle;
    public GameObject mude;
    public GameObject CreateOk;

    Button CreateOkBtn;

	void Start ()
    {
        mude.SetActive(false);
        CreateOk.SetActive(false);

        CreateOkBtn = CreateOk.GetComponent<Button>();
        CreateOkBtn.onClick.AddListener(createOkBtnFunc);
        StartCoroutine(waitFireWork());
	}
    IEnumerator waitFireWork()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(fireWorkParticle, new Vector3(-2f, 3.2f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        mude.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        CreateOk.SetActive(true);
    }
    void createOkBtnFunc()
    {
        SceneManager.LoadScene(2);
    }
}
