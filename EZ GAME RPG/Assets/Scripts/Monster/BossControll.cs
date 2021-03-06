using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControll : MonoBehaviour
{
	public enum CurrentState {idle, trace,attack1,attack2, dead };
	public CurrentState curstate = CurrentState.idle;
	private Transform _transform;
	private Transform playertransform;
	private Transform _Attransform;
	private NavMeshAgent nvAgent;
	private Animator _animator;

	public float traceDis = 1500.0f; // 추적 거리
	public float AttackDis = 2.0f; // 공격 사거리
	public float Attacktackle = 0.0f;
	
	
	public AttackTest _Tackle;

	private bool isDead = false; // 사망여부

	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.name + "감지 시작!");
	}
	
	// Start is called before the first frame update
	void Start()
	{
		
		AttackDis = 100.0f; // 수치개선
		traceDis = 150.0f; // 수치 개선
		Attacktackle = 25.0f; // 수치 개선
		_transform = this.gameObject.GetComponent<Transform>();
		playertransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
		nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
		_animator = this.gameObject.GetComponent<Animator>();

		
		
		//Debug.Log(_Attransform.position);
		
		//nvAgent.destination = playertransform.position;

		StartCoroutine(this.CheckState());
		StartCoroutine(this.CheckStateForAction());
	}

	IEnumerator CheckState()
	{
		while(!isDead)
		{
			yield return new WaitForSeconds(1.0f);

			float dis = Vector3.Distance(playertransform.position, transform.position);
			//Debug.Log(dis);
			//Debug.Log(AttackDis);
			//Debug.Log(dis);
			if (dis < AttackDis)
			{
				if (dis < Attacktackle)
				{
					curstate = CurrentState.attack1;
				}
				else
				{
					curstate = CurrentState.attack2;
				}
				
			}
			else if(dis < traceDis)
			{
				curstate = CurrentState.trace;
			}
			else
			{
				curstate = CurrentState.idle;
			}
		}
	}

	IEnumerator CheckStateForAction()
	{
		while (!isDead)
		{
			switch(curstate)
			{
				case CurrentState.idle:
					nvAgent.Stop();
					_animator.SetBool("idle", true);
					break;
				case CurrentState.trace:
					Quaternion lookRotation = Quaternion.LookRotation(playertransform.position - transform.position);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 360.0f);
					transform.position = Vector3.MoveTowards(transform.position, playertransform.position,1);
					//bool k = _animator.GetBool("Walk_Cycle_1");
					_animator.SetBool("Walk_Cycle_1", true);
					_animator.SetBool("Attack_2", false);
					_animator.SetBool("Attack_4", false);
					break;
				case CurrentState.attack1:
					lookRotation = Quaternion.LookRotation(playertransform.position - transform.position);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 360.0f);
					_animator.SetBool("Attack_2", true);
					_animator.SetBool("Attack_3", true);
					_animator.SetBool("Attack_Change", true);
				//	if(_Tackle.CheckCol)
					//{
						
					//}
					break;
				case CurrentState.attack2:
					lookRotation = Quaternion.LookRotation(playertransform.position - transform.position);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * 360.0f);
					_animator.SetBool("Attack_4", true);
					_animator.SetBool("Attack_2", false);
					_animator.SetBool("Walk_Cycle_1", false);
				
					break;
			}

			yield return null;
		}
	}
	// Update is called once per frame


	public int GetState()
    {
		Debug.Log(curstate);
		if(curstate == CurrentState.idle)
        {
			return 1;
        }

		else if (curstate == CurrentState.trace)
		{
			return 2;
		}

		else if (curstate == CurrentState.attack1)
		{
			return 3;
		}

		else if (curstate == CurrentState.attack2)
		{
			return 4;
		}

		else 
			return 5;
		
	}
		
}
