using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour {

	public SpriteRenderer renderer;
	public Rigidbody2D body;

	public PlayerData data;
	

	void Start() {
		renderer = GetComponent<SpriteRenderer>();	
		body = GetComponent<Rigidbody2D>(); 
	}

	void LateUpdate() {
		renderer.sortingOrder = -(int)(transform.position.y * 10) + 1000;
	}
}
