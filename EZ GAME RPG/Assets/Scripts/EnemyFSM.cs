using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
	public enum State
	{
		Idle,     //정지
		Chase,    //추적
		Attack,  // 공격
		Dead,   //사망
		NoState //아무
	}
	public int check;
	public State current_state = State.Idle;

	EnemyParams myParams;

	EnemyAni myAni;
	GoblinAni goani;
	SkeletonAni skeani;

	Transform player;

	PlayerParams playerParams;

	float chase_distance = 30f;  // 추적 시작 거리
	float attack_distance = 15f; // 공격 시작 범위
	float re_chase_distance = 14.5f; // 추적 시작 거리

	float rotAnglePerSec = 360f; //초당 회전 각도
	float moveSpeed = 25f;    //몬스터 이동속도

	float attackDelay = 2f;
	float attackTimer = 0f;


	public ParticleSystem hitEffects;
	void Start()
	{

		if (check == 0)
		{
			myAni = GetComponent<EnemyAni>();
		}
		if (check == 1)
		{
			goani = GetComponent<GoblinAni>();
		}
		if (check == 2)
		{
			skeani = GetComponent<SkeletonAni>();
		}

		myParams = GetComponent<EnemyParams>();
		myParams.deadEvent.AddListener(CallDeadEvent);

		if (check == 0)
		{
			ChangeState(State.Idle, EnemyAni.IDLE);
		}
		if (check == 1)
		{
			ChangeState(State.Idle, GoblinAni.IDLE);
		}
		if (check == 2)
		{
			ChangeState(State.Idle, SkeletonAni.IDLE);
		}
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerParams = player.gameObject.GetComponent<PlayerParams>();

		hitEffects.Stop();
	}


	public void AttackCal()
	{
		int attackpower = playerParams.GetAttack();
		myParams.SetEnemyAttack(attackpower);
	}

	void CallDeadEvent()
	{
		if (check == 0)
		{
			ChangeState(State.Dead, EnemyAni.DIE);
		}
		if (check == 1)
		{
			ChangeState(State.Dead, GoblinAni.DIE);
		}
		if (check == 2)
		{
			ChangeState(State.Dead, SkeletonAni.DIE);
		}
		player.gameObject.SendMessage("KILL");
	}
	public void ShowHitEffect()
	{
		hitEffects.Play();
	}
	void UpdateState()
	{
		switch (current_state)
		{
			case State.Idle:
				IdleState();
				break;
			case State.Chase:
				ChaseState();
				break;
			case State.Attack:
				AttackState();
				break;
			case State.Dead:
				DeadState();
				break;
			case State.NoState:
				NoState();
				break;
		}
	}

	public void ChangeState(State newstate, string aniname)
	{
		if (current_state == newstate)
		{
			return;
		}

		current_state = newstate;

		if (check == 0)
		{
			myAni.ChangeAni(aniname);
		}
		if (check == 1)
		{
			goani.ChangeAni(aniname);
		}
		if (check == 2)
		{
			skeani.ChangeAni(aniname);
		}
	}

	void IdleState()
	{
		if (GetDistanceFromPlayer() < chase_distance)
		{
			if (check == 0)
			{
				ChangeState(State.Chase, EnemyAni.WALK);
			}
			if (check == 1)
			{
				ChangeState(State.Chase, GoblinAni.WALK);
			}
			if (check == 2)
			{
				ChangeState(State.Chase, SkeletonAni.WALK);
			}
		}
	}

	void ChaseState()
	{
		if (GetDistanceFromPlayer() < attack_distance)
		{
			if (check == 0)
			{
				ChangeState(State.Attack, EnemyAni.ATTACK);
			}
			if (check == 1)
			{
				ChangeState(State.Attack, GoblinAni.ATTACK);
			}
			if (check == 2)
			{
				ChangeState(State.Attack, SkeletonAni.ATTACK);
			}
		}
		else
		{
			TurnToDestination();
			MoveToDestination();
		}
	}

	void AttackState()
	{
		if (GetDistanceFromPlayer() > re_chase_distance)
		{
			attackTimer = 0f;
			if (check == 0)
			{
				ChangeState(State.Chase, EnemyAni.WALK);
			}
			if (check == 1)
			{
				ChangeState(State.Chase, GoblinAni.WALK);
			}
			if (check == 2)
			{
				ChangeState(State.Chase, SkeletonAni.WALK);
			}
		}
		else
		{
			if (attackTimer > attackDelay)
			{
				transform.LookAt(player.position);
				if (check == 0)
				{
					myAni.ChangeAni(EnemyAni.ATTACK);
				}
				if (check == 1)
				{
					goani.ChangeAni(GoblinAni.ATTACK);
				}
				if (check == 2)
				{
					skeani.ChangeAni(SkeletonAni.ATTACK);
				}
				attackTimer = 0f;
			}
			attackTimer += Time.deltaTime;
		}
	}

	void DeadState()
	{
		GetComponent<BoxCollider>().enabled = false;
	}

	void NoState()
	{

	}

	void TurnToDestination()
	{
		Quaternion lookRotation = Quaternion.LookRotation(player.position - transform.position);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSec);
	}

	void MoveToDestination()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
	}

	float GetDistanceFromPlayer()
	{
		float distance = Vector3.Distance(transform.position, player.position);
		return distance;
	}

	void Update()
	{
		UpdateState();
	}
}