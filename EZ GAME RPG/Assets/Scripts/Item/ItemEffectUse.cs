using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect     //아이템 효과 
{
	public string name;     //아이템 이름
	public string[] part;   //아이템 적용 효과 HP, MP, Damage, 
	public int[] num;       //아이템 효과 수치
}

public class ItemEffectUse : MonoBehaviour       //아이템 사용
{
	private ItemEffect[] item_effects; //아이템 사용 효과

	private const string HP = "HP", MP = "MP";

	public void UseItem(Item item)
	{

	}
}
