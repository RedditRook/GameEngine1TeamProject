using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
	public PlayerParams player;
	public Image weapon_image;    //아이템 이미지
	public Image armor_image;    //아이템 이미지

	public Item weapontier1;
	public Item weapontier2;
	public Item weapontier3;
	public Item armortier1;
	public Item armortier2;
	public Item armortier3;

	private void Update()
	{
		Debug.Log(player.weapontier + ", " + player.armortier);
		change();
	}

	public void change()
	{
		if (player.weapontier == 1)
		{
			weapon_image.sprite = weapontier1.item_image;
		}
		if (player.weapontier == 2)
		{
			weapon_image.sprite = weapontier2.item_image;
		}
		if (player.weapontier == 3)
		{
			weapon_image.sprite = weapontier3.item_image;
		}
		if (player.armortier == 1)
		{
			armor_image.sprite = armortier1.item_image;
		}
		if (player.armortier == 2)
		{
			armor_image.sprite = armortier2.item_image;
		}
		if (player.armortier == 3)
		{
			armor_image.sprite = armortier3.item_image;
		}
	}
}
