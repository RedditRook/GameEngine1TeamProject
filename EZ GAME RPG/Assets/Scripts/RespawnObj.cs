using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObj : MonoBehaviour
{
	List<Transform> spawnpos = new List<Transform>();

	GameObject[] monsters;

	public GameObject Monprefab;
	public int spawnnumber = 1;
	public float respawndelay = 3f;

	int deadMonsters = 0;

	void Start()
	{
		make_spawn_pos();
	}

	void make_spawn_pos()
	{
		foreach (Transform pos in transform)
		{
			if (pos.tag == "Respawn")
			{
				spawnpos.Add(pos);
			}
		}
		if(spawnnumber > spawnpos.Count)
		{
			spawnnumber = spawnpos.Count;
		}
		monsters = new GameObject[spawnnumber];
		make_monsters();
	}

	void make_monsters()
	{
		for(int i=0;i<spawnnumber;i++)
		{
			GameObject mon = Instantiate(Monprefab, spawnpos[i].position, Quaternion.identity) as GameObject;
			mon.SetActive(false);

			monsters[i] = mon;
		}
	}

	void spawn_monster()
	{
		for(int i=0;i<monsters.Length;i++)
		{
			monsters[i].SetActive(true);
		}
	}

	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag=="Player")
		{
			spawn_monster();
			GetComponent<SphereCollider>().enabled = false;
		}
	}

	 void Update()
	{
		
	}
}
