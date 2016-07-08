using UnityEngine;
using System.Collections;

public class MapMake : MonoBehaviour {
	public GameObject editSetting;

	public Transform FindChild_inParent;
	public Transform FindChild_inChild;

	public GameObject Saving;
	public GameObject Save_Complate;


	float[] objPos_data;
	//float[] testSpeed;


	float[] _data;
	//float[] _datain;

	string _tmpStr;


	public void saveEditorBtn(){
		//_tmpStr = null
		_tmpStr = "";

		//find_Child
		Find_Child ();

		//objPos = [Transform.childCount]
		objPos_data = new float[FindChild_inParent.childCount*3];

		//_data = [Transform.childCount]
		_data = new float[FindChild_inParent.childCount];

		//objPos_data[i] = {num,pos.x,pos.y,...}
		obj_NumPos();


		for(int i = 0; i < objPos_data.Length; i++){
			
			_tmpStr = _tmpStr + objPos_data [i];
			//Debug.Log (i);
			if (i < objPos_data.Length -1) {
				_tmpStr = _tmpStr + ",";
			}
		}

		ES2.Save(_tmpStr,Application.dataPath + "/stage/S1_obj.txt");



	}


	public void AnimationBtn(){
		
		Find_Child ();
		obj_AniControll ();

	}



	void Find_Child(){
		FindChild_inParent = FindChild_inParent.GetComponentInChildren<Transform>();
		Debug.Log ("오브젝트 수 : " + FindChild_inParent.childCount);
	}

	void Find_Child_inChild(){
		FindChild_inChild = FindChild_inChild.GetComponentInChildren<Transform>();
	}

	void obj_NumPos(){
		int i = 0;
		foreach (Transform child in FindChild_inParent) {
			for (int j = 0; j < 3; j++) {
				
				switch (j) {
				case 0:
					objPos_data [i] = System.Convert.ToSingle (child.name.Substring (0, 4));
					break;
				case 1:
					objPos_data[i] = child.transform.position.x;
					break;
				case 2:
					objPos_data[i] = child.transform.position.y;
					break;
				}
				Debug.Log ("position : " + objPos_data[i]);
				i++;
			}

		}
	}

	void obj_AniControll(){
		if (editSetting.GetComponent<EditSetting> ().AnimationStop) {
			editSetting.GetComponent<EditSetting> ().AnimationStop = false;
			foreach (Transform child in FindChild_inParent) {

				child.GetComponent<Animator> ().enabled = false;
			}
		} else {
			editSetting.GetComponent<EditSetting> ().AnimationStop = true;
			foreach (Transform child in FindChild_inParent) {

				child.GetComponent<Animator> ().enabled = true;
			}
		}


	}



}
