using UnityEngine;
using NebulaNexus.Enemy.StateMachine;
using NebulaNexus.Main;

namespace NebulaNexus.Enemy.States
{
    public class IdleState : IState
    {
        public EnemyController Owner { get; set; }

        public void OnStateEnter()
        {
            Owner.Enemy.transform.position = Owner.Data.StartPostion;
        }

        public void Update()
        {
            if (Vector2.Distance(Owner.Enemy.transform.position, Owner.Data.EndPosition) > Owner.Data.MinDistance)
            {
                Owner.Enemy.transform.Translate(Owner.Data.DownSpeed * Time.deltaTime * -Owner.Enemy.transform.up);
            }
            else
            {
                Owner.Enemy.transform.position = Owner.Data.EndPosition;
                Owner.StateMachine.ChangeState(StateMachine.States.SHOOTING);
            }
        }

        public void OnStateExit()
        {
            GameService.Instance.EventService.OnEnemyActive.Invoke();
        }
    }
}