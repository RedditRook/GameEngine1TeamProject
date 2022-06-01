using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour		//인벤토리 슬롯에 
{
	public Item item;			//아이템 객체
	public TextMeshProUGUI name;	//아이템 이름
	public TextMeshProUGUI price;	//아이템 가격
	public Image item_image;	//아이템 이미지

	[SerializeField]
	private TextMeshProUGUI text;

	private void Start()
	{
		name.text = item.name;
		price.text = item.price.ToString();
		item_image.sprite = item.item_image;
	}

	private void SetColor(float _alpha)		//아이템 투명도 조절(삭제시 알파0, 생성시 알파1)
	{
		Color color = item_image.color;
		color.a = _alpha;
		item_image.color = color;
	}
}