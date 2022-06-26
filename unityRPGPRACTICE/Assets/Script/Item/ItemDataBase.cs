using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ItemDataBase : MonoBehaviour
{
    [SerializeField]
    public ItemSet[] setItem;

}

[System.Serializable]
public struct ItemSet
{
    public Sprite ItemForm;
    public Sprite ItemCharImage;
    public string ItemName;
    public int ItemID;
    public bool isBuy;
    public bool isUse;
    public GameObject Item;
    public int ItemSell;
    public int ItemAddDamage;
    [TextArea(0,4)]
    public string ItemReference;
}
