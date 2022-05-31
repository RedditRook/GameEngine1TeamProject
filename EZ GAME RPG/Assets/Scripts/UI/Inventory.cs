using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
	public static bool invectoryActivated = false;  // �κ��丮 ���� ����

	[SerializeField]
	private GameObject inventory_image; // Inventory_Base �̹���
	[SerializeField]
	private GameObject slots_parent;    // Inventory Grid

	private InventorySlot[] slots;  // ���Ե� �迭

	public Item for_test;

	void Start()
	{
		inventory_image.SetActive(false);
		slots = slots_parent.GetComponentsInChildren<InventorySlot>();
	}

	void Update()
	{
		TryOpenInventory();
		CheatGetLeather();
		CheatGetLeatherLow();
	}

	private void TryOpenInventory()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			invectoryActivated = !invectoryActivated;

			if (invectoryActivated)
				OpenInventory();
			else
				CloseInventory();
		}
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
							Debug.Log("�ټ� ����");
							return;
						}
						else
						{
							slots[i].SetSlotCount(_count);
							Debug.Log(slots[i].item_count);
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
					Debug.Log("�ټ� ����");
					return;
				}
				else
					slots[i].AddItem(_item, _count);
				return;
			}
		}
	}

	public void CheatGetLeather()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			GetItem(for_test, 1);
			Debug.Log("���� �߰�");
		}
	}
	public void CheatGetLeatherLow()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			GetItem(for_test, -1);
			Debug.Log("���� ����");
		}
	}
}