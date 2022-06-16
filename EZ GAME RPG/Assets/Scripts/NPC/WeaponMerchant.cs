using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMerchant : NPC
{
	private Shop shop;

	// Start is called before the first frame update
	public override void Start()
	{
		// TODO: NPC 시작 포지션 지정
		name = "러셀";
		shop = GameObject.Find("WeaponShopList").GetComponent<Shop>();
	}

	// Update is called once per frame
	public override void Update()
	{
	}

	public override void ShowUI()
	{
		text.PrintName(name);
		text.PrintText("러셀 무기상에 오신 것을 환영합니다.\n");
		text.PrintText("찾으시는 물건이 있으신가요?");
		shop.TryOpenShop();
		text.ShowBox();
	}

	public override void HideUI()
	{
		text.HideBox();
	}
}