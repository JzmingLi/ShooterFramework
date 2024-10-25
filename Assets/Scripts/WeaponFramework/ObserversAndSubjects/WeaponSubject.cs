using System;
using UnityEngine;

namespace WeaponFramework.ObserversAndSubjects
{
    public class WeaponSubject
    {
        public event Action OutofAmmo;
        public event Action Reloaded;

        public void NotifyOutofAmmo()
        {
            Debug.Log("Out of Ammo");
            OutofAmmo?.Invoke();
        }

        public void NotifyReloaded()
        {
            Reloaded?.Invoke();
        }
    }
}