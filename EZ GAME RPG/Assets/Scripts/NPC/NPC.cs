using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	// 변수 목록
	private Rigidbody rigid_body;       // rigid body
	protected new string name;          // 이름
	protected Vector3 position;         // 위치
	protected TextBox text;				// UI 객체 추가 예정

	// 퀘스트, 여관, 상점

	private void Awake()
	{
		rigid_body = GetComponent<Rigidbody>();
		text = GameObject.Find("TextBox").GetComponent<TextBox>();
		//text = GetComponent<TextBox>();
	}

	// Start is called before the first frame update
	public virtual void Start()
	{

	}

	// Update is called once per frame
	public virtual void Update()
	{

	}

	// 플레이어와 상호작용이 이뤄졌을 때 UI를 표시하는 함수
	public virtual void ShowUI()
	{

	}
	public virtual void HideUI()
	{

	}

	public string Name { get; }

	public Vector3 Position { get; }
}
