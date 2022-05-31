using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public bool skill1;
	public bool skill2;
	public bool skill3;
	public bool skill4;

	private float maxhp;
    public float MaxHP
    {
        get
        {
            return maxhp;
        }
    }

    private float maxmp;
    public float MaxMP
    {
        get
        {
            return maxmp;
        }
    }

    private float hp;
    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    private float mp;
    public float MP
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
        }
    }

	private int level;
	public int Level
	{
		get
		{
			return level;
		}
		set
		{
			level = value;
		}
	}

	private int exp;
	public int EXP
	{
		get
		{
			return exp;
		}
		set
		{
			exp = value;
		}
	}

	private int maxexp;
	public int MaxEXP
	{
		get
		{
			return maxexp;
		}
		set
		{
			maxexp = value;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        maxhp = 100;
        hp = 100;
        maxmp = 100;
        mp = 100;
		level = 1;

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
}
