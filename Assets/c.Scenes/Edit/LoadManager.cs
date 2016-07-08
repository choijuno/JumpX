using UnityEngine;
using System.Collections;

public class LoadManager : MonoBehaviour {
	public Transform loadParent;

	public GameObject StartPos;
	public GameObject ground;
	public GameObject ground_2;
	public GameObject breakground;
	public GameObject fish;
	public GameObject crocodile;
	public GameObject Cage;

	GameObject _tmp;

	string[] objPos_dataArr;
	float[] objPos_dataIn;

	// Use this for initialization
	void Start () {
		//load

		string[] objPos_dataArr = ES2.Load<string> (Application.dataPath + "/stage/S1_obj.txt").Split(',');

		objPos_dataIn = new float[objPos_dataArr.Length];

		for (int j = 0; j < objPos_dataArr.Length; j++) {
			objPos_dataIn [j] = System.Convert.ToSingle(objPos_dataArr [j]);
		}

		for (int i = 0; i < objPos_dataArr.Length; i+=3) {
			Debug.Log ("!!!!");
			switch (""+objPos_dataIn[i]) {
			case "9999":
				_tmp = Instantiate (StartPos, new Vector3 (objPos_dataIn [i + 1], objPos_dataIn [i + 2], 0), Quaternion.identity) as GameObject;
				break;
			case "1000":
				_tmp = Instantiate(ground, new Vector3(objPos_dataIn[i+1],objPos_dataIn[i+2],0), Quaternion.identity) as GameObject;
				break;
			case "1001":
				_tmp = Instantiate(ground_2, new Vector3(objPos_dataIn[i+1],objPos_dataIn[i+2],0), Quaternion.identity) as GameObject;
				break;
			case "1010":
				_tmp = Instantiate(breakground, new Vector3(objPos_dataIn[i+1],objPos_dataIn[i+2],0), Quaternion.identity) as GameObject;
				break;
			case "2000":
				_tmp = Instantiate(fish, new Vector3(objPos_dataIn[i+1],objPos_dataIn[i+2],0), Quaternion.identity) as GameObject;
				break;
			case "2010":
				_tmp = Instantiate(crocodile, new Vector3(objPos_dataIn[i+1],objPos_dataIn[i+2],0), Quaternion.identity) as GameObject;
				break;
			case "5000":
				_tmp = Instantiate(Cage, new Vector3(objPos_dataIn[i+1],objPos_dataIn[i+2],0), Quaternion.identity) as GameObject;
				break;
			}
		}
		/*

		*/


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
