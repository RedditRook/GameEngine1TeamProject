using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParams : CharacterParams
{
	public string name;
	public int exp { get; set; }
	public int DropGold { get; set; }

	public override void InitParams()
	{
		name = "Spider";
		maxHp = 200;
		curHp = maxHp;
		attack = 50;
		defense = 5;
		DropGold = 20;

		exp = 50;

		isDead = false;
	}
	// Start is called before the first frame update

	protected override void UpdateAfterReceiveAttack()
	{
		base.UpdateAfterReceiveAttack();
	}

}
