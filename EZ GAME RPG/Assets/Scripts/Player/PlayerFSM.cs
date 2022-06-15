﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
	[SerializeField]
	Transform playerInputSpace = default;

	public enum STATE
	{
		IDLE,
		WALK,
		Attack,
		AttackWait,
		Dead,
		Skill1,
		Skill2,
		Skill3,
		Skill4
	}

	public STATE currentState = STATE.IDLE;
	Vector3 curTargetPos;
	GameObject curEnemy;

	public float rotAnglePerSecond = 360.0f; // 1초에 플레이어의 방향을 360도 회전
	public float moveSpeed = 2.0f; // 초당 2미터의 속도

	float attackDelay = 2.0f; // 어텍 딜레이
	float attackTimer = 0.0f;
	float attackDistance = 10.0f; // 사거리
	float chaseDistance = 2.5f;

	PlayerAni myAni;
	PlayerParams myParams;
	EnemyParams curEnemyParams;
	
	AudioSource sword;

	Inventory inv;
	public Item item;

	// Start is called before the first frame update
	void Start()
	{
		myAni = GetComponent<PlayerAni>();
		// myAni.ChangeAni(PlayerAni.ANI_WALK)

		myParams = GetComponent<PlayerParams>();
		myParams.InitParams();
		myParams.deadEvent.AddListener(ChangeToPlayerDead);
		sword = GetComponent<AudioSource>();

		ChangeState(STATE.IDLE, PlayerAni.ANI_IDLE);
		inv = transform.Find("Inventory Controller").GetComponent<Inventory>();
	}

	public void ChangeToPlayerDead()
	{
		ChangeState(STATE.Dead, PlayerAni.ANI_DEAD);
	}

	public void AttackCal()
	{
		if (curEnemy == null)
		{
			return;
		}

		
		if (curEnemy == null)
		{
			return;
		}
		curEnemy.GetComponent<EnemyFSM>().ShowHitEffect();

		int attackpower = myParams.GetAttack();
		sword.Play(0);

		curEnemyParams.SetEnemyAttack(attackpower);
	}
	
	public void AttackEnemy(GameObject enemy)
	{
		if (curEnemy != null && curEnemy == enemy)
		{
			return;
		}

		curEnemyParams = enemy.GetComponent<EnemyParams>();

		if (curEnemyParams.isDead == false)
		{

			curEnemy = enemy;
			curTargetPos = curEnemy.transform.position;

			GameManager.instance.changecurrenttarget(curEnemy);
			ChangeState(STATE.WALK, PlayerAni.ANI_WALK);
		}
		else
		{
			inv.GetItem(item, 1);
			curEnemyParams = null;
		}
	}
	void ChangeState(STATE newState, int aniNumber)
	{
		if (currentState == newState)
		{
			return;
		}

		myAni.ChangeAni(aniNumber);
		currentState = newState;
	}

	void UpdateState()
	{
		switch (currentState)
		{
			case STATE.IDLE:
				IdleState();
				break;
			case STATE.WALK:
				MoveState();
				break;
			case STATE.Attack:
				AttackState();
				break;
			case STATE.AttackWait:
				AttackWaitState();
				break;
			case STATE.Dead:
				DeadState();
				break;
			case STATE.Skill1:
				Skill1State();
				break;
			case STATE.Skill2:
				Skill2State();
				break;
			case STATE.Skill3:
				Skill3State();
				break;
			case STATE.Skill4:
				Skill4State();
				break;
			default:
				break;
		}
	}

	void IdleState()
	{

	}

	void MoveState()
	{
		TurnToDes();
		MoveToDes();
	}

	void AttackState()
	{
		attackTimer = 0.0f;
		transform.LookAt(curTargetPos);

		ChangeState(STATE.AttackWait, PlayerAni.ANI_ATKIDLE);
	}

	void AttackWaitState()
	{
		if (attackTimer > attackDelay)
		{
			ChangeState(STATE.Attack, PlayerAni.ANI_ATTACK);
		}

		attackTimer += Time.deltaTime;
	}

	void DeadState()
	{

	}

	void Skill1State()
	{
		ChangeState(STATE.Skill1, PlayerAni.ANI_SKILL1);
	}

	void Skill2State()
	{
		ChangeState(STATE.Skill2, PlayerAni.ANI_SKILL2);
	}

	void Skill3State()
	{
		ChangeState(STATE.Skill3, PlayerAni.ANI_SKILL3);
	}

	void Skill4State()
	{
		ChangeState(STATE.Skill4, PlayerAni.ANI_SKILL4);
	}
	public void MoveTo(Vector3 tPos)
	{
		if (currentState == STATE.Dead)
		{
			return;
		}

		curEnemy = null;
		curTargetPos = tPos;

		ChangeState(STATE.WALK, PlayerAni.ANI_WALK);
	}

	void TurnToDes()
	{
		Quaternion lookRotation = Quaternion.LookRotation(curTargetPos - transform.position);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSecond);
	}

	void MoveToDes()
	{
		transform.position = Vector3.MoveTowards(transform.position, curTargetPos, moveSpeed * Time.deltaTime);

		if (curEnemy == null)
		{
			if (transform.position == curTargetPos)
			{
				ChangeState(STATE.IDLE, PlayerAni.ANI_IDLE);
			}
		}

		else if (Vector3.Distance(transform.position, curTargetPos) < attackDistance)
		{
			ChangeState(STATE.Attack, PlayerAni.ANI_ATTACK);
		}
	}
	void Skill()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			Skill1State();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Skill2State();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			Skill3State();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Skill4State();
		}
	}
	// Update is called once per frame
	void Update()
	{
		UpdateState();
		Skill();
	}
}
