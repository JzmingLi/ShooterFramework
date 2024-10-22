using System;
using SingletonPattern;
using TMPro;
using UnityEngine;
using UserInterface.Menus;

namespace UserInterface.HUD
{
    public class HUDManager : Singleton<HUDManager>
    {
        [SerializeField] private WeaponSpawner weaponSpawner;
        [SerializeField] private TextMeshProUGUI alert;
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
            alert.text = message;
        }
        
    }
}