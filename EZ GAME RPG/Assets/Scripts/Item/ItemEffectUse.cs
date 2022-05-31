using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect     //������ ȿ������� Ŭ����
{
	public string name;     //������ �̸�(Ű)
	public string[] part;   //ü��, ���� ���? HP, MP, Damage, 
	public int[] num;       //�󸶳� �ۿ���?
}

public class ItemEffectUse : MonoBehaviour       //�������� ȿ�� ����
{
	private ItemEffect[] item_effects; //�����ۺ� ȿ�� ����� �迭

	private const string HP = "HP", MP = "MP";

	public void UseItem(Item item)
	{

	}
}
