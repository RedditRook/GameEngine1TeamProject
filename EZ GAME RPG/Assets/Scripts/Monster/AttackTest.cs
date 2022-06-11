using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour
{
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
		Debug.Log("감지 시작1111!");
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
