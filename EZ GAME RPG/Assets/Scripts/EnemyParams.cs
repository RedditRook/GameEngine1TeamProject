using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyParams : CharacterParams
{
	public string name;
	public int hp;
	public int atk;
	public int def;
	public int dg;
	public int exp { get; set; }
	public int DropGold { get; set; }
	public Image hpbar;
	public override void InitParams()
	{
		maxHp = hp;
		curHp = maxHp;
		attack = atk;
		defense = def;
		DropGold = dg;

		exp = 50;
		
		isDead = false;
		initHPBarsize();
	}

	void initHPBarsize()
	{
		hpbar.rectTransform.localScale =new Vector3(1f, 1f, 1f);
	}

	protected override void UpdateAfterReceiveAttack()
	{
		base.UpdateAfterReceiveAttack();
		hpbar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
	}

}
