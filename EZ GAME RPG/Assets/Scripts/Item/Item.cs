using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Make", menuName = "Make/Item")]
public class Item : ScriptableObject
{
	public enum ITEMTYPE
	{
		equipment,
		consumable,
		material,
	}

	public ITEMTYPE item_type;
	public string name;
	public Sprite item_image;
	public GameObject item_prefab;
	public Item forprice;
	public int price;
}