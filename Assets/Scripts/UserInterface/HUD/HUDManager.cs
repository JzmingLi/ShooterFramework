using System;
using SingletonPattern;
using TMPro;
using UnityEngine;
using UserInterface.Menus;
using WeaponFramework.Factories;

namespace UserInterface.HUD
{
    public class HUDManager : Singleton<HUDManager>
    {
        [SerializeField] private WeaponSpawner weaponSpawner;
        [SerializeField] private GameObject alertPos;
        private void Start()
        {
            weaponSpawner.gameObject.SetActive(false);
        }

        public void ShowWeaponSpawner()
        {
            weaponSpawner.gameObject.SetActive(true);
        }

        public void CloseWeaponSpawner()
        {
            weaponSpawner.gameObject.SetActive(false);
        }

        public void Alert(string message)
        {
            AlertFactory.SpawnAlertPopup(message, alertPos.transform);
        }
        
    }
}