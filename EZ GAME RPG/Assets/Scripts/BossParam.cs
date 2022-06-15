using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParams : CharacterParams
{
	public string name { get; set; }
	public int curexp { get; set; }
	public int expToLevelUp { get; set; }
	public int money { get; set; }

	public override void InitParams()
	{
		name = "BossMonster";
		level = 10;
		maxHp = 1000;
		curHp = maxHp;
		attack = 100;
		defense = 20;

		isDead = false;
	}

	protected override void UpdateAfterReceiveAttack()
	{
		base.UpdateAfterReceiveAttack();
	}
}
