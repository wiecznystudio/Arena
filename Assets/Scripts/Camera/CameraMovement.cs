using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform destination; 
	public float smooth = 0.2f;

	void Start () {

	}
	
	
	void Update () {
		if(destination == null)
			return;

		Vector3 destPos = destination.position;
		destPos.z = transform.position.z;

		transform.position = Vector3.Lerp(transform.position, destPos, smooth);	
	}
}
