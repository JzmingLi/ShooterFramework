using System;
using System.Collections.Generic;
using UnityEngine;
using WeaponFramework.Factories;
using HelperClasses;
using TMPro;

namespace UserInterface.Menus
{
    public class WeaponSpawner : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown weaponDropdown;
        [SerializeField] private TMP_Dropdown sightDropdown;
        [SerializeField] private TMP_Dropdown magDropdown;

        [SerializeField] private Transform weaponPreviewPosition;

        private GameObject _weaponPreview;
        private GameObject _sightPreview;
        private GameObject _magPreview;
        
        private void Start()
        {
           MakeOptionsFromList();
        }

        void MakeOptionsFromList()
        {
            weaponDropdown.ClearOptions();
            List<string> weaponOptions = new List<string>();
            weaponOptions.Add("Not Chosen");
            foreach (WeaponData weapon in WeaponFactory.Weapons)
            {
                weaponOptions.Add(weapon.displayName);
            }
            weaponDropdown.AddOptions(weaponOptions);
            
            sightDropdown.ClearOptions();
            List<string> sightOptions = new List<string>();
            sightOptions.Add("Not Chosen");
            foreach (GameObject sight in WeaponFactory.SightPrefabs)
            {
                sightOptions.Add(sight.name);
            }
            sightDropdown.AddOptions(sightOptions);
            
            magDropdown.ClearOptions();
            List<string> magOptions = new List<string>();
            magOptions.Add("Not Chosen");
            foreach (MagData mag in WeaponFactory.Mags)
            {
                magOptions.Add(mag.displayName);
            }
            magDropdown.AddOptions(magOptions);
        }

        public void SwitchWeapons(int option)
        {
            if (option != 0)
            {
                int index = option - 1;
                if (_weaponPreview != null) Destroy(_weaponPreview);
                Debug.Log("Showing Weapon Preview");
                _weaponPreview = Instantiate(WeaponFactory.Weapons[index].modelPrefab, weaponPreviewPosition);
                Helper.SetLayerRecursively(_weaponPreview, "Preview", "Default");
            }
            else if (_weaponPreview != null) Destroy(_weaponPreview);
        }

        public void SwitchSights(int option)
        {
            if (option != 0)
            {
                int index = option - 1;
                if (_weaponPreview != null)
                {
                    if (_sightPreview != null) Destroy(_sightPreview);
                    GameObject sightPos = Helper.FindChildWithTag(_weaponPreview, "SightAttachmentPoint");
                    _sightPreview = Instantiate(WeaponFactory.SightPrefabs[index], sightPos.transform);
                    Helper.SetLayerRecursively(_sightPreview, "Preview", "Default");
                }
            }
            else if (_sightPreview != null) Destroy(_sightPreview);
        }
        
        public void SwitchMags(int option)
        {
            if (option != 0)
            {
                int index = option - 1;
                if (_weaponPreview != null)
                {
                    if (_magPreview != null) Destroy(_magPreview);
                    GameObject magPos = Helper.FindChildWithTag(_weaponPreview, "MagAttachmentPoint");
                    _magPreview = Instantiate(WeaponFactory.Mags[index].modelPrefab, magPos.transform);
                    Helper.SetLayerRecursively(_magPreview, "Preview", "Default");
                }
            }
            else if (_magPreview != null) Destroy(_magPreview);
        }

        public void SpawnWeapon()
        {
            
        }
    }
}