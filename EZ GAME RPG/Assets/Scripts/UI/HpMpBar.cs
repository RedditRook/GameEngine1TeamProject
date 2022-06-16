using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpMpBar : MonoBehaviour
{
	public PlayerParams player;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

		transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().fillAmount = player.curHp / player.MaxHp;
		transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().fillAmount = player.curMp / player.MaxMp;
		transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().fillAmount = player.curexp / player. expToLevelUp;

	}
}
