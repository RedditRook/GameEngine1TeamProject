using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlot : MonoBehaviour
{
	public PlayerSkill skill;           //스킬 객체
	public TextMeshPro SkillName;    //스킬 이름 출력 TMPtext
	public Image skill_image;    //스킬 이미지

	[SerializeField]
	private TextMeshProUGUI text_Count;

	private void SetColor(float _alpha)     //아이템 투명도 조절(삭제시 알파0, 생성시 알파1)
	{
		Color color = skill_image.color;
		color.a = _alpha;
		skill_image.color = color;
	}
	public void AddSkill(PlayerSkill pskill) //슬롯에 아이템이 추가될 때
	{
		skill = pskill;
		skill_image.sprite = pskill.item_image;

		text_Count.text = skill.name;

		SetColor(1);
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
