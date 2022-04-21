public class QuestNPC : NPC
{
	// Start is called before the first frame update
	public override void Start()
	{
		name = "카린";
		ani.SetBool("param_idletoko_big", false);
	}

	// Update is called once per frame
	public override void Update()
	{

	}

	public override void ShowUI()
	{
		print(name);
		print("모험가 길드에 오신 것을 환영합니다.");
		print("현재 수행 가능한 퀘스트 목록입니다.");

		ani.SetBool("param_idletoko_big", true);
	}

	public override void HideUI()
	{
		print(name);
		print("이용해 주셔서 감사합니다.");
		print("다음에 또 이용해 주세요.");
		ani.SetBool("param_idletoko_big", false);
	}
}
