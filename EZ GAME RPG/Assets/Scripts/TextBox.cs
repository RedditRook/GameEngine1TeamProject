using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBox : MonoBehaviour
{
	public GameObject conversation;
	public TextMeshPro text;    //스킬 이름 출력 TMPtext

	[SerializeField]
	private TextMeshProUGUI conversation_text;
	[SerializeField]
	private TextMeshProUGUI name_text;

	private float timer;
	private float waitingtime;

	// Start is called before the first frame update
	void Start()
	{
		conversation.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if(timer >= waitingtime)
		{
			conversation.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.J))
		{
			ShowBoxByTime(5);
		}
	}

	void PrintText(string ptext)
	{
		conversation_text.text = ptext;
	}
	void PrintName(string ptext)
	{
		name_text.text = ptext;
	}

	void ShowBoxByTime(float ftime)
	{
		timer = 0;
		conversation.SetActive(true);
		waitingtime = ftime;
	}
	void ShowBox()
	{
		conversation.SetActive(true);
	}
}
