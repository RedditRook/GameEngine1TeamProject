using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public bool skill1;
	public bool skill2;
	public bool skill3;
	public bool skill4;

	private float max_hp;
	public float MaxHP { get; set; }

	private float max_mp;
	public float MaxMP { get; set; }

	private float hp;
	public float HP { get; set; }

	private float mp;
	public float MP { get; set; }

	private int level;
	public int Level { get; set; }

	private float exp;
	public float EXP { get; set; }

	private float maxexp;
	public float MaxEXP { get; set; }

	private bool interacting_npc;
	public bool IsInteractingNPC { get; set; }

	// Start is called before the first frame update
	void Start()
	{
		max_hp = 100;
		max_mp = 100;

		hp = 100;
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
	}

	void SkillUnlock()
	{
		if (level >= 2)
		{
			skill1 = true;
		}
		if (level >= 4)
		{
			skill2 = true;
		}
		if (level >= 7)
		{
			skill3 = true;
		}
		if (level >= 10)
		{
			skill4 = true;
		}
	}

	void LevelUp()
	{
		Level++;
		EXP = 0.0f;
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