using System;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UserInterface.HUD;
using UserInterface.Menus;
using WeaponFramework;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset input;
        [SerializeField] private PlayerCamera playerCamera;
        
        private HUDManager _hudManager;
        private PlayerMovement _playerMovement;
        private WeaponController _weaponController;
        
        // Inputs
        private InputAction _aim;
        private InputAction _openMenu;
        private InputAction _closeMenu;
        private InputAction _shoot;
        
        private void Awake()
        {
            input.Enable();
            
            _hudManager = HUDManager.Instance;
            playerCamera.Input = input;
            
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.Input = input;
            
            _weaponController = GetComponent<WeaponController>();   
            
            _aim = input.FindActionMap("Player").FindAction("Aim");
            _shoot = input.FindActionMap("PLayer").FindAction("Attack");
            _openMenu = input.FindActionMap("Player").FindAction("OpenMenu");
            _closeMenu = input.FindActionMap("UI").FindAction("CloseMenu");
            
            input.FindActionMap("Player").Enable();
            input.FindActionMap("UI").Disable();
        }
        
        //Replace with commands

        private void Update()
        {
            if (_aim.triggered)
            {
                _weaponController.ToggleAim();
            }

            if (_openMenu.triggered)
            {
                Debug.Log("Menu Opened");
                Cursor.lockState = CursorLockMode.Confined;
                _hudManager.ShowWeaponSpawner();
                input.FindActionMap("Player").Disable();
                input.FindActionMap("UI").Enable();
                
            } 
            else if (_closeMenu.triggered)
            {
                Debug.Log("Menu Closed");
                Cursor.lockState = CursorLockMode.Locked;
                _hudManager.CloseWeaponSpawner();
                input.FindActionMap("Player").Enable();
                input.FindActionMap("UI").Disable();
            }

            if (_shoot.IsPressed())
            {
                _weaponController.Shoot();
            }
        }
    }
}
