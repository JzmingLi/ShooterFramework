using System;
using System.Numerics;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using WeaponFramework.Factories;
using WeaponFramework.ObserversAndSubjects;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using RecoilSystemDLL;

namespace WeaponFramework
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject viewmodel;
        public Transform aimPoint;
        
        // Viewmodel Offsets
        public Vector3 idleOffset;
        public Quaternion idleRotation;
        public Vector3 aimOffset;
        
        // Positions for firing positions
        public Vector3 sightPosition;

        private RecoilSystem _recoilSystem;
        
        [SerializeField] private float aimSpeed;

        private Transform _viewpos;
        private WeaponStateMachine _stateMachine;
        public Weapon Weapon {  get; private set; }

        private float _timeUntilNextShoot;
        private bool _outOfAmmo;
        public WeaponSubject Subject;

        public bool UseFlyweight;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _viewpos = viewmodel.GetComponent<Transform>(); 
            _viewpos.SetParent(mainCamera.transform, false);
            
            _stateMachine = new WeaponStateMachine(this);
            _stateMachine.Initialize(_stateMachine.IdleState);

            Subject = new WeaponSubject();
            
            idleRotation = Quaternion.identity;
            
            _recoilSystem = viewmodel.AddComponent<RecoilSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Weapon != null) _stateMachine.Update();
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
            if (Weapon != null)
            {
                if (_timeUntilNextShoot == 0)
                {
                    AmmoType round = Weapon.Mag.TakeRound();
                    if (round)
                    {
                        if (UseFlyweight) ProjectileFactory.SpawnFlyweightBullet(round, Weapon, 5);
                        else ProjectileFactory.SpawnBullet(round, Weapon, 5);
                        _timeUntilNextShoot = 1 / (Weapon.FireRate / 60);
                        _recoilSystem.ResetRecoilTime();
                    }
                    else
                    {
                        if (!_outOfAmmo)
                        {
                            _outOfAmmo = true;
                            Subject.NotifyOutofAmmo();
                        }
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
            _viewpos.localPosition = Vector3.Lerp(_viewpos.localPosition, newPosition + _recoilSystem._recoilPositionOffset, Time.deltaTime * aimSpeed);
            _viewpos.localRotation = Quaternion.Lerp(_viewpos.localRotation, _recoilSystem._recoilRotationOffset, Time.deltaTime * aimSpeed);
        }

        public void SwitchWeapon(Weapon weapon)
        {
            Weapon = weapon;
            /*
            foreach (Transform child in viewmodel.transform)
            {
                Destroy(child.gameObject);
            }
            */
            if (weapon != null)
            {
                aimPoint = weapon.AimPoint;
                Weapon.Model.transform.SetParent(viewmodel.transform, false);
                sightPosition = -viewmodel.transform.InverseTransformPoint(aimPoint.position);
                _outOfAmmo = false;
                Subject.NotifyReloaded();
            }
            else
            {

                Debug.Log("Equipped Nothing");
            }
        }
    }
}
