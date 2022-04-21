using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;  // ÀÎº¥Åä¸® ¿­¸² ´ÝÈû

    [SerializeField]
    private GameObject inventory_image; // Inventory_Base ÀÌ¹ÌÁö
    [SerializeField]
    private GameObject slots_parent;    // Inventory Grid

    private InventorySlot[] slots;  // ½½·Ôµé ¹è¿­

    public Item for_test;
    public Sprite for_test_image;
    public Item 
    void Start()
    {
        slots = slots_parent.GetComponentsInChildren<InventorySlot>();
        for_test.item_type = Item.ITEMTYPE.material;
        for_test.name = "°¡Á×";
        for_test.item_image = for_test_image;


   GameObject item_prefab;

}

    void Update()
    {
        TryOpenInventory();
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
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }

    public void CheatGetLeather()
    {
        Item CheatLeather;
        if (Input.GetKeyDown(KeyCode.L))
        {
            get
        }
    }
}