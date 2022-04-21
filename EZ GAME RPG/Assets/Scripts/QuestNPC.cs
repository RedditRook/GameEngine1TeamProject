using UnityEngine;

public class QuestNPC : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		name = "quest";
	}

	// Update is called once per frame
	public override void Update()
	{

	}

	public override void ShowUI()
	{
		print(name);
	}
}
