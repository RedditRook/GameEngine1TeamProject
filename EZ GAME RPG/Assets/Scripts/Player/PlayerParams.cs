using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : MonoBehaviour
{ 

	public float curHp;
	public int atk;
	public int def;
	public float MaxHp;
	public int curexp;
	public int expToLevelUp;
	public int money;
	public int level;
	public string name;
	public bool isDead;

	void Start()
    {

    }
	public void InitParams()
	{
		name = "Unity";
		level = 10;
		MaxHp = 100;
		curHp = MaxHp;
		atk = 20;
		def = 5;
		curexp = 0;
		expToLevelUp = 100 * level;
		money = 0;

		isDead = false;
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

    }

}
