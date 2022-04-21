using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	GameObject player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	void MouseCheck()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.name == "Terrain")
				{
					player.transform.position = hit.point;
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
