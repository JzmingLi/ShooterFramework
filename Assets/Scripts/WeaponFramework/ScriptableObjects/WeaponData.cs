using System.Collections.Generic;
using UnityEngine;

namespace WeaponFramework
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public string displayName;
        public float fireRate;
        public CartridgeSize cartridgeSize;
        public List<FireMode> fireModes;
        public GameObject modelPrefab;
    }
}
