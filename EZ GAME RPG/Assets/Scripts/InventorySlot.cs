using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour      //�κ��丮 ���Կ� 
{
    public Item item;           //������ ��ü
    public TextMeshPro text;    //������ �̸� �� �ټ� ��� TMPtext
    public int item_count;      //������ �ټ�
    public Image item_image;    //������ �̹���

    [SerializeField]
    private TextMeshProUGUI text_Count;

    private void SetColor(float _alpha)     //������ ���� ����(������ ����0, ������ ����1)
    {
        Color color = item_image.color;
        color.a = _alpha;
        item_image.color = color;
    }

    public void AddItem(Item _item, int _count = 1) //���Կ� �������� �߰��� ��
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
            text_Count.text = "";
        }
        SetColor(1);
    }

    public void SetSlotCount(int _count)    //���Կ� �������� ���� ���� ��
    {
        item_count += _count;
        text_Count.text = item.name + "(" + item_count.ToString() + ")";

        if (item_count <= 0)
            ClearSlot();
    }

    private void ClearSlot()                //���Կ� �������� ������ ��
    {
        item = null;
        item_count = 0;
        item_image.sprite = null;
        SetColor(0);

        text_Count.text = "0";
    }
}