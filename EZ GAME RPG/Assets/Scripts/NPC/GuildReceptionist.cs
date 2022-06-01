using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildReceptionist : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		name = "러셀";
	}

	// Update is called once per frame
	public override void Update()
	{
	}

	public override void ShowUI()
	{
		text.PrintName(name);
		text.PrintText("퀘스트 의뢰 목록입니다.");
		text.ShowBox();
	}

	public override void HideUI()
	{
		text.HideBox();
	}
}
