using TMPro;
using UnityEngine;
using WeaponFramework;

namespace UserInterface.HUD
{
    public class AlertObserver : MonoBehaviour
    {
        [SerializeField] private WeaponController subject;
        
        
        private void OutofAmmo()
        {
            HUDManager.Instance.Alert("Out of Ammo");
        }

        private void Reloaded()
        {
            HUDManager.Instance.Alert("");
        }
        private void Awake()
        {
            if (subject != null)
            {
                subject.OutofAmmo += OutofAmmo;
                subject.Reloaded += Reloaded;
            }
        }

        private void OnDestroy()
        {
            if (subject != null)
            {
                subject.OutofAmmo -= OutofAmmo;
                subject.Reloaded -= Reloaded;
            }
        }
    }
}