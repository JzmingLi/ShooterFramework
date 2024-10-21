using UnityEngine;
using WeaponFramework;

namespace StatePattern
{
    public class IdleState : IState
    {
        private WeaponController _weapon;
        private Vector3 _idlePosition;
        
        public IdleState(WeaponController weapon)
        {
            _weapon = weapon;
        }
    
        public void Enter()
        {
            
        }

        public void Update()
        {
            _weapon.UpdateViewmodelPosition(_weapon.idleOffset);
        }

        public void Exit()
        {
        
        }
    }
}
