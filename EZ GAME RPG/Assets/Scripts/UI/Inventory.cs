using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
	static private bool inventoryActivated;  // 인벤토리 열림 닫힘
	public bool OnActivated { get { return inventoryActivated; } }

	[SerializeField]
	private GameObject inventory_image; // Inventory_Base 이미지
	[SerializeField]
	private GameObject slots_parent;    // Inventory Grid

	private InventorySlot[] slots;  // 슬롯들 배열

	public Item for_test;

	private int gold;		// 소지금
	public TextMeshProUGUI gold_text;

	void Start()
	{
		inventoryActivated = false;

		inventory_image.SetActive(false);
		slots = slots_parent.GetComponentsInChildren<InventorySlot>();
		
		gold = 0;
		gold_text.text = "Gold: " + gold.ToString();
	}

	void Update()
	{
		//TryOpenInventory();
		CheatGetLeather();
		CheatGetLeatherLow();
	}

	public void TryOpenInventory()
	{
		inventoryActivated = !inventoryActivated;

		if (inventoryActivated)
			OpenInventory();
		else
			CloseInventory();
	}

	private void OpenInventory()
	{
		inventory_image.SetActive(true);
	}

	private void CloseInventory()
	{
		inventory_image.SetActive(false);
	}

	public void GetItem(Item _item, int _count = 1)
	{
		if (Item.ITEMTYPE.equipment != _item.item_type)
		{
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item != null)
				{
					if (slots[i].item.name == _item.name)
					{
						if (slots[i].item_count <= 0 && _count < 0)
						{
							return;
						}
						else
						{
							slots[i].SetSlotCount(_count);
						}
						return;
					}
				}
			}
		}

		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].item == null)
			{
				if (_count < 0)
				{
					return;
				}
				else
					slots[i].AddItem(_item, _count);
				return;
			}
		}
	}

	public bool SpendGold(int _gold)
	{
		if (gold < _gold)
		{
			return false;
		}

		gold -= _gold;
		gold_text.text = "Gold: " + gold.ToString();

		return true;
	}
	
	public void GetMoney(int _gold)
	{
		gold += _gold;
		gold_text.text = "Gold: " + gold.ToString();
	}

	public void CheatGetLeather()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			GetItem(for_test, 1);
			GetMoney(100);
		}
	}
	public void CheatGetLeatherLow()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			GetItem(for_test, -1);
			SpendGold(100);
		}
	}
}