using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public Text text;
	public Image icon;
	public Image border;
	public Image type;
	private ItemPattern item;

	public void SetCard(ItemPattern i) {
		item = i;
		text.text = item.itemName;
		icon.sprite = item.itemIcon;
		type.color = item.typeColor;
		border.color = item.rareColor;
	}


	public void MouseEnter() {
		((HarborGuiController)GameController.Instance.guiController).SetCardInfo(true, item, this.transform.position);
	}

	public void MouseExit() {
		((HarborGuiController)GameController.Instance.guiController).SetCardInfo(false, null, Vector2.zero);
	}

	public void Equip() {
		MouseExit();
		((HarborGuiController)GameController.Instance.guiController).player.data.equipment.Equip(item);
		((HarborGuiController)GameController.Instance.guiController).ReloadEquipment();
		((HarborGuiController)GameController.Instance.guiController).ReloadStats();
	}
}
