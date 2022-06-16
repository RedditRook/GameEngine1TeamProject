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
	public Item for_test2;

	private int gold;		// 소지금
	public TextMeshProUGUI gold_text;

	public PlayerParams player;

	void Start()
	{
		inventoryActivated = false;

		inventory_image.SetActive(false);
		slots = slots_parent.GetComponentsInChildren<InventorySlot>();
		
		gold = 0;
		gold_text.text = "Gold: " + gold.ToString();

		player = GameObject.Find("Player").GetComponent<PlayerParams>();

	}

	void Update()
	{
		//TryOpenInventory();
		CheatGetLeather();
		CheatGetLeatherLow();
		UseItem();


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

	public bool GetItem(Item _item, int _count = 1)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].item != null)
			{
				if (slots[i].item.name == _item.name)
				{
					if (slots[i].item_count <= 0 && _count < 0)
					{
						return false;
					}
					else if (slots[i].item_count + _count < 0)
					{
						return false;
					}
					else
					{
						slots[i].SetSlotCount(_count);
						return true;
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
					return false;
				}
				else
				{
					slots[i].AddItem(_item, _count);
					return true;

				}
			}
		}
		return false;
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
	
	public bool GetGold(int _gold)
	{
		if(gold + _gold >= 0)
		{
			Debug.Log(gold + ", " + _gold);
			gold += _gold;
			gold_text.text = "Gold: " + gold.ToString();
			return true;
		}
		else
		{
			return false;
		}
	}

	public int SlotSize()
	{
		return slots.Length;
	}

	public bool IsFilled(int i)
	{
		return slots[i].item;
	}

	public bool HaveConsumableItem(int i, Item _item)
	{
		if (slots[i].item == _item && slots[i].item.item_type == Item.ITEMTYPE.consumable)
		{
			return true;
		}

		return false;
	}

	public void UseItem()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item != null)
				{
					if (slots[i].item.name == "HP 포션")
					{
						Debug.Log("있다");
						if (slots[i].item_count <= 0)
						{
							return;
						}
						else
						{
							GetItem(slots[i].item, -1);
							player.curHp += 50;
							if (player.curHp > player.MaxHp)
								player.curHp = player.MaxHp;
						}

					}
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item != null)
				{
					if (slots[i].item.name == "MP 포션")
					{
						if (slots[i].item_count <= 0)
						{
							return;
						}
						else
						{
							GetItem(slots[i].item, -1);
							player.curMp += 50;
							if (player.curMp > player.MaxMp)
								player.curMp = player.MaxMp;
						}

					}
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].item != null)
				{
					if (slots[i].item.name == "쿠키")
					{
						if (slots[i].item_count <= 0)
						{
							return;
						}
						else
						{
							GetItem(slots[i].item, -1);
							player.curHp += 30;
							player.curMp += 30;
							if (player.curHp > player.MaxHp)
								player.curHp = player.MaxHp;
							if (player.curMp > player.MaxMp)
								player.curMp = player.MaxMp;
						}

					}
				}
			}
		}
	}

	public void CheatGetLeather()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			GetItem(for_test, 5);
			GetItem(for_test2, 5);
			GetGold(500);
			player.GetEXP(player.expToLevelUp);
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