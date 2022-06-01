using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnOwner : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		name = "라칸";
	}

	// Update is called once per frame
	public override void Update()
	{
	}

	public override void ShowUI()
	{
		text.PrintName(name);
		text.PrintText("저장하시겠습니까?");
		text.ShowBox();
	}

	public override void HideUI()
	{
		text.HideBox();
	}
}
