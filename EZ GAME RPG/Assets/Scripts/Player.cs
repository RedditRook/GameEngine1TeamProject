using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float max_hp;
	private float max_mp;

	private float hp;
	private float mp;

	private void Awake()
	{
		hp = max_hp = 100;
		mp = max_mp = 100;	
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
