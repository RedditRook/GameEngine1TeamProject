using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
	// Start is called before the first frame update

	public const int ANI_IDLE = 0;
	public const int ANI_WALK = 1;

	Animator anim;
    
    void Start()
    {
		anim = GetComponent<Animator>();
    }


	public void ChangeAni(int aniNumber)
    {
		anim.SetInteger("aniName", aniNumber);
    }


    // Update is called once per frame
    void Update()
    {
		
    }
}
