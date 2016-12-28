using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floorManager : MonoBehaviour {

	public int floorNumber;
	public InputField inputSearch;
	public GameObject goshelf;

	private GameObject shelfsearch,greenglow;
	private GameObject[] disableShelfPaths;
	private LineRenderer myLine;
	Animator anim;

	void Start () {
		RemoveRoute ();
	}
		
	public void GetSearch(string searchname){
		

		if (searchname == "") {
			RemoveRoute ();
		}else{

			shelfsearch = GameObject.Find (searchname);
			if (shelfsearch != null) {
				if(shelfsearch.gameObject.CompareTag("parentnode")){
					greenglow = shelfsearch.transform.GetChild(0).gameObject;

					anim = greenglow.GetComponent<Animator> ();
					myLine = shelfsearch.GetComponent<LineRenderer> ();
					myLine.enabled = true;
					anim.SetTrigger ("glow");
				}

			} else {
				Debug.Log ("Product does not exist");
			}

		}
	}


	private void RemoveRoute(){
		disableShelfPaths = GameObject.FindGameObjectsWithTag ("parentnode");

		for (int i = 0; i < disableShelfPaths.Length; i++) {
			myLine = disableShelfPaths[i].GetComponent<LineRenderer> ();
			myLine.enabled = false;

			greenglow = disableShelfPaths [i].transform.GetChild (0).gameObject;
			anim = greenglow.GetComponent<Animator> ();
			anim.SetTrigger ("noglow");
		}
	}
}
