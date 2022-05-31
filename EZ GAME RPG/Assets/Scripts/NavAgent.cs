using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavAgent : MonoBehaviour
{
	public Transform target;
	public bool is_chase;
	NavMeshAgent nav;

	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if (is_chase)
		{
			nav.SetDestination(target.position);
		}
	}
}
