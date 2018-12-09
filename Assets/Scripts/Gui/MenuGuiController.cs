using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGuiController : GuiController {

	public NetworkController network;

	// variables
	public Animator anim;

	public InputField ip;
	public InputField port;

	private bool ipDirectActive = false;

	void Start() {
		ip.text = "";
		port.text = "";

		anim.Play("StartGame");
	}

	void Update () {
		
	}

	// buttons handle
	public void FastMatch() {
		string tempIp = "localhost";
		int tempPort = 7777;
		if(ip.text != "") {
			tempIp = ip.text;
		}
		if(port.text != "") {
			tempPort = System.Convert.ToInt32(port.text);
		}
		ipDirectActive = false;
			
		network.SetupServer(tempIp, tempPort);
	}
	public void EnterHarbor() {
		network.SetupSingle();
	}
	public void HostServer() {
		anim.Play("MainToMulti");
	}
	public void BrowseServers() {
		anim.Play("MainToMulti");
	}
	public void ExitGame() {
		Application.Quit();
	}

	public void HostServer1() {
		string tempIp = "localhost";
		int tempPort = 7777;
		if(ip.text != "") {
			tempIp = ip.text;
		}
		if(port.text != "") {
			tempPort = System.Convert.ToInt32(port.text);
		}
		ipDirectActive = false;

		network.SetupServer(tempIp, tempPort);
	}
	public void IpDirect() {
		if(!ipDirectActive) {
			anim.Play("MultiToDirect");
			ipDirectActive = true;
		} else {
			anim.Play("DirectToMulti");
			ipDirectActive = false;
		}
	}
	public void GoBackToMain() {
		anim.Play("MultiToMain");
		ipDirectActive = false;
	}

	public void DirectConnect() {
		string tempIp = "localhost";
		int tempPort = 7777;
		if(ip.text != "") {
			tempIp = ip.text;
		}
		if(port.text != "") {
			tempPort = System.Convert.ToInt32(port.text);
		}
		ipDirectActive = false;

		network.ConnectToServer(tempIp, tempPort);
	}

}
