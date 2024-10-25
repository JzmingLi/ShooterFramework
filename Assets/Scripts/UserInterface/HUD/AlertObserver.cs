using System;
using TMPro;
using UnityEngine;
using WeaponFramework;
using WeaponFramework.ObserversAndSubjects;

namespace UserInterface.HUD
{
    public class AlertObserver : MonoBehaviour
    {
        [SerializeField] private WeaponController weaponController;
        private WeaponSubject _subject;

        private void OutofAmmo()
        {
            Debug.Log("Out of Ammo, Displaying to hud");
            HUDManager.Instance.Alert("Out of Ammo");
        }

        private void Reloaded()
        {
            HUDManager.Instance.Alert("");
        }
        private void Start()
        {
            _subject = weaponController.Subject;
            if (_subject != null)
            {
                _subject.OutofAmmo += OutofAmmo;
                _subject.Reloaded += Reloaded;
            }
        }

        private void OnDestroy()
        {
            if (_subject != null)
            {
                _subject.OutofAmmo -= OutofAmmo;
                _subject.Reloaded -= Reloaded;
            }
        }
    }
}