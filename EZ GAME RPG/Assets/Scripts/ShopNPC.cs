using UnityEngine;

public class ShopNPC : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		name = "shop";
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
