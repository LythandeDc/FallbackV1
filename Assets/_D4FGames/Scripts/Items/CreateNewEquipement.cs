using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewEquipement : MonoBehaviour
{
    private BaseEquipment newEquipment;
    private string[] itemNames = new string[4] { "Common", "Great", "Amazing", "Insane" };
    private string[] itemDes = new string[2] { "A new cool item", "A new not-so-cool item" };

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        CreateEquipment();
        Debug.Log(newEquipment.ItemName);
        Debug.Log(newEquipment.ItemDescription);
        Debug.Log(newEquipment.ItemID.ToString());
        Debug.Log(newEquipment.EquipmentType.ToString());
        Debug.Log(newEquipment.Staminia.ToString());
        Debug.Log(newEquipment.Endurance.ToString());
    }

    /// <summary>
    /// Create Equipment
    /// </summary>
    private void CreateEquipment()
    {
        newEquipment = new BaseEquipment();
        newEquipment.ItemName = itemNames[Random.Range(0, 3)] + " Item";
        newEquipment.ItemID = Random.Range(1, 101);
        ChooseItemType();
        newEquipment.ItemDescription = itemDes[Random.Range(0, itemDes.Length)] + " Decription";
        // STATS
        newEquipment.Staminia = Random.Range(1, 11);
        newEquipment.Endurance = Random.Range(1, 11);
        newEquipment.Intellect = Random.Range(1, 11);
        newEquipment.Strength = Random.Range(1, 11);
    }

    /// <summary>
    /// Choose Item Type
    /// </summary>
    private void ChooseItemType()
    {
        int randomTemp = Random.Range(1, 9);

        if(randomTemp == 1)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HEAD;
        }
        else if (randomTemp == 2)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
        }
        else if (randomTemp == 3)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.SHOULDERS;
        }
        else if (randomTemp == 4)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.FEET;
        }
        if (randomTemp == 5)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.NECK;
        }
        if (randomTemp == 6)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.EARRING;
        }
        if (randomTemp == 7)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.RING;
        }
        if (randomTemp == 8)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEGS;
        }
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        
    }
}
