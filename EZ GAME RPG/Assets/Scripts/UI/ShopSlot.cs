using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour       //인벤토리 슬롯에 
{
	public Item item;               //아이템 객체
	public TextMeshProUGUI name;    //아이템 이름
	public TextMeshProUGUI price;   //아이템 가격
	private int int_price;          //아이템 가격(int)
	public Image item_image;        //아이템 이미지

	private Inventory _inventory;
	public Inventory inventory
	{
		set { _inventory = value; }
	}

	private void Start()
	{
		name.text = item.name;
		item_image.sprite = item.item_image;
		int.TryParse(item.price.ToString(), out int_price);
	}

	private void SetColor(float _alpha)     //아이템 투명도 조절(삭제시 알파0, 생성시 알파1)
	{
		Color color = item_image.color;
		color.a = _alpha;
		item_image.color = color;
	}

	public void Sell()
	{
		for (int i = 0; i < _inventory.SlotSize(); i++)
		{
			if (_inventory.HaveConsumableItem(i, item) || _inventory.IsFilled(i) == false)
			{
				if (_inventory.SpendGold(int_price))
				{
					_inventory.GetItem(item, 1);
				}

				break;
			}
		}
	}

	public void Buy()
	{
		_inventory.GetItem(item, -1);
		_inventory.GetGold(int_price);
	}
}