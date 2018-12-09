using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AttackCollide : MonoBehaviour {

	public PlayerController thisPlayer;


	private void OnTriggerEnter2D(Collider2D col) {
		
		if(col.gameObject.tag == "Player" && col.gameObject != thisPlayer.gameObject) {
			col.GetComponent<PlayerController>().ReceiveDamage(thisPlayer);
		}	
	}
}
