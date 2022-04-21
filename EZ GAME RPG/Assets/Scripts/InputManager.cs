using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	GameObject player;
	List<GameObject> npcs;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		npcs = new List<GameObject>();
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
					//player.transform.position = hit.point;

					player.GetComponent<PlayerFSM>().MoveTo(hit.point);
				}
			}
		}
	}

	void KeyboardCheck()
	{
		// NPC 상호작용 키
		if (Input.GetKeyDown(KeyCode.Space))
		{
			for (int i = 0; i < GameObject.FindGameObjectWithTag("NPC").transform.childCount; ++i)
			{
				npcs.Add(GameObject.FindGameObjectWithTag("NPC").transform.GetChild(i).gameObject);
			}

				float distance = Vector3.Distance(player.transform.position, npc.transform.position);

				if (distance < 5.0f)
				{
					npc.SendMessage("ShowUI");
				}
		}
	}

	// Update is called once per frame
	void Update()
	{
		MouseCheck();
		KeyboardCheck();
	}
}
