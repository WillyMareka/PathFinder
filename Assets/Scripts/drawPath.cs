using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPath : MonoBehaviour {

	public float startWid = 0.5f;
	public float endWid = 0.5f;


	public Transform destination;

	Transform[] pathTransforms;
	private LineRenderer lineRenderer;
	private float counter;
	private List<Transform> nodes;
	private GameObject camObj;
	private cameraManager CM;
	public bool canCamMove = false;

	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.startWidth = startWid;
		lineRenderer.endWidth = endWid;
		nodes = new List<Transform> ();
		pathTransforms = GetComponentsInChildren<Transform> ();

		lineRenderer.numPositions = pathTransforms.Length - 3;
	}
		

	void Update(){

		nodes = new List<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms [i] != transform) {
				if (pathTransforms [i].gameObject.tag == "pathnode") {
					nodes.Add (pathTransforms [i]);
				}
			}
		}

		for (int i = 0; i < nodes.Count; i++) {
			Vector3 currentNode = nodes [i].position;
			Vector3 previousNode = Vector3.zero;

			if (i > 0) {
				previousNode = nodes [i - 1].position;
			}

			lineRenderer.SetPosition (i, currentNode);
		}

	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			
			//if (destination != null && canCamMove == true) {
				camObj = GameObject.Find ("Main Camera");
				CM = camObj.GetComponent<cameraManager> ();
			//Debug.Log (destination.position);
				CM.ToSelected (destination);
			//}
		}

	}


}
