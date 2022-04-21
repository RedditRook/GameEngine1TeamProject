using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
	public enum STATE
	{
		IDLE,
		WALK
	}

	public STATE currentState = STATE.IDLE;

	Vector3 curTargetPos;

	public float rotAnglePerSecond = 360.0f; // 1초에 플레이어의 방향을 360도 회전

	public float moveSpeed = 2.0f; // 초당 2미터의 속도

	PlayerAni myAni;


    // Start is called before the first frame update
    void Start()
	{
		myAni = GetComponent<PlayerAni>();
		// myAni.ChangeAni(PlayerAni.ANI_WALK)

		ChangeState(STATE.IDLE, PlayerAni.ANI_IDLE);
	}

	void ChangeState(STATE newState, int aniNumber)
    {
		if(currentState == newState)
        {
			return;
        }

		myAni.ChangeAni(aniNumber);
		currentState = newState;
    }

	void UpdateState()
    {
		switch(currentState)
        {
			case STATE.IDLE:
				IdleState();
				break;
			case STATE.WALK:
				MoveState();
				break;
        }
    }

	void IdleState()
    {

    }

	void MoveState()
    {
		TurnToDes();
		MoveToDes();
	}



	public void MoveTo(Vector3 tPos)
    {
		curTargetPos = tPos;
		ChangeState(STATE.WALK, PlayerAni.ANI_WALK);
    }

	void TurnToDes()
    {
		Quaternion lookRotation = Quaternion.LookRotation(curTargetPos - transform.position);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSecond);
    }

	void MoveToDes()
    {
		transform.position = Vector3.MoveTowards(transform.position, curTargetPos, moveSpeed * Time.deltaTime);

		if(transform.position == curTargetPos)
        {
			ChangeState(STATE.IDLE, PlayerAni.ANI_IDLE);
        }
    }
	// Update is called once per frame
	void Update()
    {
		UpdateState();
    }
}
