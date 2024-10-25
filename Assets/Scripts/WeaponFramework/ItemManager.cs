using System;
using System.Collections.Generic;
using SingletonPattern;
using UnityEngine;
using WeaponFramework.Factories;

namespace WeaponFramework
{
    public class ItemManager : Singleton<ItemManager>
    {
        [SerializeField] public List<WeaponData> weapons;
        [SerializeField] public List<GameObject> sights;
        [SerializeField] public List<MagData> mags;
        [SerializeField] public List<AmmoType> ammoTypes;
        [SerializeField] public GameObject alertPrefab;
    }
}