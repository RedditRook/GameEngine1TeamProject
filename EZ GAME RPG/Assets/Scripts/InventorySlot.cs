using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour      //인벤토리 슬롯에 
{
    public Item item;           //아이템 객체
    public TextMeshPro text;    //아이템 이름 및 겟수 출력 TMPtext
    public int item_count;      //아이템 겟수
    public Image item_image;    //아이템 이미지

    [SerializeField]
    private TextMeshProUGUI text_Count;

    private void SetColor(float _alpha)     //아이템 투명도 조절(삭제시 알파0, 생성시 알파1)
    {
        Color color = item_image.color;
        color.a = _alpha;
        item_image.color = color;
    }

    public void AddItem(Item _item, int _count = 1) //슬롯에 아이템이 추가될 때
    {
        item = _item;
        item_count = _count;
        item_image.sprite = item.item_image;

        if (item.item_type != Item.ITEMTYPE.equipment)
        {
            text_Count.text = item.name + "(" + item_count.ToString() + ")";
        }
        else
        {
            text_Count.text = " ";
        }
        SetColor(1);
    }

    public void SetSlotCount(int _count)    //슬롯에 아이템의 수가 변할 때
    {
        item_count += _count;
        text_Count.text = item.name + "(" + item_count.ToString() + ")";

        if (item_count <= 0)
            ClearSlot();
    }

    private void ClearSlot()                //슬롯에 아이템이 없어질 때
    {
        item = null;
        item_count = 0;
        item_image.sprite = null;
        SetColor(0);

        text_Count.text = "0";
    }
}