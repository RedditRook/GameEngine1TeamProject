using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public bool skill1;
	public bool skill2;
	public bool skill3;
	public bool skill4;
	public SkillBar skillbar;
	private bool interacting_npc;
	public bool IsInteractingNPC { get; set; }

	// Start is called before the first frame update
	void Start()
	{
		max_hp = 100;
		max_mp = 100;

		hp = 50;
		mp = 100;

		exp = 0;
		maxexp = 100;

		level = 1;

		MaxHP = max_hp;
		MaxMP = max_mp;
		MaxEXP = maxexp;

		HP = hp;
		MP = mp;
		EXP = exp;
		Level = level;

		IsInteractingNPC = interacting_npc;

		//스킬 정보
		skill1 = false;
		skill2 = false;
		skill3 = false;
		skill4 = false;
	}

	// Update is called once per frame
	void Update()
	{
		GetEXP(1);
	}

	void SkillUnlock()
	{
		if (Level >= 2 && skill1 == false)
		{
			skill1 = true;
			skillbar.GetSkill(skillbar.for_test1);
		}
		if (Level >= 4 && skill2 == false)
		{
			skill2 = true;
			skillbar.GetSkill(skillbar.for_test2);
		}
		if (Level >= 7 && skill3 == false)
		{
			skill3 = true;
			skillbar.GetSkill(skillbar.for_test3);
		}
		if (Level >= 10 && skill4 == false)
		{
			skill4 = true;
			skillbar.GetSkill(skillbar.for_test4);
		}
	}

	void LevelUp()
	{
		Level++;
		EXP = 0.0f;
		skillbar.SetLevelText(Level);
		SkillUnlock();
	}

	void GetEXP(float expamount)
	{
		EXP += expamount;
		if(EXP >= maxexp)
		{
			LevelUp();
		}
	}
}