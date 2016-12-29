using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour {


	public float camspeed = 0.1f;

	public Transform transformToView;
	private Transform camtransform;
	private float startTime;
	private float routeLength,currentDistance;


	void Start () {
		startTime = Time.time;
		camtransform = transform;
	}

	void Update(){
		if (transformToView != null) {
			routeLength = Vector3.Distance (camtransform.position, transformToView.position);

			float distToCover = (Time.time - startTime) / camspeed;
			float currentDistance = distToCover / routeLength;

			if (camtransform.position != transformToView.position) {
				transform.position = Vector3.Lerp (camtransform.position, transformToView.position, currentDistance);
				transform.rotation = Quaternion.Lerp (camtransform.rotation, transformToView.rotation, currentDistance);
				Debug.Log ("Current Distance " + currentDistance);
			} else {
				Debug.Log ("Greater than 1 ");
			}
		}
	}
		
}
