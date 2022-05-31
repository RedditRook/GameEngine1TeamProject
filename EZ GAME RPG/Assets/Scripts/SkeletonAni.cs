using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAni : MonoBehaviour
{
	public const string IDLE = "Idle2";
	public const string WALK = "Walk01";
	public const string ATTACK = "SwingNormal";
	public const string DIE = "Death";

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
