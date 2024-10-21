﻿using System;
using System.Collections.Generic;
using UnityEngine;
using WeaponFramework.Factories;

namespace WeaponFramework
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private List<WeaponData> weapons;
        [SerializeField] private List<GameObject> sights;
        [SerializeField] private List<MagData> mags;

        private void Start()
        {
            WeaponFactory.UpdateLists(weapons,sights,mags);
        }
    }
}