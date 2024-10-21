using UnityEngine;
using WeaponFramework;

[CreateAssetMenu(fileName = "AmmoType", menuName = "Scriptable Objects/AmmoType")]
public class AmmoType : ScriptableObject
{
    public CartridgeSize cartridgeSize;
    public GameObject projectilePrefab;
    // In the future add stuff like damage and velocity
}
