using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFSM : MonoBehaviour
{
	public enum STATE
	{
		IDLE,
		WALK,
		Attack,
		AttackWait,
		Dead,
		Attack2,
		Attack3,
		Roll
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
	public BossControll bossControll;

    // Start is called before the first frame update
    void Start()
	{
		myAni = GetComponent<PlayerAni>();
		// myAni.ChangeAni(PlayerAni.ANI_WALK)
		myParams = GetComponent<PlayerParams>();
		myParams.InitParams();
		myParams.deadEvent.AddListener(ChangeToPlayerDead);

		ChangeState(STATE.IDLE, PlayerAni.ANI_IDLE);
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

		curEnemy.GetComponent<EnemyFSM>().ShowHitEffect();

		int attackpower = myParams.GetAttack();

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
			curEnemyParams = null;
		}
	}
	public void ChangeState(STATE newState, int aniNumber)
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

		Debug.Log(currentState);
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
			case STATE.Attack2:
				AttackSkill2();
				break;
			case STATE.Attack3:
				AttackSkill3();
				break;
			case STATE.Roll:
				Roll();
				break;
			default:
				break;
		}
	}

	void Roll()
	{

	}
	void AttackSkill2()
	{
		Debug.Log("aaaaa");
		//ChangeState(STATE.IDLE, PlayerAni.ANI_IDLE);
	}

	void AttackSkill3()
	{
		//ChangeState(STATE.IDLE, PlayerAni.ANI_IDLE);
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

		//ChangeState(STATE.AttackWait, PlayerAni.ANI_ATKIDLE);
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

	// Update is called once per frame
	void Update()
	{
		UpdateState();
	}
}
