using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPath : MonoBehaviour {

	public float startWid = 0.5f;
	public float endWid = 0.5f;

	public Transform origin;
	private Transform destination;
	Transform[] pathTransforms;
	private LineRenderer lineRenderer;
	private float counter;
	private List<Transform> nodes;

	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.startWidth = startWid;
		lineRenderer.endWidth = endWid;
		nodes = new List<Transform> ();
		pathTransforms = GetComponentsInChildren<Transform> ();

		lineRenderer.numPositions = pathTransforms.Length - 2;
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


}
