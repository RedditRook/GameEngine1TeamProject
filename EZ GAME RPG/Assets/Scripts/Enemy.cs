using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float max_health;
    public float current_health;
    public Transform target;
    
    Rigidbody rigid;
    BoxCollider box_collider;
    Material mat;
    NavMeshAgent nav;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        box_collider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
    }

     void Update()
    {
        nav.SetDestination(target.position);   
    }
}
