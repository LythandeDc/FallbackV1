using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPotion : MonoBehaviour
{
    private BasePotion newPotion;
    // String that several names for potions

    /// <summary>
    /// START
    /// </summary>
	void Start ()
    {
        CreatePotion();
        Debug.Log(newPotion.ItemName);
        Debug.Log(newPotion.ItemDescription);
        Debug.Log(newPotion.ItemID.ToString());
        Debug.Log(newPotion.PotionType.ToString());
    }

    /// <summary>
    /// CREATE POTION
    /// </summary>
    private void CreatePotion()
    {
        newPotion = new BasePotion();
        newPotion.ItemName = "Potion";
        newPotion.ItemDescription = "This is a potion";
        newPotion.ItemID = Random.Range(0, 101);
        ChoosePotionType();
    }

    /// <summary>
    /// Choose Potion Type
    /// </summary>
    private void ChoosePotionType()
    {
        int randomTemp = Random.Range(0, 7);

        if (randomTemp == 0)
        {
            newPotion.PotionType = BasePotion.PotionTypes.HEALTH;
        }
        else if (randomTemp == 1)
        {
            newPotion.PotionType = BasePotion.PotionTypes.ENERGY;
        }
        else if (randomTemp == 2)
        {
            newPotion.PotionType = BasePotion.PotionTypes.STRENGTH;
        }
        else if(randomTemp == 3)
        {
            newPotion.PotionType = BasePotion.PotionTypes.INTELLECT;
        }
        else if(randomTemp == 4)
        {
            newPotion.PotionType = BasePotion.PotionTypes.VITALITY;
        }
        else if(randomTemp == 5)
        {
            newPotion.PotionType = BasePotion.PotionTypes.ENDURANCE;
        }
        else if(randomTemp == 6)
        {
            newPotion.PotionType = BasePotion.PotionTypes.SPEED;
        }
    }
	
	/// <summary>
    /// UPDATE
    /// </summary>
	void Update ()
    {
		
	}
}
