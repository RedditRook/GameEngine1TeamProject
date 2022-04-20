using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    enum ITEMCODE 
    { 
        BASIC_SWORD,
        BASIC_SHIELD,
        BASIC_HELMET,
        BASIC_ARMOR,
        BASIC_LEGGINGS
    };
    private string name;
    private int value;
    private int code;
}
