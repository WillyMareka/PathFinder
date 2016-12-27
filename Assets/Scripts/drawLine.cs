using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float counter;
	private float dist;

	public Transform origin;
	public Transform destination;

	public float startWid = 0.5f;
	public float endWid = 0.5f;

	public float lineDrawSpeed = 6f;


	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetPosition (0,origin.position);
		lineRenderer.startWidth = startWid;
		lineRenderer.endWidth = endWid;

		dist = Vector3.Distance (origin.position,destination.position);
	}

	void Update () {
		if (counter < dist) {
			counter += 0.1f / lineDrawSpeed;
			float x = Mathf.Lerp (0, dist, counter);

			Vector3 pointA = origin.position;
			Vector3 pointB = destination.position;

			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;

			lineRenderer.SetPosition (1, pointAlongLine);
		}
	}
}
