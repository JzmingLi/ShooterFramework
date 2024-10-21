using UnityEngine;
using WeaponFramework;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Weapon")]
public class WeaponData : ScriptableObject
{
    public string displayName;
    public float fireRate;
    public CartridgeSize cartridgeSize;
    public FireMode fireMode;
    public GameObject modelPrefab;
}
