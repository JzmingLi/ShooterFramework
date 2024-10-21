using System;
using System.Collections.Generic;
using HelperClasses;
using UnityEngine;
using UnityEngine.Serialization;

namespace WeaponFramework.Factories
{
    public static class WeaponFactory
    {
        public static List<WeaponData> Weapons { get; private set; }
        public static List<GameObject> SightPrefabs { get; private set; }
        public static List<MagData> Mags { get; private set; }

        public static void UpdateLists(List<WeaponData> newWeapons, List<GameObject> newSights, List<MagData> newMags)
        {
            Weapons = newWeapons;
            SightPrefabs = newSights;
            Mags = newMags;
        }
        
        // For now directly assembles weapons and places it into the weapon controller
        public static void AssembleWeapon(int weaponIndex, int magIndex, GameObject model, WeaponController location)
        {
            Magazine magazine = new Magazine(Mags[magIndex], Helper.FindChildWithTag(model, "Magazine"));
            Weapon newWeapon = new Weapon(Weapons[weaponIndex], model, magazine);
        }
    }
}