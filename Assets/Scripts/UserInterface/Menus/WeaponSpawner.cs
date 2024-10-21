using System;
using System.Collections.Generic;
using CommandPattern;
using UnityEngine;
using WeaponFramework.Factories;
using HelperClasses;
using TMPro;
using WeaponFramework;
using WeaponFramework.Commands;

namespace UserInterface.Menus
{
    public class WeaponSpawner : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown weaponDropdown;
        [SerializeField] private TMP_Dropdown sightDropdown;
        [SerializeField] private TMP_Dropdown magDropdown;

        [SerializeField] private Transform weaponPreviewPosition;
        [SerializeField] private WeaponController player;
        
        private GameObject _weaponPreview;
        private GameObject _sightPreview;
        private GameObject _magPreview;
        private ItemManager _itemManager;

        private void Awake()
        {
            _itemManager = ItemManager.Instance;
        }

        private void Start()
        {
           MakeOptionsFromList();
        }

        void MakeOptionsFromList()
        {
            weaponDropdown.ClearOptions();
            List<string> weaponOptions = new List<string>();
            weaponOptions.Add("Not Chosen");
            foreach (WeaponData weapon in _itemManager.weapons)
            {
                weaponOptions.Add(weapon.displayName);
            }
            weaponDropdown.AddOptions(weaponOptions);
            
            sightDropdown.ClearOptions();
            List<string> sightOptions = new List<string>();
            sightOptions.Add("Not Chosen");
            foreach (GameObject sight in _itemManager.sights)
            {
                sightOptions.Add(sight.name);
            }
            sightDropdown.AddOptions(sightOptions);
            
            magDropdown.ClearOptions();
            List<string> magOptions = new List<string>();
            magOptions.Add("Not Chosen");
            foreach (MagData mag in _itemManager.mags)
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
                _weaponPreview = Instantiate(_itemManager.weapons[index].modelPrefab, weaponPreviewPosition);
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
                    _sightPreview = Instantiate(_itemManager.sights[index], sightPos.transform);
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
                    _magPreview = Instantiate(_itemManager.mags[index].modelPrefab, magPos.transform);
                    Helper.SetLayerRecursively(_magPreview, "Preview", "Default");
                }
            }
            else if (_magPreview != null) Destroy(_magPreview);
        }

        // For now directly assembles weapons and places it into the weapon controller
        public void SpawnWeapon()
        {
            if (!(weaponDropdown.value == 0 || sightDropdown.value == 0 || magDropdown.value == 0))
            {
                GameObject model = Instantiate(_weaponPreview);
                Helper.SetLayerRecursively(model, "Default", "Preview");
                Weapon weapon = WeaponFactory.AssembleWeapon(weaponDropdown.value - 1, magDropdown.value - 1, model);
                //player.SwitchWeapon(weapon);
                EquipCommand command = new EquipCommand(weapon, player);
                CommandInvoker.ExecuteCommand(command);
            }
        }

        public void Undo()
        {
            CommandInvoker.UndoCommand();
        }
    }
}