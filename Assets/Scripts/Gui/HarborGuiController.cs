using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HarborGuiController : GuiController {

	public PlayerController player;

	public Transform cardsParent;
	public GameObject cardPrefab;
	public ItemInfo itemInfo;

	[Header("Stats")]
	public Text healthText;
	public Text dpsText;
	public Text armorText;
	public Text goldText;

	[Header("Equipped")]
	public Image currentWeapon;
	public Image currentModifier;
	public Image currentOutfit;
	public Image currentAura;
	public Image currentPet;
	
	void Start() {
		player = Transform.FindObjectOfType<PlayerController>();
	}

	public void ReloadStats() {
		// health text
		healthText.text = player.data.playerHealth + " / " + player.data.playerMaxHealth;
		
		// dps text
		float percent, minDps = 0, maxDps = 0;
		if(player.data.equipment.currentWeapon != null) {
			percent = (player.data.equipment.currentWeapon.damage*(player.data.equipment.currentWeapon.damageFactor/100f));
			minDps = (player.data.equipment.currentWeapon.damage - percent)/player.data.equipment.currentWeapon.attackSpeed;
			maxDps = (player.data.equipment.currentWeapon.damage + percent)/player.data.equipment.currentWeapon.attackSpeed;
		}
		dpsText.text = Mathf.Round(minDps).ToString() + " - " + Mathf.Round(maxDps).ToString();

		// armor text
		armorText.text = player.data.armour.ToString();

		// gold text
		goldText.text = player.data.gold.ToString();

	}
	
	public void ReloadEquipment() {
		// find player
		if(player == null) {
			player = Transform.FindObjectOfType<PlayerController>();
		}

		// reload current eq
		if(player.data.equipment.currentWeapon != null) {
			currentWeapon.sprite = player.data.equipment.currentWeapon.itemIcon;
			currentWeapon.color = new Color32(255, 255, 255, 255);
		} else currentWeapon.color = new Color32(255, 255, 255, 0);

		if(player.data.equipment.currentModifier != null) {
			currentModifier.sprite = player.data.equipment.currentModifier.itemIcon;
			currentModifier.color = new Color32(255, 255, 255, 255);
		} else currentModifier.color = new Color32(255, 255, 255, 0);

		if(player.data.equipment.currentOutfit != null) {
			currentOutfit.sprite = player.data.equipment.currentOutfit.itemIcon;
			currentOutfit.color = new Color32(255, 255, 255, 255);
		} else currentOutfit.color = new Color32(255, 255, 255, 0);

		if(player.data.equipment.currentAura != null) {
			currentAura.sprite = player.data.equipment.currentAura.itemIcon;
			currentAura.color = new Color32(255, 255, 255, 255);
		} else currentAura.color = new Color32(255, 255, 255, 0);

		if(player.data.equipment.currentPet != null) {
			currentPet.sprite = player.data.equipment.currentPet.itemIcon;
			currentPet.color = new Color32(255, 255, 255, 255);
		} else currentPet.color = new Color32(255, 255, 255, 0);

		// reload inventory
		for(int i = 0; i < cardsParent.childCount; i++) {
			GameObject.Destroy(cardsParent.GetChild(i).gameObject);
		}

		foreach(ItemPattern item in player.data.equipment.inventory) {
			GenerateCard(item);
		}
	}

	void GenerateCard(ItemPattern item) {
		GameObject newCard = GameObject.Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		newCard.transform.SetParent(cardsParent);
		newCard.GetComponent<Card>().SetCard(item);
	}


	public void SetCardInfo(bool active, ItemPattern item, Vector2 pos) {
		if(!active) {
			itemInfo.gameObject.SetActive(false);
			return;
		}

		itemInfo.gameObject.SetActive(true);
		itemInfo.transform.position = pos + new Vector2(102, -10);
		itemInfo.SetItemInfo(item, player);
	}
}
