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
        public static List<AmmoType> AmmoTypes { get; private set; }

        public static void UpdateLists(
            List<WeaponData> newWeapons, 
            List<GameObject> newSights, 
            List<MagData> newMags, 
            List<AmmoType> newAmmoTypes)
        {
            Weapons = newWeapons;
            SightPrefabs = newSights;
            Mags = newMags;
            AmmoTypes = newAmmoTypes;
        }
        
        // For efficient use with weapon spawner
        public static Weapon AssembleWeapon(int weaponIndex, int magIndex, GameObject model)
        {
            Magazine magazine = new Magazine(Mags[magIndex], Helper.FindChildWithTag(model, "Magazine"));
            magazine.FillMag(AmmoTypes[0]); // Fill with placeholder ammo for now
            Weapon newWeapon = new Weapon(Weapons[weaponIndex], model, magazine);
            return newWeapon;
        }
    }
}