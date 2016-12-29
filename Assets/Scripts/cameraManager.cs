using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour {


	public float camspeed = 3.0f;

	private Transform transformToView;
	private Transform camtransform;
	private float startTime;
	private float routeLength;


	void Start () {
		startTime = Time.time;
		camtransform = transform;
	}

	public void ToSelected(Transform transformToView){
		routeLength = Vector3.Distance (camtransform.position,transformToView.position);

		float distToCover = (Time.time - startTime) * camspeed;
		float currentDistance = distToCover / routeLength;

		transform.position = Vector3.Lerp (camtransform.position, transformToView.position, currentDistance);
		transform.rotation = Quaternion.Lerp (camtransform.rotation, transformToView.rotation, currentDistance);
	}
}
