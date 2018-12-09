using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarborController : SceneController {

	// variables
	public bool menuOpen = false;

	public GameObject eqWindow;
	public HarborGuiController guiController;

	void Start() {
		GameController.Instance.SetGuiController(guiController);
		GameController.Instance.SetSceneController(this);
	}

	public override void StartScene() {

	}
	
	public override void UpdateScene () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(menuOpen) {				
				eqWindow.SetActive(false);
				menuOpen = false;
				guiController.player.controllable = true;
			} else {
				eqWindow.SetActive(true);
				guiController.ReloadEquipment();
				guiController.ReloadStats();
				menuOpen = true;
				guiController.player.controllable = false;
			}
		}	
	}

}
