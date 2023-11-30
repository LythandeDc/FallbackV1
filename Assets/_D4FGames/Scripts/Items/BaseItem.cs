using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private int itemID;
    public enum ItemTypes
    {
        EQUIPEMENT,
        WEAPON,
        SCROLL,
        POTION,
        CHEST
    }
    private ItemTypes itemType;

    /// <summary>
    /// Item Name
    /// </summary>
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    /// <summary>
    /// Item Description
    /// </summary>
    public string ItemDescription
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    /// <summary>
    /// Item ID
    /// </summary>
    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }

    /// <summary>
    /// Item Type
    /// </summary>
    public ItemTypes ItemType
    {
        get { return itemType; }
        set { itemType = value; }
    }
}
