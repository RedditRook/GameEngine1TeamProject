using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinParams : CharacterParams
{
	public string name;
	public int exp { get; set; }
	public int DropGold { get; set; }
	public Image hpbar;
	public override void InitParams()
	{
		name = "Goblin";
		maxHp = 200;
		curHp = maxHp;
		attack = 50;
		defense = 5;
		DropGold = 20;

		exp = 50;

		isDead = false;
		initHPBarsize();
	}

	void initHPBarsize()
	{
		hpbar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
	}

	protected override void UpdateAfterReceiveAttack()
	{
		base.UpdateAfterReceiveAttack();
		hpbar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 5f, 1f);
	}
}
