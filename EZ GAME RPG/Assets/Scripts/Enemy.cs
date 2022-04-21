using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public float max_health;
	public float current_health;
	public Transform target;
	public BoxCollider melee_area;
	public bool is_chase;
	public bool is_attack;


	Rigidbody rigid;
	BoxCollider box_collider;
	Material mat;
	NavMeshAgent nav;
	Animator anime;

	void Awake()
	{
		rigid = GetComponent<Rigidbody>();
		box_collider = GetComponent<BoxCollider>();
		mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
		nav = GetComponent<NavMeshAgent>();
		anime = GetComponent<Animator>();

		Invoke("ChaseStart", 2);
	}

	void ChaseStart()
	{
		is_chase = true;
		anime.SetBool("isWalk", true);
	}

	void Update()
	{
		if (is_chase)
		{
			nav.SetDestination(target.position);
		}

	}

	void Targeting()
	{
		float target_radius = 1.5f;
		float targe_range = 30f;

		RaycastHit[] ray_hits = Physics.SphereCastAll(transform.position, target_radius, transform.forward, targe_range, LayerMask.GetMask("Player"));

		if(ray_hits.Length > 0)
		{
			StartCoroutine(Attack());
		}

	}

	IEnumerator Attack()
	{
		is_chase = false;
		is_attack = true;
		anime.SetBool("isAttack", true);

		yield return new WaitForSeconds(0.2f);
		melee_area.enabled = true;

		yield return new WaitForSeconds(1f);
		melee_area.enabled = false;

		is_chase = true;
		is_attack = false;
		anime.SetBool("isAttack", false);

	}

	void FixedUpdate()
	{
		Targeting();
	}
}
