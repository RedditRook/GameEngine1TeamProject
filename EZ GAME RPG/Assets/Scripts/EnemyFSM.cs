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

	public State current_state = State.Idle;

	EnemyAni myAni;

	Transform player;

	float chase_distance = 35f;  // 추적 시작 거리
	float attack_distance = 10f; // 공격 시작 범위
	float re_chase_distance = 14.5f; // 추적 시작 거리

	float rotAnglePerSec = 360f; //초당 회전 각도
	float moveSpeed = 10f;    //몬스터 이동속도

	float attackDelay = 2f;
	float attackTimer = 0f;
	 void Start()
	{
		myAni = GetComponent<EnemyAni>();
		ChangeState(State.Idle, EnemyAni.IDLE);

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void UpdateState()
	{
		switch(current_state)
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

	public void ChangeState(State newstate,string aniname)
	{
		if(current_state == newstate)
		{
			return;
		}

		current_state = newstate;
		myAni.ChangeAni(aniname);
	}

	void IdleState()
	{
		if(GetDistanceFromPlayer()<chase_distance)
		{
			ChangeState(State.Chase, EnemyAni.WALK);
		}
	}

	void ChaseState()
	{
		if(GetDistanceFromPlayer()<attack_distance)
		{
			ChangeState(State.Attack, EnemyAni.ATTACK);
		}
		else
		{
			TurnToDestination();
			MoveToDestination();
		}
	}

	void AttackState()
	{
		if(GetDistanceFromPlayer()>re_chase_distance)
		{
			attackTimer = 0f;
			ChangeState(State.Chase, EnemyAni.WALK);
		}
		else
		{
			if(attackTimer >attackDelay)
			{
				transform.LookAt(player.position);
				myAni.ChangeAni(EnemyAni.ATTACK);

				attackTimer = 0f;
			}

			attackTimer += Time.deltaTime;
		}
	}

	void DeadState()
	{

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
