using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	GameObject player;
	GameObject npc;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		npc = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).gameObject;
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	void MouseCheck()
	{
		if (Input.GetMouseButtonDown(0) && !player.GetComponent<Player>().is_interacting)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.name == "Terrain")
				{
					//player.transform.position = hit.point;

					player.GetComponent<PlayerFSM>().MoveTo(hit.point);
				}
			}
		}
	}

	void KeyboardCheck()
	{
		// NPC 상호작용 키
		if (Input.GetKeyDown(KeyCode.Space) && !player.GetComponent<Player>().is_interacting)
		{
			float min_distance = 100.0f;

			for (int i = 0; i < GameObject.FindGameObjectWithTag("NPC").transform.childCount; ++i)
			{
				GameObject temp_npc = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(i).gameObject;
				float distance = Vector3.Distance(player.transform.position, temp_npc.transform.position);

				if (min_distance > distance)
				{
					min_distance = distance;
					npc = temp_npc;
				}
			}

			if (min_distance < 5.0f)
			{
				player.GetComponent<Player>().is_interacting = true;
				npc.SendMessage("ShowUI");
			}
		}

		// 플레이어가 NPC와의 상호작용 종료 시
		if (Input.GetKeyDown(KeyCode.Escape) && player.GetComponent<Player>().is_interacting)
		{
			player.GetComponent<Player>().is_interacting = false;
			npc.SendMessage("HideUI");
		}

		// for debugging
		// if (player.GetComponent<Player>().is_interacting)
		// {
		// 	player.GetComponent<Player>().is_interacting = false;
		// 	npc.SendMessage("HideUI");
		// }
	}

	// Update is called once per frame
	void Update()
	{
		MouseCheck();
		KeyboardCheck();
	}
}
