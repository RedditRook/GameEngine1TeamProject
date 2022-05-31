using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	GameObject player;
	GameObject npc;

	// Start is called before the first frame update
	//업데이트
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void MouseCheck()
	{
		if (Input.GetMouseButtonDown(1))
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
				else if (hit.collider.gameObject.tag == "Enemy")
				{
					player.GetComponent<PlayerFSM>().AttackEnemy(hit.collider.gameObject);
				}
			}
		}
	}


	void KeyboardCheck()
	{
		// SPACE 키를 눌렀을 때 플레이어가 npc와 상호작용을 하지 않고 있을 때
		if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<Player>().IsInteractingNPC == false)
		{
			float min_distance = 100.0f;

			for (int i = 0; i < GameObject.FindGameObjectWithTag("NPC").transform.childCount; ++i)
			{
				// 월드 상에 존재하는 모든 NPC들을 검사(몬스터 NPC 제외)
				GameObject near_npc = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(i).gameObject;
				// 플레이어와 NPC 사이의 거리를 검사
				float distance = Vector3.Distance(player.transform.position, near_npc.transform.position);

				// 해당 NPC와 플레이어 사이의 거리가 최단거리일 경우
				if (min_distance > distance)
				{
					min_distance = distance;
					npc = near_npc;
				}
			}

			// 해당 NPC와 플레이어 사이의 거리가 5 미만인 경우 상호작용 개시
			if (min_distance < 5.0f)
			{
				player.GetComponent<Player>().IsInteractingNPC = true;
				npc.SendMessage("ShowUI");
			}
		}

		// ESC키를 눌렀을 때 플레이어가 NPC와 상호작용을 하고 있을 때 상호작용 종료
		if (Input.GetKeyDown(KeyCode.Escape) && player.GetComponent<Player>().IsInteractingNPC == true)
		{
			player.GetComponent<Player>().IsInteractingNPC = false;
			npc.SendMessage("HideUI");
		}
	}

	// Update is called once per frame
	void Update()
	{
		MouseCheck();
		KeyboardCheck();
	}
}
