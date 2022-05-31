using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAni : MonoBehaviour
{
	public const string IDLE = "Monster_anim|Idle_1";
	public const string WALK = "Monster_anim|Walk";
	public const string ATTACK = "Monster_anim|Atack";
	public const string DIE = "Monster_anim|Death";

	Animation anim;
	void Start()
	{
		anim = GetComponentInChildren<Animation>();
	}

	public void ChangeAni(string aniname)
	{
		anim.CrossFade(aniname);
	}

	void Update()
	{

	}
}
