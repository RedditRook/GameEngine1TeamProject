using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Make Item", menuName = "Make Item/Item")]
public class Item : ScriptableObject
{
    public enum ITEMTYPE
    {
        equipment,
        consumable,
        material,
    }

    public ITEMTYPE item_type;
    public string name;
    public Sprite item_image;
    public GameObject item_prefab;
}