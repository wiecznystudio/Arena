using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
	Sword, Hammer, Spear
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class WeaponPattern : ItemPattern {

	// variables
	public WeaponType weaponType;

	public float damage;
	public float damageFactor;

	public float attackSpeed;

	public BoxCollider2D collider;

}
