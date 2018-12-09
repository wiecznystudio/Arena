using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {

	[Header("Item info")]
	public Text firstText;
	public Text secondText;
	public Text firstAmount;
	public Text secondAmount;
	[Header("Equipped info")]
	public Text firstTextEq;
	public Text secondTextEq;
	public Text firstAmountEq;
	public Text secondAmountEq;
	public Transform eqWindow;
		
	public void SetItemInfo(ItemPattern item, PlayerController player) {
		if(item is WeaponPattern) {
			// weapon data
			SetWeaponInfo((WeaponPattern)item, player);
		} else if(item is ModifierPattern) {
			// modifier data
			firstText.text = "Mod:";
			firstAmount.text = 0.ToString();
		} else if(item is OutfitPattern) {
			// outfit data
			firstText.text = "Armor:";
			firstAmount.text = 0.ToString();
		} else if(item is AuraPattern) {
			// aura data
			firstText.text = "Aura:";
			firstAmount.text = 0.ToString();
		} else if(item is PetPattern) {
			// pet data
			firstText.text = "Pet:";
			firstAmount.text = 0.ToString();
		} 
	}


	private void SetWeaponInfo(WeaponPattern item, PlayerController player) {
		firstTextEq.text = firstText.text = "Dps:";
		// item info
		float percent = (item.damage*(item.damageFactor/100f));
		float minDps = (item.damage - percent)/item.attackSpeed;
		float maxDps = (item.damage + percent)/item.attackSpeed;
		firstAmount.text = Mathf.Round(minDps).ToString() + " - " + Mathf.Round(maxDps).ToString();

		// equipped info
		if(player.data.equipment.currentWeapon != null) {
			eqWindow.gameObject.SetActive(true);
			percent = (player.data.equipment.currentWeapon.damage*(player.data.equipment.currentWeapon.damageFactor/100f));
			minDps = (player.data.equipment.currentWeapon.damage - percent)/player.data.equipment.currentWeapon.attackSpeed;
			maxDps = (player.data.equipment.currentWeapon.damage + percent)/player.data.equipment.currentWeapon.attackSpeed;
			firstAmountEq.text = Mathf.Round(minDps).ToString() + " - " + Mathf.Round(maxDps).ToString();
		} else eqWindow.gameObject.SetActive(false);
	}


}
