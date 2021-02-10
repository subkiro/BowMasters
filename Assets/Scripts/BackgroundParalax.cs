using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{
	Transform cam; // Camera reference (of its transform)
	Vector3 previousCamPos;

	public float length = 0f; 
	public float startPos = 0f;

	public float paralaxEffect = 1f; // Smoothing factor of parrallax effect
	
	void Start()
	{
		cam = Camera.main.transform;
		startPos = this.transform.position.x;

	}

	void Update()
	{
		float temp = cam.transform.position.x * (1 - paralaxEffect);
		float dist = cam.transform.position.x * ( paralaxEffect);

		transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
		if (temp > startPos - length) {
			startPos += length;
		} else if(temp<startPos-length){
			startPos -= length;
		}
	}
}
