﻿using System.Collections;
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
			if (camtransform.position != transformToView.position) {
				routeLength = Vector3.Distance (camtransform.position, transformToView.position);

				float distToCover = (Time.time - startTime) / camspeed;
				float currentDistance = distToCover / routeLength;
				transform.position = Vector3.Lerp (camtransform.position, transformToView.position, currentDistance);
				transform.rotation = Quaternion.Lerp (camtransform.rotation, transformToView.rotation, currentDistance);

			}
		}
	}
		
}
