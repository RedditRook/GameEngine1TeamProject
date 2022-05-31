using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect     //아이템 효과저장용 클래스
{
    public string name;     //아이템 이름(키)
    public string[] part;   //체력, 마나 어디에? HP, MP, Damage, 
    public int[] num;       //얼마나 작용을?
}

public class ItemEffectUse : MonoBehaviour       //아이템의 효과 적용
{
    private ItemEffect[] item_effects; //아이템별 효과 저장용 배열

    private const string HP = "HP", MP = "MP";

    public void UseItem(Item item)
    {

    }
}
