using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public float max_health;
	public float current_health;
	public Transform target;
	public bool is_chase;
	
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
			current_health -= 0.05f;
		}

	}
}
