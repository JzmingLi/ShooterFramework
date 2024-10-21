using UnityEngine;
using WeaponFramework;

[CreateAssetMenu(fileName = "AmmoType", menuName = "Scriptable Objects/AmmoType")]
public class AmmoType : ScriptableObject
{
    public CartridgeSize cartridgeSize;
    
    // In the future add stuff like damage and velocity
}
