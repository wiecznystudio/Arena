using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
	Idle, Move, Attack, Slide, Stand		
}
public enum AttackType {
	Weak, Strong
}


public class PlayerData : MonoBehaviour {

	// player character variables
	public Rigidbody2D body;
	public Vector2 horizontalMovement, verticalMovement;
	public Vector2 heading;

	public float moveSpeed;
	public float lastX, lastY;
	public string playerName = "player";
	public int playerScore = 0;

	public PlayerState state;
	public PlayerState animationState;
	public AttackType attackType;

	// eq and pets
	public PlayerEquipment equipment;

	public float playerDamage;
	public float playerDamageFactor;

	public float playerHealth;
	public float playerMaxHealth;

	public float armour;

	public float attackSpeed;
	public float attackTime;
	public float slideSpeed;
	public float slideTime;

	public int gold = 0;
	

	void Update() {
		if(attackTime > 0f) {
			attackTime -= Time.deltaTime;
		} else { //if(state != PlayerState.Attack) {
			state = PlayerState.Idle;
		}

		if(slideTime > 0f) {
			slideTime -= Time.deltaTime;
		} else {
			state = PlayerState.Idle;
		}

	}
}
