using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitcheck : MonoBehaviour
{
	public int maxhealth;
	public int curhealth;

	Rigidbody rigid;
	BoxCollider boxcollider;

	void Awake()
	{
		rigid = GetComponent<Rigidbody>();
		boxcollider = GetComponent<BoxCollider>();
	}

	void OnTriggerEnter(Collider other)
	{
			
	}
}
