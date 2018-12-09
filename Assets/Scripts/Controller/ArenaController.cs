using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ArenaController : SceneController {
	
	// variables
	public List<PlayerSyncData> players;

	public Text playerOneText;	
	public Text playerOneScore;
	public Text playerTwoText;
	public Text playerTwoScore;

	// functions
	public override void StartScene () {
		players = new List<PlayerSyncData>();
		GameObject[] pl = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject p in pl) {
            players.Add(p.GetComponent<PlayerSyncData>());
        }
		if(players.Count >= 1) {
			playerOneText.text = players[0].data.playerName;
			playerOneScore.text = players[0].data.playerScore.ToString();
		} else {
			playerOneText.text = "Disconnected";
			playerOneScore.text = "0";
		}
		if(players.Count >= 2) {
			playerTwoText.text = players[1].data.playerName;
			playerTwoScore.text = players[1].data.playerScore.ToString();
		} else {
			playerTwoText.text = "Disconnected";
			playerTwoScore.text = "0";
		}
	}
	
	public override void UpdateScene () {
		if(players.Count <= 1) {
			UpdatePlayerName();
			UpdatePlayerInfo();
		}

		if(players.Count >= 2) {
			playerTwoText.text = players[1].data.playerName;
			playerTwoScore.text = players[1].data.playerScore.ToString();
			playerOneText.text = players[0].data.playerName;
			playerOneScore.text = players[0].data.playerScore.ToString();
		} else if(players.Count >= 1) {
			playerOneText.text = players[0].data.playerName;
			playerOneScore.text = players[0].data.playerScore.ToString();
		}
	}

	// network functions
	void OnConnectedToServer() {
		UpdatePlayerName();
	}

	void UpdatePlayerName() {
		foreach(PlayerSyncData p in players) {
			p.UpdateName();
		}
	}
    void UpdatePlayerInfo() {
        players.Clear();
        GameObject[] pl = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject p in pl) {
            players.Add(p.GetComponent<PlayerSyncData>());
        }
		if(players.Count >= 1) {
				playerOneText.text = players[0].data.playerName;
		} else {
			playerOneText.text = "Disconnected";
		}
		if(players.Count >= 2) {
			playerTwoText.text = players[1].data.playerName;
		} else {
			playerTwoText.text = "Disconnected";
		}
    }

	
}
