using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkController : NetworkManager {

	// singleton
	private static NetworkController instance;
	public static NetworkController Instance {
		get { return instance; }
	}

	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	
	}

	// game variables
	//public NetworkManager network;

	// buttons and slider handle
	public void SetupSingle() {
		networkAddress = "";
		networkPort = 0;
		onlineScene = "Harbor";
		StartHost();
	}

	public void SetupServer(string ip, int port) {
		networkAddress = ip;
		networkPort = port;

		onlineScene = "LanArena";
		StartHost();
		
	}

	public void ConnectToServer(string ip, int port) {
		NetworkManager.singleton.networkAddress = ip;
		NetworkManager.singleton.networkPort = port;

		NetworkManager.singleton.StartClient();
	}





}
