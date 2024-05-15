using NebulaNexus.Enemy.States;
using NebulaNexus.Enemy.StateMachine;

namespace NebulaNexus.Enemy
{
    public class EnemyStateMachine : GenericStateMachine<EnemyController>
    {
        public EnemyStateMachine(EnemyController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            states.Add(StateMachine.States.IDLE, new IdleState());
            states.Add(StateMachine.States.SHOOTING, new ShootingState());
            states.Add(StateMachine.States.MOVEMENT, new MovementState());
        }
    }
}