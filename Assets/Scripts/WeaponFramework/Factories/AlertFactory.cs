using TMPro;
using UnityEngine;
using UserInterface.HUD;

namespace WeaponFramework.Factories
{
    public static class AlertFactory
    {
        private static ItemManager _itemManager = ItemManager.Instance;
        
        public static GameObject SpawnAlertPopup(string message, Transform position)
        {
            GameObject popup = Object.Instantiate(_itemManager.alertPrefab, position);
            popup.GetComponent<TextMeshProUGUI>().text = message;
            GameObject.Destroy(popup, 5);
            return popup;
        }
    }
}