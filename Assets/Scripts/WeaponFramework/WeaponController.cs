using System;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace WeaponFramework
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject viewmodel;
        public Transform aimPoint;
        
        public Vector3 idleOffset;
        public Vector3 aimOffset;
        public Vector3 sightPosition;
        
        [SerializeField] private float aimSpeed;

        private Transform _viewpos;
        private WeaponStateMachine _stateMachine;
        private Weapon _weapon;

        private float _timeUntilNextShoot;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _viewpos = viewmodel.GetComponent<Transform>(); 
            _viewpos.SetParent(mainCamera.transform, false);
            
            _stateMachine = new WeaponStateMachine(this);
            _stateMachine.Initialize(_stateMachine.IdleState);
        }

        // Update is called once per frame
        void Update()
        {
            if(_weapon != null) _stateMachine.Update();
        }
        
        // Commands
        public void ToggleAim()
        {
            if (_stateMachine.CurrentState == _stateMachine.IdleState)
            {
                _stateMachine.Transition(_stateMachine.AimState);
            }
            else
            {
                _stateMachine.Transition(_stateMachine.IdleState);
            }
        }

        public void Shoot()
        {
            if (_weapon != null)
            {
                if (_timeUntilNextShoot == 0)
                {
                    AmmoType round = _weapon.Mag.TakeRound();
                    if (round)
                    {
                        GameObject bullet = Instantiate(round.projectilePrefab, _weapon.Muzzle.position, mainCamera.transform.rotation);
                        bullet.GetComponent<Rigidbody>().linearVelocity = _weapon.Muzzle.transform.forward * 50f;
                        Destroy(bullet, 5f);
                        _timeUntilNextShoot = 1 / (_weapon.FireRate / 60);
                    }
                }
                else
                {
                    _timeUntilNextShoot -= Time.deltaTime;
                    if (_timeUntilNextShoot < 0) _timeUntilNextShoot = 0;
                }
            }
        }
        
        public void UpdateViewmodelPosition(Vector3 newPosition)
        {
            _viewpos.localPosition = Vector3.Lerp(_viewpos.localPosition, newPosition, Time.deltaTime * aimSpeed);
        }
        
        // For now basically throws current weapon into limbo for garbage colletion
        public void SwitchWeapon(Weapon weapon)
        {
            _weapon = weapon;
            foreach (Transform child in viewmodel.transform)
            {
                Destroy(child.gameObject);
            }
            aimPoint = weapon.AimPoint;
            _weapon.Model.transform.SetParent(viewmodel.transform, false);
            sightPosition = -viewmodel.transform.InverseTransformPoint(aimPoint.position);
        }
    }
}
