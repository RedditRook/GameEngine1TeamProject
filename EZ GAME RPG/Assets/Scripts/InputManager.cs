using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	// 사용 키 모음
	private Dictionary<KeyCode, Action> key_dictionary;

	private GameObject player;
	private NPC interact_npc;
	private Inventory inventory;
	private Shop shop;

	private void Awake()
	{
		key_dictionary = new Dictionary<KeyCode, Action>
		{
			{ KeyCode.Space, StartInteraction },
			{ KeyCode.Escape, EndInteraction },
			{ KeyCode.I, ActInventory },
			{ KeyCode.A, NormalAttack },
			{ KeyCode.Q, Skill1 },
			{ KeyCode.W, Skill2 },
			{ KeyCode.E, Skill3 },
			{ KeyCode.R, Skill4 },
		};
	}

	// Start is called before the first frame update
	//업데이트
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		inventory = GameObject.Find("Inventory Controller").GetComponent<Inventory>();
		interact_npc = GameObject.FindGameObjectWithTag("NPC").transform.GetChild(0).GetComponent<NPC>();
		shop = GameObject.Find("ShopList").GetComponent<Shop>();
	}

	void MouseCheck()
	{
		// 우클릭
		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.name == "Object100")
				{
					//player.transform.position = hit.point;

					player.GetComponent<PlayerFSM>().MoveTo(hit.point);
				}
			}
		}
		// 좌클릭
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.tag == "Enemy")
				{
					player.GetComponent<PlayerFSM>().AttackEnemy(hit.collider.gameObject);
				}
			}
		}
	}

	void KeyboardCheck()
	{
		if (Input.anyKeyDown)
		{
			foreach (var dic in key_dictionary)
			{
				if (Input.GetKeyDown(dic.Key))
				{
					dic.Value();
				}
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		MouseCheck();
		KeyboardCheck();
	}

	// NPC와 상호작용 시작
	private void StartInteraction()
	{
		// 플레이어가 npc와 상호작용을 하지 않고 있을 때
		if (player.GetComponent<Player>().IsInteractingNPC == false)
		{
			var npc = GameObject.FindGameObjectWithTag("NPC").transform;
			float min_distance = 100.0f;

			for (int i = 0; i < npc.childCount; ++i)
			{
				// 월드 상에 존재하는 모든 NPC들을 검사(몬스터 NPC 제외)
				// 플레이어와 NPC 사이의 거리를 검사
				float distance = Vector3.Distance(player.transform.position, npc.GetChild(i).position);

				// 해당 NPC와 플레이어 사이의 거리가 최단거리일 경우
				if (min_distance > distance)
				{
					min_distance = distance;
					interact_npc = npc.GetChild(i).GetComponent<NPC>();
				}
			}

			// 해당 NPC와 플레이어 사이의 거리가 5 미만인 경우 상호작용 개시
			if (min_distance < 5.0f)
			{
				player.GetComponent<Player>().IsInteractingNPC = true;
				interact_npc.ShowUI();
			}
		}
	}

	// 상호작용 종료
	private void EndInteraction()
	{
		if (shop.OnOpened)
		{
			shop.TryOpenShop();
		}
		// 인벤토리가 열려있으면 인벤토리를 닫는다
		else if (inventory.OnActivated)
		{
			inventory.TryOpenInventory();
		}
		// if else 구조를 이용하여 UI가 1개씩 닫히도록 한다
		// 플레이어가 NPC와 상호작용을 하고 있을 때
		else if (player.GetComponent<Player>().IsInteractingNPC == true)
		{
			// 상호작용 종료
			player.GetComponent<Player>().IsInteractingNPC = false;
			interact_npc.HideUI();
		}
	}

	private void ActInventory()
	{
		inventory.TryOpenInventory();
	}

	private void NormalAttack()
	{

		// TODO: 평타
	}

	private void Skill1()
	{
		// TODO: 스킬 발동
	}

	private void Skill2()
	{

	}
	
	private void Skill3()
	{

	}

	private void Skill4()
	{
		
	}
}
