using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	public GameObject fadein;

	private bool scenechangecheck;
	private bool sceneopencheck;
	private float timer;
	private float waitingtime;
	private float fadeinalpha;

	void Start()
	{
		timer = 0.0f;
		fadeinalpha = 1.0f;
		waitingtime = 2;
		scenechangecheck = false;
		sceneopencheck = true;
		fadein.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

    void Update()
	{
		timer += Time.deltaTime;
		if (sceneopencheck == true)
		{
			fadeinalpha -= Time.deltaTime / waitingtime;
			fadein.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, fadeinalpha);

			if (timer >= waitingtime)
			{
				sceneopencheck = false;
				fadein.SetActive(false);
			}
		}
		if (scenechangecheck == true)
		{
			fadeinalpha += Time.deltaTime / waitingtime;
			fadein.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, fadeinalpha);

			if (timer >= waitingtime)
				SceneManager.LoadScene("GameScene");
		}
	}

	public void SceneChanged()
	{
		fadein.SetActive(true);
		scenechangecheck = true;
		timer = 0;
	}
}
