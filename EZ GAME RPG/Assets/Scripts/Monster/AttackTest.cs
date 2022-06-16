using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour
{
	public float curHp;
	public int atk;
	public int def;
	public float MaxHp;
	public bool isDead;

	public bool CheckCol = false;
	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other);
		if (other.tag =="Player")
		{
			CheckCol = true;
		}

		Debug.Log(CheckCol);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			CheckCol = false;
		}
	}


	// Start is called before the first frame update
	void Start()
    {
		name = "BossMob";
		MaxHp = 1000;
		curHp = MaxHp;
		atk = 50;
		def = 50;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
