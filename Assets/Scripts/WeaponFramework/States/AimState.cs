using UnityEngine;
using WeaponFramework;

namespace StatePattern
{
    public class AimState : IState
    {
        private WeaponController _weapon;
        private Vector3 _aimPosition;

        public AimState(WeaponController weapon)
        {
            _weapon = weapon;
        }

        public void Enter()
        {
        }

        public void Update()
        {
            _aimPosition = _weapon.sightPosition + _weapon.aimOffset;
            _weapon.UpdateViewmodelPosition(_aimPosition);
        }

        public void Exit()
        {
        
        }
    }
}
