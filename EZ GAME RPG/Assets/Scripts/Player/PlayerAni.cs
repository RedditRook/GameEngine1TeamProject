using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
	// Start is called before the first frame update

	public const int ANI_IDLE = 0;
	public const int ANI_WALK = 1;
	public const int ANI_ATTACK = 2;
	public const int ANI_ATKIDLE = 3;
	public const int ANI_DEAD = 4;

	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}


	public void ChangeAni(int aniNumber)
	{
		anim.SetInteger("aniName", aniNumber);
	}


	// Update is called once per frame
	void Update()
	{

	}
}
