using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPattern : ScriptableObject {

	// variables
	
	public string itemName;
	public int itemID;
	public Sprite itemIcon;
	public Animator itemAnimator;
	public int rareChance;
	public Color rareColor = new Color32(185, 128, 80, 255);
	public Color typeColor;

	
}
