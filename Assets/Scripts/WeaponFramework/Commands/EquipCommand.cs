using CommandPattern;
using UnityEditor;
using UnityEngine;

namespace WeaponFramework.Commands
{
    public class EquipCommand : ICommand
    {
        private Weapon _oldWeapon;
        private GameObject _oldWeaponModel;
        private Weapon _newWeapon;
        WeaponController _controller;

        public EquipCommand(Weapon weapon, WeaponController controller)
        {
            _oldWeapon = controller.Weapon;
            if (controller.Weapon != null)
            {
                _oldWeaponModel = controller.Weapon.Model;
            }
            _newWeapon = weapon;
            _controller = controller;

            if (_oldWeaponModel != null)
            {
                _oldWeaponModel.SetActive(false);
            }
        }
        public void Execute()
        {
            _controller.SwitchWeapon(_newWeapon);
        }

        public void Undo()
        {
            if(_oldWeaponModel) _oldWeaponModel.SetActive(true);
            _controller.SwitchWeapon(_oldWeapon);
            Object.Destroy(_newWeapon.Model);
        }

        public void ClearData()
        {
            Object.Destroy(_oldWeaponModel);
        }
    }
}