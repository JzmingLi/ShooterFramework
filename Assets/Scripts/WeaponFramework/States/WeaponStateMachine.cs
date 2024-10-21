using StatePattern;

namespace WeaponFramework
{
    public class WeaponStateMachine : StateMachine
    {
        public AimState AimState;
        public IdleState IdleState;

        public WeaponStateMachine(WeaponController weaponController)
        {
            AimState = new AimState(weaponController);
            IdleState = new IdleState(weaponController);
        }
    }
}
