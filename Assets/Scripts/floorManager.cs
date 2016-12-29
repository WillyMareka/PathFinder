using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floorManager : MonoBehaviour {

	public int floorNumber;
	public InputField inputSearch;
	private drawPath DP;

	private GameObject shelfsearch,greenglow;
	private GameObject[] disableShelfPaths;
	private LineRenderer myLine;
	private Transform selectedShelf;
	Animator anim;

	void Start () {
		RemoveRoute ();
	}

//	void Update(){
//		
//	}

	public void RemoveRoute(){
		disableShelfPaths = GameObject.FindGameObjectsWithTag ("parentnode");

		for (int i = 0; i < disableShelfPaths.Length; i++) {
			myLine = disableShelfPaths[i].GetComponent<LineRenderer> ();
			myLine.enabled = false;

			greenglow = disableShelfPaths [i].transform.GetChild (0).gameObject;
			anim = greenglow.GetComponent<Animator> ();
			anim.SetTrigger ("noglow");
		}
	}
		
	public void GetSearch(string searchname){
		
		if (searchname == "") {
			RemoveRoute ();
		}else{

			shelfsearch = GameObject.Find (searchname);
			if (shelfsearch != null) {
				if(shelfsearch.gameObject.CompareTag("parentnode")){
					DP = shelfsearch.GetComponent<drawPath> ();
					myLine = shelfsearch.GetComponent<LineRenderer> ();
					myLine.enabled = true;

					greenglow = shelfsearch.transform.GetChild(0).gameObject;
					selectedShelf = shelfsearch.transform.GetChild(1).transform;

					anim = greenglow.GetComponent<Animator> ();
					anim.SetTrigger ("glow");


					DP.destination = selectedShelf;
					DP.canCamMove = true;
				}
			} else {
				Debug.Log ("Product does not exist");
			}

		}
	}







}
