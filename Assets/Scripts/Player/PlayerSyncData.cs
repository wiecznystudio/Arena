using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSyncData : NetworkBehaviour {

	// variables
	public PlayerData data;
	
	[SyncVar] private PlayerState netState = PlayerState.Idle;
	[SyncVar] private AttackType netAttackType = AttackType.Weak;
	[SyncVar] private Vector2 netPosition = Vector2.zero;
	[SyncVar] private float netHealth = 100f;
	[SyncVar] private float netFlipSprite = 1f;
	[SyncVar] private float netMoveX = 0f;
	[SyncVar] private float netMoveY = 0f;
	[SyncVar] private float netLastX = 0f;
	[SyncVar] private float netLastY = 0f;
	[SyncVar] private string netPlayerName = "";
	[SyncVar] private int netPlayerScore = 0;

	// default unity functions

	void Update() {
		if(isLocalPlayer) {
			TransmitStates();
			TransmitPosition();
			TransmitFlip();
			TransmitAnimations();
			
		} else {	
			AnswerStates();
			AnswerPosition();
			AnswerFlip();
			AnswerAnimations();	
			
		}
		
		if(isServer) {
			TransmitScore();
			TransmitHealth();
		} else {
			AnswerScore();
			AnswerHealth();
		}
	}

	public void UpdateName() {
		if(isLocalPlayer) {
			TransmitName();
		} else {
			AnswerName();
		}
	}

	// network functions
	// states
	[Command]
	void CmdStatesToServer(PlayerState st, AttackType at) {
		netState = st;
		netAttackType = at;
	}
	[Client]
	public void TransmitStates() {
		CmdStatesToServer(data.state, data.attackType);
	}
	public void AnswerStates() {
		data.state = netState;
		data.attackType = netAttackType;
	}
	// position
	[Command]
	void CmdPositionToServer(Vector2 pos) {
		netPosition = pos;
	}
	[Client]
	public void TransmitPosition() {
		CmdPositionToServer(data.body.position);
	}
	public void AnswerPosition() {
		//player.body.position = netPosition;
		data.body.position = Vector2.Lerp(data.body.position, netPosition, Time.deltaTime);
	}
	// health
	[Command]
	void CmdHealthToServer(float h) {
		netHealth = h;
	}
	[Client]
	public void TransmitHealth() {
		CmdHealthToServer(data.playerHealth);
	}
	public void AnswerHealth() {
		data.playerHealth = netHealth;
	}
	// flip
	[Command]
	void CmdFlipToServer(float x) {
		netFlipSprite = x;
	}
	[Client]
	void TransmitFlip() {
		CmdFlipToServer(transform.localScale.x);
	}
	void AnswerFlip() {
		transform.localScale = new Vector3(netFlipSprite, 1f, 1f);
	}
	// moving
	[Command]
	void CmdAnimationsToServer(float mX, float mY, float lX, float lY) {
		netMoveX = mX;
		netMoveY = mY;
		netLastX = lX;
		netLastY = lY;
	}
	[Client]
	void TransmitAnimations() {
		CmdAnimationsToServer(data.heading.x, data.heading.y, data.lastX, data.lastY);
	}
	void AnswerAnimations() {
		data.heading.x = netMoveX;
		data.heading.y = netMoveY;
		data.lastX = netLastX;
		data.lastY = netLastY;
	}
	// name
	[Command]
	void CmdNameToServer(string name) {
		netPlayerName = data.playerName;
	}
	[Client]
	public void TransmitName() {
		CmdNameToServer(data.playerName);
	}
	public void AnswerName() {
		data.playerName = netPlayerName;
	}
	// score
	[ClientRpc]
	void RpcScoreToServer(int score) {
		netPlayerScore = score;
	}
	[Client]
	void TransmitScore() {
		RpcScoreToServer(data.playerScore);
	}
	void AnswerScore() {
		data.playerScore = netPlayerScore;
	}
}
