using UnityEngine;
using System.Collections;

public class EditSetting : MonoBehaviour {
	public Transform FindChild_inParent;
	public Transform loadchild_Parent;
	public bool LoadManager;
	public GameObject loadManager_obj;
	public GameObject objs_obj;
	public bool AnimationStop;


	// Use this for initialization
	void Start () {
		
		obj_AniControll ();
		AnimationStop = true;
		if (!LoadManager) {
			loadManager_obj.SetActive (false);
			objs_obj.SetActive (true);
		} else {
			loadManager_obj.SetActive (true);
			objs_obj.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void obj_setting(){

	}

	void obj_AniControll(){
		
		foreach (Transform child in FindChild_inParent) {
			if (child.GetComponent<Animator> () != null) {
				Debug.Log (child.GetComponent<Animator> ());
				child.GetComponent<Animator> ().enabled = false;
			}
			}

	}
}
