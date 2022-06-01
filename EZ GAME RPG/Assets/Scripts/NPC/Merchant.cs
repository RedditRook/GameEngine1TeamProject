using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		// TODO: NPC 시작 포지션 지정
		name = "아리엘";
	}

	// Update is called once per frame
	public override void Update()
	{
	}

	public override void ShowUI()
	{
		text.PrintName(name);
		text.PrintText("현재 판매중인 상품 목록입니다.");
		text.ShowBox();
	}

	public override void HideUI()
	{
		text.HideBox();
	}
}