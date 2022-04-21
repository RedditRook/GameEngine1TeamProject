using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : CharacterParams
{
	public string name { get; set; }
	public int curexp { get; set; }
	public int expToLevelUp { get; set; }
	public int money { get; set; }

	public override void InitParams()
	{
		name = "Unity";
		level = 10;
		maxHp = 100;
		curHp = maxHp;
		attack = 20;
		defense = 5;

		curexp = 0;
		expToLevelUp = 100 * level;
		money = 0;

		isDead = false;
	}

	protected override void UpdateAfterReceiveAttack()
	{
		base.UpdateAfterReceiveAttack();
	}


}
