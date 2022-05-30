using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float maxhp;
    public float MaxHP
    {
        get
        {
            return maxhp;
        }
    }

    private float maxmp;
    public float MaxMP
    {
        get
        {
            return maxmp;
        }
    }

    private float hp;
    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    private float mp;
    public float MP
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxhp = 100;
        hp = 100;
        maxmp = 100;
        mp = 100;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
