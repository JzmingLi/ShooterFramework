using System;
using UnityEngine;
using UserInterface.Menus;

namespace UserInterface.HUD
{
    public class HUDManager : MonoBehaviour
    {
        [SerializeField] private WeaponSpawner weaponSpawner;

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
    }
}