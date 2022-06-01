using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterParams : MonoBehaviour
{
	public int maxHp { get; set; }
	public int maxMp { get; set; }
	public int curMp { get; set; }
	public int curHp { get; set; }
	public int attack { get; set; }
	public int defense { get; set; }

	public int level { get; set; }

	public bool isDead { get; set; }

	public int attackmin { get; set; }
	public int attackmax { get; set; }

	[System.NonSerialized]
	public UnityEvent deadEvent = new UnityEvent();

	// Start is called before the first frame update
	void Start()
	{
		InitParams();
	}

	public virtual void InitParams()
	{

	}

	public int GetAttack()
	{
		int at = attack;
		return at;
	}

	public int get_random_attack()
	{
		int randattack = Random.Range(attackmin, attackmax + 1);
		return randattack; 
	}

	public void SetEnemyAttack(int enemyAttackPower)
	{
		curHp -= enemyAttackPower;
		UpdateAfterReceiveAttack();
	}

	protected virtual void UpdateAfterReceiveAttack()
	{
		Debug.Log(name);
		print(name + "s HP:" + curHp);

		if (curHp <= 0)
		{
			curHp = 0;
			isDead = true;
			deadEvent.Invoke();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
