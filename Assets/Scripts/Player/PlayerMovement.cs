using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	public Rigidbody2D body;
	public PlayerData data;

	void Start() {
		
	}

	public void UpdateMovement() {
		
		// movement input
		data.horizontalMovement = Vector3.right * Input.GetAxisRaw("Horizontal");
		data.verticalMovement = Vector3.up * Input.GetAxisRaw("Vertical");

		if(data.horizontalMovement != Vector2.zero || data.verticalMovement != Vector2.zero) {
			data.state = PlayerState.Move;
		} else {
			data.state = PlayerState.Idle;
		}

		if (this.isLocalPlayer) {
			// attack input
			if(Input.GetMouseButton(0)) {
				if((data.animationState == PlayerState.Idle || data.animationState == PlayerState.Move) && data.attackTime <= 0f) {
					data.state = PlayerState.Attack;
					data.attackType = AttackType.Weak;
					data.attackTime = data.attackSpeed;
					return;
				}
			} else if(Input.GetMouseButton(1)) {
				if((data.animationState == PlayerState.Idle || data.animationState == PlayerState.Move) && data.attackTime <= 0f) {
					data.state = PlayerState.Attack;
					data.attackType = AttackType.Strong;
					data.attackTime = data.attackSpeed * 1.5f;
					return;
				}
			}

			// slide position
			if(data.animationState == PlayerState.Slide)  {
				Vector2 dest = new Vector2(data.heading.x, data.heading.y) * data.slideSpeed * Time.deltaTime;
				body.position += dest;
				return;
			} else if(data.animationState == PlayerState.Stand)  {
				Vector2 dest = new Vector2(data.heading.x, data.heading.y) * (data.slideSpeed/2f) * Time.deltaTime;
				body.position += dest;
				return;
			}

			if(data.animationState == PlayerState.Move) {
				data.heading = Vector3.Normalize(data.verticalMovement + data.horizontalMovement);
				Vector2 dest = new Vector2(data.heading.x, data.heading.y) * data.moveSpeed * Time.deltaTime;
				body.position += dest;
			}

			// slide
			if(Input.GetKeyDown(KeyCode.LeftShift) && data.slideTime <= 0f && data.animationState == PlayerState.Move) {
				data.state = PlayerState.Slide;
				data.slideTime = 2f;
				return;
			}

			
		}

	}
}
