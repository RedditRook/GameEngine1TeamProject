using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	List<GameObject> monsters = new List<GameObject>();

	void Awake()
	{
		if(instance == null)
		{
			instance = this; 
		}
	}

	public void addnewmonsters(GameObject mon)
	{
		bool sameexist = false;
		for(int i=0; i < monsters.Count; i++)
		{
			if(monsters[i] == mon)
			{
				sameexist = true;
				break;
			}
		}
		if(sameexist==false)
		{
			monsters.Add(mon);
		}
	}

	public void removemonster(GameObject mon)
	{
		foreach (GameObject monster in monsters)
		{
			if(monster == mon)
			{
				monsters.Remove(monster);
				break;
			}
		}
	}

	public void changecurrenttarget(GameObject mon)
	{
		deselectallmonster();
		mon.GetComponent<EnemyFSM>().showselection();
	}

	public void deselectallmonster()
	{
		for(int i =0;i<monsters.Count;i++)
		{
			monsters[i].GetComponent<EnemyFSM>().hideselection();
		}
	}
	void Update()
	{
	}
}
