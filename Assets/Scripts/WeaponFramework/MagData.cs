using UnityEngine;
using WeaponFramework;

[CreateAssetMenu(fileName = "MagData", menuName = "Scriptable Objects/MagData")]
public class MagData : ScriptableObject
{
    public string displayName;
    public int maxCapacity;
    public CartridgeSize cartridgeSize;
    public GameObject modelPrefab;
}
