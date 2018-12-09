using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

	Slider hpBar;
	public Slider attackBar;
	public PlayerData data;

	float attack, maxAttack;

	public void SetPlayer () {
	
		hpBar = GameObject.Find("HP_Bar").GetComponent<Slider>();
		SetAttack();
	}
	
	public void Update() {
		if(data.attackTime <= 0f) {
			if(attackBar.gameObject.active) {
				attackBar.gameObject.SetActive(false);
			}	
			return;
		}

		UpdateAttack();
	}
	
	public void UpdateHP (float hp) {
		hpBar.value = hp;
	}
	public void SetAttack() {
		attack = maxAttack = data.attackSpeed;
		attackBar.maxValue = maxAttack;
		attackBar.value = attack;
	}

	public void UpdateAttack() {
		if(!attackBar.gameObject.active) {
			attackBar.gameObject.SetActive(true);
		}	

		if(data.attackType == AttackType.Weak) {
			attackBar.maxValue = data.attackSpeed;
		} else {
			attackBar.maxValue = data.attackSpeed * 1.5f;
		}

		if(data.heading.x < 0f )  {
			attackBar.transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
		} else if(data.heading.x > 0f) {
			attackBar.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
		}

		attackBar.value = data.attackTime;
	}


}
