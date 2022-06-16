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

	public EnemyParams myParams;

	EnemyAni myAni;
	GoblinAni goani;
	SkeletonAni skeani;

	Inventory inv;
	public Item item;

	Transform player;
	

	//Transform player;


	float chase_distance = 30f;  // 추적 시작 거리
	float attack_distance = 15f; // 공격 시작 범위
	float re_chase_distance = 14.5f; // 추적 시작 거리

	float rotAnglePerSec = 360f; //초당 회전 각도
	float moveSpeed = 25f;    //몬스터 이동속도

	float attackDelay = 2f;
	float attackTimer = 0f;


	public ParticleSystem hitEffects;

	public GameObject selectmark;
	GameObject myrespawnobj;
	public int spawnid { get; set; }

	Vector3 originpos;

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

		hideselection();
		myParams = GetComponent<EnemyParams>();
		myParams.InitParams();
		myParams.deadEvent.AddListener(CallDeadEvent);

		inv = GameObject.Find("Inventory Controller").GetComponent<Inventory>();
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

		player = GameObject.Find("Player").transform;
		playerParams = player.gameObject.GetComponent<PlayerParams>();

		hitEffects.Stop();
	}

	public void addtoworldagain()
	{
		transform.position = originpos;
		GetComponent<EnemyParams>().InitParams();
		GetComponent<BoxCollider>().enabled = true;
	}

	public void hideselection()
	{
		selectmark.SetActive(false);
	}

	public void showselection()
	{
		selectmark.SetActive(true);
	}
	public void AttackCal()
	{
		int attackpower = myParams.GetAttack();
		myParams.SetEnemyAttack(attackpower);
	}

	public void setspawnobj(GameObject respawnobj, int spawnid, Vector3 originpos)
	{
		myrespawnobj = respawnobj;
		this.spawnid = spawnid;
		this.originpos = originpos;
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

		StartCoroutine(removemefromworld());
	}
	IEnumerator removemefromworld()
	{
		yield return new WaitForSeconds(1f);

		if (check == 0)
		{
			inv.GetGold(100);
			inv.GetItem(item);
			ChangeState(State.Idle, EnemyAni.IDLE);
		}
		if (check == 1)
		{
			inv.GetGold(100);
			inv.GetItem(item);
			ChangeState(State.Idle, GoblinAni.IDLE);
		}
		if (check == 2)
		{
			inv.GetGold(100);
			inv.GetItem(item);
			ChangeState(State.Idle, SkeletonAni.IDLE);
		}

		myrespawnobj.GetComponent<RespawnObj>().removemonster(spawnid);
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
			default:
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