using System;
using System.Collections.Generic;
using HelperClasses;
using UnityEngine;
using UnityEngine.Serialization;

namespace WeaponFramework.Factories
{
    public static class WeaponFactory
    {
        private static ItemManager _itemManager = ItemManager.Instance;
        
        // For efficient use with weapon spawner
        public static Weapon AssembleWeapon(int weaponIndex, int magIndex, GameObject model)
        {
            Magazine magazine = new Magazine(_itemManager.mags[magIndex], Helper.FindChildWithTag(model, "Magazine"));
            magazine.FillMag(_itemManager.ammoTypes[0]); // Fill with placeholder ammo for now
            Weapon newWeapon = new Weapon(_itemManager.weapons[weaponIndex], model, magazine);
            return newWeapon;
        }
    }
}