public class ShopNPC : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		name = "포르자";
	}

	// Update is called once per frame
	public override void Update()
	{

	}

	public override void ShowUI()
	{
		print(name);
		print("세상의 모든 물건을 취급하는 포르자 상회입니다.");
	}

	public override void HideUI()
	{
		print(name);
		print("다음에 또 방문해 주세요.");
	}
}
