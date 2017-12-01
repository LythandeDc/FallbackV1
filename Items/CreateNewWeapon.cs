using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWeapon : MonoBehaviour
{
    private BaseWeapon newWeapon;

    void Start()
    {
        CreateWeapon();
        Debug.Log(newWeapon.ItemName);
        Debug.Log(newWeapon.ItemDescription);
        Debug.Log(newWeapon.ItemID.ToString());
        Debug.Log(newWeapon.WeaponType.ToString());
        Debug.Log(newWeapon.Staminia.ToString());
        Debug.Log(newWeapon.Endurance.ToString());
    }

    /// <summary>
    /// Create Weapon
    /// </summary>
    public void CreateWeapon()
    {
        newWeapon = new BaseWeapon();

        // Assign name to the weapon
        newWeapon.ItemName = "W" + Random.Range(1, 101);
        // Create a weapon description
        newWeapon.ItemDescription = "This is a new weapon";
        // Weapon ID
        newWeapon.ItemID = Random.Range(1, 101);
        // Stats
        newWeapon.Staminia = Random.Range(1, 11);
        newWeapon.Endurance = Random.Range(1, 11);
        newWeapon.Intellect = Random.Range(1, 11);
        newWeapon.Strength = Random.Range(1, 11);
        // Choose type of weapon
        ChooseWeaponType();
        // Spell effect id
        newWeapon.SpellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType()
    {
        int randomTemp = Random.Range(1, 7);

        if(randomTemp == 1)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
        }
        else if (randomTemp == 2)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.STAFF;
        }
        else if (randomTemp == 3)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.DAGGER;
        }
        else if (randomTemp == 4)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.BOW;
        }
        else if (randomTemp == 5)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHIELD;
        }
        else if (randomTemp == 6)
        {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.POLEARM;
        }
    }
}
