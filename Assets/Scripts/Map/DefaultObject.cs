using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultObject : MonoBehaviour {

	void Start() {
		GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 10) + 1000;
	}
}
