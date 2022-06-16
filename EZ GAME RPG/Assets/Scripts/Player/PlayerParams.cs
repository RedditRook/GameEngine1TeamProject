using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : MonoBehaviour
{ 

	public float curHp;
	public float curMp;
	public int atk;
	public int def;
	public float MaxHp;
	public float MaxMp;
	public float curexp;
	public float expToLevelUp;
	public int money;
	public int level;
	public string name;
	public bool isDead;


	public bool skill1;
	public bool skill2;
	public bool skill3;
	public bool skill4;
	public SkillBar skillbar;
	private bool interacting_npc;
	public bool IsInteractingNPC { get; set; }

	void Start()
    {

    }
	public void InitParams()
	{
		name = "Unity";
		level = 1;
		MaxHp = 100;
		curHp = MaxHp;
		MaxMp = 100;
		curMp = MaxMp;
		atk = 20;
		def = 5;
		curexp = 0;
		expToLevelUp = 100 * level;
		money = 0;

		isDead = false;

		skill1 = false;
		skill2 = false;
		skill3 = false;
		skill4 = false;
	}

	public float GetHp()
    {
		return curHp;
    }

	public void SetHp(float Hp)
    {
		curHp = Hp;
    }

	void Update()
    {
		GetEXP(1);
	}


	void SkillUnlock()
	{
		if (level >= 2 && skill1 == false)
		{
			skill1 = true;
			skillbar.GetSkill(skillbar.for_test1);
		}
		if (level >= 4 && skill2 == false)
		{
			skill2 = true;
			skillbar.GetSkill(skillbar.for_test2);
		}
		if (level >= 7 && skill3 == false)
		{
			skill3 = true;
			skillbar.GetSkill(skillbar.for_test3);
		}
		if (level >= 10 && skill4 == false)
		{
			skill4 = true;
			skillbar.GetSkill(skillbar.for_test4);
		}
	}
	void LevelUp()
	{
		level++;
		//Debug.Log(level);
		curexp = 0.0f;
		skillbar.SetLevelText(level);
		Debug.Log(level);
		SkillUnlock();
	}

	void GetEXP(float expamount)
	{
		curexp += expamount;
		if (curexp >= expToLevelUp)
		{
			LevelUp();
		}
	}

}
