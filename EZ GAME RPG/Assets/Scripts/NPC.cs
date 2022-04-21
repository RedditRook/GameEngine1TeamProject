using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
	// 변수 목록
	private Rigidbody rigid_body;
	protected new string name;
	protected Vector3 position;

	private Player player;

	// 퀘스트, 제작, 상점

	private void Awake()
	{
		rigid_body = GetComponent<Rigidbody>();
	}

    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

	public string Name
	{
		get { return name; }
	}
}
