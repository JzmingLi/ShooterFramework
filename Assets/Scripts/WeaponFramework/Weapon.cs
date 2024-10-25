using System.Collections.Generic;
using HelperClasses;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WeaponFramework
{
    public class Weapon
    {
        // Base Weapon Stats
        private WeaponData _baseData;
        
        #region Stats after Adjustments
            // Informative and compatibility
            public string DisplayName;
            public CartridgeSize CartridgeSize;
            
            // Weapon Output
            public float FireRate; // In RPM
            public List<FireMode> FireModes;
            public float BulletCount; // For Shotgun Pellets
            
            #region // Weapon Performance
                // Weapon Ballistics
                public float BarrelLength; // Affects Muzzle Velocity
                public float ShotDeviation; // InAccuracy in MOA (Rounded to 3cm per 100m)
                    
                // Weapon Handling
                public float Ergonomics; // Affects handling and compensation effectiveness
                public float Weight; // Affects handling and movement speed
                
                public float Handling; // ADS, Reload, switch mode and swap speed
                public float Compensation; // Recenter time and effectiveness after firing
                // Weapon Reliability
                public float Durability; // Affects other reliability stats (Questioning if I should have part durability)
                public float Reliability; // Affects base chance to Jam
                public float Cooling; // Affects overheating rate
                
                public float Overheat; // Affects cook off chance
                public Malfunction Malfunction; // Prevents Firing
                
            #endregion
            // Visuals
            public GameObject Model;
            
            // Transforms
            public Transform AimPoint; // REMOVE THIS IF ADDING SIGHTS
            public Transform Muzzle; // Bullet and particle effect spawn
            
            // Attachments
            public Magazine Mag; // Currently loaded magazine
            // Add Sights, Barrels, Foregrips, Handguards, Stocks
            
            // Bools
            public bool OpenBolt; // Doesn't store round in chamber
            public bool CanFire; // Updated by shot cooldown
            
            public AmmoType ChamberedRound; // Currently loaded round
        #endregion
        
        public Weapon(WeaponData baseData, GameObject model, Magazine magazine)
        {
            _baseData = baseData;
            DisplayName = baseData.displayName;
            FireRate = baseData.fireRate;
            CartridgeSize = baseData.cartridgeSize;
            FireModes = baseData.fireModes;

            this.Model = model;
            AimPoint = Helper.FindChildWithTag(model,"AimPoint").transform;
            Muzzle = Helper.FindChildWithTag(model,"Muzzle").transform;
            
            Mag = magazine;
        }
    }
}
