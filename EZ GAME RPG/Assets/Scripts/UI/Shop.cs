using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	private bool shop_opened;  // 인벤토리 열림 닫힘
	public bool OnOpened { get { return shop_opened; } }

	[SerializeField]
	private GameObject shop_image; // Inventory_Base 이미지
	[SerializeField]
	private GameObject slots_parent;    // Inventory Grid
	[SerializeField]
	private Inventory inventory;
	[SerializeField]
	private ShopSlot[] slots;  // 슬롯들 배열

	public Item for_test;

	void Start()
	{
		shop_opened = false;

		shop_image.SetActive(false);
	}

	void Update()
	{

	}

	public void TryOpenShop()
	{
		shop_opened = !shop_opened;

		if (shop_opened)
			shop_image.SetActive(true);
		else
			shop_image.SetActive(false);
	}
}
