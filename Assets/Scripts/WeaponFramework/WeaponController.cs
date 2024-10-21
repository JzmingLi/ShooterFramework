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
        
        public Vector3 idlePosition;
        public Vector3 aimPosition;
        
        [SerializeField] private float aimSpeed;

        private Transform _viewpos;
        private WeaponStateMachine _stateMachine;
        private Weapon _weapon;
        
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
            _stateMachine.Update();
        }
        
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
        
        public void UpdateViewmodelPosition(Vector3 newPosition)
        {
            _viewpos.localPosition = Vector3.Lerp(_viewpos.localPosition, newPosition, Time.deltaTime * aimSpeed);
        }
    }
}
