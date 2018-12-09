using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	// variables
	public PlayerMovement movementHandle;
	public PlayerRenderer rendererHandle;
	public PlayerAnimations animHandle;	
	public PlayerHUD hudHandle;
	public PlayerData data;

	public AttackCollide attackCollide;

	private NetworkStartPosition[] spawnPoints;

	public bool controllable = true;


	// unity default functions
	void Start () {
		movementHandle.data = data;
		rendererHandle.data = data;
		animHandle.data = data;
		hudHandle.data = data;
		
		attackCollide = GetComponentInChildren<AttackCollide>();
			
		if (this.isLocalPlayer) {
			spawnPoints	= FindObjectsOfType<NetworkStartPosition>();
			Camera.main.gameObject.GetComponent<CameraMovement>().destination = this.transform;
			hudHandle.SetPlayer();
		}
	}
	
	void Update () {
		animHandle.GetAnimationsData();	
		if(controllable) movementHandle.UpdateMovement();
		animHandle.UpdateAnimations();

		//if(hudHandle.attackBar.gameObject.active) {
			///hudHandle.UpdateHud();
		 	//hudHandle.SetAttack(data.attackTime);
		//}

	}

	


	public void ReceiveDamage(PlayerController player) {
		if(!isServer)
			return;

		float damage = player.data.playerDamage + Random.Range(-player.data.playerDamage * player.data.playerDamageFactor, player.data.playerDamage * player.data.playerDamageFactor);
		data.playerHealth -= damage;

		if(data.playerHealth <= 0f) {
			data.playerHealth = data.playerMaxHealth;
			player.data.playerScore++;
			RpcRespawn();
		}
	}

	// reset position
	[ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;

            if (spawnPoints != null && spawnPoints.Length > 0) {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            rendererHandle.body.position = spawnPoint;
        }
    }

	// animations funcions
	void EndAttack() {
		//data.attack = false;
	}
	void EndSlide() {
		//data.slide = false;
	}

}
