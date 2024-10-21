using System;
using UnityEngine;
using UnityEngine.InputSystem;
using WeaponFramework;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset input;
        [SerializeField] private PlayerCamera playerCamera;
        
        private PlayerMovement _playerMovement;
        private WeaponController _weaponController;
        
        private void Awake()
        {
            input.Enable();
            
            playerCamera.Input = input;
            
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.Input = input;
            
            _weaponController = GetComponent<WeaponController>();   
        }
        
        //Replace with commands

        private void Update()
        {
            InputAction aim = input.FindActionMap("Player").FindAction("Aim");
            if (aim.triggered)
            {
                _weaponController.ToggleAim();
            }
        }
    }
}
