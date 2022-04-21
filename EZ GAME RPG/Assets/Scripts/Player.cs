using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// 플레이어의 최대 HP, MP
	private float max_hp;
	private float max_mp;

	// 플레이어의 현재 HP, MP
	private float hp;
	private float mp;

	public bool is_interacting;

	private void Awake()
	{
		hp = max_hp = 100;
		mp = max_mp = 100;
		is_interacting = false;
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		hp -= 0.01f;
		mp -= 0.01f;
	}

	public float MaxHP
	{
		get { return max_hp; }
	}
	public float MaxMP
	{
		get { return max_mp; }
	}
	public float HP
	{
		get { return hp; }
		set { hp = value; }
	}
	public float MP
	{
		get { return mp; }
		set { mp = value; }
	}
}
