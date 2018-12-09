using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour {

	Camera main;
	Vector3 startCam, startCloud, mouse, destCam, destCloud;
	public float smooth = 0.1f;

	public Transform clouds;

	void Start () {
		main = Camera.main;
		startCam = this.transform.position;
		startCloud = clouds.transform.localPosition;
	}
	
	void Update () {
		Vector3 mouse = main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = this.transform.position.z;

		destCam = startCam - mouse;
		transform.position = Vector3.Lerp(startCam, destCam, smooth);

		destCloud = startCloud + mouse;
		destCloud.z = startCloud.z;
		clouds.localPosition = Vector3.Lerp(startCloud, destCloud, smooth/8f);
	}
}
