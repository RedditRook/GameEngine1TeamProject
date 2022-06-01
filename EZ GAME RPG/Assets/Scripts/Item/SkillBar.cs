﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBar : MonoBehaviour
{
	public Player player;
	[SerializeField]
	private GameObject SkillBar_image; // Skill_Base 이미지
	[SerializeField]
	private GameObject slots_parent;    // Skill Grid
	private SkillSlot[] slots;

	public PlayerSkill for_test1;
	public PlayerSkill for_test2;
	public PlayerSkill for_test3;
	public PlayerSkill for_test4;


	void Start()
	{
		slots = slots_parent.GetComponentsInChildren<SkillSlot>();
	}

	void Update()
	{
		CheatGetSkill();

	}

	public void GetSkill(PlayerSkill _skill)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].skill == null)
			{
				slots[i].AddSkill(_skill);
				Debug.Log(i);
				return;
			}
		}
	}

	public void CheatGetSkill()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			GetSkill(for_test1);
			GetSkill(for_test2);
			GetSkill(for_test3);
			GetSkill(for_test4);
			Debug.Log("스킬 추가");
		}
	}
}
