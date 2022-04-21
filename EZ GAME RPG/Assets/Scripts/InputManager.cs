using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

	GameObject player;
	// Start is called before the first frame update
	//업데이트
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");

	}

	void MouseCheck()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.name == "Plane003")
				{
					//player.transform.position = hit.point;

					player.GetComponent<PlayerFSM>().MoveTo(hit.point);
				}

				else if(hit.collider.gameObject.tag == "Enemy")
				{
					player.GetComponent<PlayerFSM>().AttackEnemy(hit.collider.gameObject);
				}
			}
		}
	}
	// Update is called once per frame
	void Update()
    {
		MouseCheck();
    }
}
