using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {

	// singleton
	private static ItemList instance = null;
	public static ItemList Instance {
		get  { return instance; }
	}

	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else if(instance != this) {
			Destroy(this.gameObject);
		}
	}

	// items

	public List<WeaponPattern> weapons;
	public OutfitPattern[] outfits;
	public ModifierPattern[] modifiers;
	public AuraPattern[] auras;
	public PetPattern[] pets;
}
