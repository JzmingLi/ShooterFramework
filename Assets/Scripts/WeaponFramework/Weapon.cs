using HelperClasses;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WeaponFramework
{
    public class Weapon
    {
        private WeaponData _baseData;
        
        public string DisplayName;
        public float FireRate;
        public CartridgeSize CartridgeSize;
        public FireMode FireMode;
        public GameObject Model;
        
        public Transform AimPoint;
        public Transform Muzzle;
        public Magazine Mag;

        public Weapon(WeaponData baseData, GameObject model, Magazine magazine)
        {
            _baseData = baseData;
            DisplayName = baseData.displayName;
            FireRate = baseData.fireRate;
            CartridgeSize = baseData.cartridgeSize;
            FireMode = baseData.fireMode;

            this.Model = model;
            AimPoint = Helper.FindChildWithTag(model,"AimPoint").transform;
            Muzzle = Helper.FindChildWithTag(model,"Muzzle").transform;
            
            Mag = magazine;
        }
    }
}
