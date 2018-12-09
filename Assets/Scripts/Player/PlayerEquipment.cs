using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {

	public List<ItemPattern> inventory = new List<ItemPattern>();

	public WeaponPattern currentWeapon;
	public OutfitPattern currentOutfit;
	public ModifierPattern currentModifier;
	public AuraPattern currentAura;
	public PetPattern currentPet;

	public void Equip(ItemPattern item) {
		if(item is WeaponPattern)
			EquipWeapon((WeaponPattern)item);
		else if(item is OutfitPattern)
			EquipOutfit((OutfitPattern)item);
		else if(item is ModifierPattern)
			EquipModifier((ModifierPattern)item);
		else if(item is AuraPattern)
			EquipAura((AuraPattern)item);
		else if(item is PetPattern)
			EquipPet((PetPattern)item);
	}

	private void EquipWeapon(WeaponPattern weapon) {
		if(currentWeapon != null) inventory.Add(currentWeapon);
		currentWeapon = weapon;
		inventory.Remove(weapon);
	}
	
	public void EquipOutfit(OutfitPattern outfit) {
		if(currentOutfit != null) inventory.Add(currentOutfit);
		currentOutfit = outfit;
		inventory.Remove(outfit);
	}

	public void EquipModifier(ModifierPattern modifier) {
		if(currentModifier != null) inventory.Add(currentModifier);
		currentModifier = modifier;
		inventory.Remove(modifier);
	}

	public void EquipAura(AuraPattern aura) {
		if(currentAura != null) inventory.Add(currentAura);
		currentAura = aura;
		inventory.Remove(aura);
	}

	public void EquipPet(PetPattern pet) {
		if(currentPet != null) inventory.Add(currentPet);
		currentPet = pet;
		inventory.Remove(pet);
	}
	 


}
