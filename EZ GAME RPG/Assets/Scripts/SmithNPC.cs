public class SmithNPC : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		name = "릴리아나";
	}

	// Update is called once per frame
	public override void Update()
	{

	}

	public override void ShowUI()
	{
		print(name);
		print("필요한 무기가 있어?");
	}

	public override void HideUI()
	{
		print(name);
		print("망가지면 고치러 와.");
	}
}
