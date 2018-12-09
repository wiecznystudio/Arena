using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// singleton
	private static GameController instance;
	public static GameController Instance {
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

	// variables
	public SceneController sceneController;
	public GuiController guiController;
	public PlayerController player;

	// functions

	void Start() {
		if(sceneController != null) sceneController.StartScene();
	}

	void Update() {
		if(sceneController != null) sceneController.UpdateScene();
	}

	public void SetGuiController(GuiController controller) {
		guiController = controller; 
	}

	public void SetSceneController(SceneController controller) {
		sceneController = controller; 
	}
	
}
