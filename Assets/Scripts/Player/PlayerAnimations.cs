using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

	public Animator anim;
	public AnimatorClipInfo animInfo;
	public PlayerData data;
	string currentClip;
	
	void Start() {
		anim = GetComponent<Animator>();
	}

	public void UpdateAnimations() {

		//GetAnimationsData();
		FlipSprite();

		// attacking animation	
		if(data.state == PlayerState.Attack && data.animationState != PlayerState.Attack) {
			Attack();
			return;
		} else if(data.animationState != PlayerState.Attack || data.state != PlayerState.Attack) {
			anim.SetBool("isAttacking", false); 
		}
		
		if(data.state == PlayerState.Slide && data.animationState != PlayerState.Slide) {
			anim.SetBool("isSliding", true);
			return;
		} else if(data.animationState != PlayerState.Slide || data.state != PlayerState.Slide) {
			anim.SetBool("isSliding", false); 
		}

		// moving and idle animations
		if(data.state == PlayerState.Idle) {
			//if(data.heading.x == 0f && data.heading.y == 0) {
			anim.SetFloat("LastMoveX", data.lastX);
			anim.SetFloat("LastMoveY", data.lastY);
			anim.SetBool("isMoving", false);
		} else if(data.state == PlayerState.Move) {
			data.lastX = data.heading.x;
			data.lastY = data.heading.y;
			anim.SetBool("isMoving", true);
		}

		anim.SetFloat("MoveX", data.heading.x);
		anim.SetFloat("MoveY", data.heading.y);


	}

	public void GetAnimationsData() {
		// get animations data
		animInfo = anim.GetCurrentAnimatorClipInfo(0)[0];
		currentClip = animInfo.clip.name;

		if(currentClip == "attack1" || currentClip == "attack2" || currentClip == "attack3") {
			data.animationState = PlayerState.Attack;
		} else if(currentClip == "slide") {
			data.animationState = PlayerState.Slide;
		} else if(currentClip == "stand") {
			data.animationState = PlayerState.Stand;
		} else if(currentClip == "move") {
			data.animationState = PlayerState.Move;
		} else if(currentClip == "idle") {
			data.animationState = PlayerState.Idle;
		} 
	}

	private void FlipSprite() {
		// flip sprite 
		if(data.heading.x < 0f )  {
			transform.localScale = new Vector3(-1f, 1f, 1f);
		} else if(data.heading.x > 0f) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}


	void Attack() {
		anim.SetBool("isAttacking", true);
		if(data.attackType == AttackType.Weak) {
			anim.SetTrigger("attack1");
		} else {
			anim.SetTrigger("attack2");
		}
	}

}
