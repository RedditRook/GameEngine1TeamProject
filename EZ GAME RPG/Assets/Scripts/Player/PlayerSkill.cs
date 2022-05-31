using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Make", menuName = "Make/Skill")]
public class PlayerSkill : ScriptableObject
{
	public string name;
	public Sprite item_image;
	public GameObject item_prefab;
}
