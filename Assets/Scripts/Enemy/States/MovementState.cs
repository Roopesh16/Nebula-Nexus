using NebulaNexus.Enemy.StateMachine;
using UnityEngine;

namespace NebulaNexus.Enemy.States
{

    public class MovementState : IState
    {
        public EnemyController Owner { get; set; }
        private float moveTimer;
        private float maxMoveTimer;
        private Vector2 currentPosition;
        private Vector2 destinationPosition;

        private const int MIN_VAL = 0;
        private const int MAX_VAL = 100;

        public void OnStateEnter()
        {
            moveTimer = 0f;
            currentPosition = Owner.Enemy.transform.position;
            destinationPosition = GetRandomDestination();
            maxMoveTimer = GetRandomMoveTime();
        }

        public void Update()
        {
            if (moveTimer < maxMoveTimer)
            {
                OscillateEnemy();
                moveTimer += Time.deltaTime;
            }
            else
                Owner.StateMachine.ChangeState(StateMachine.States.SHOOTING);
        }

        public void OnStateExit()
        {
            moveTimer = 0f;
        }

        private void OscillateEnemy()
        {
            Vector2 dir = currentPosition - destinationPosition;
            if (Vector2.Distance(Owner.Enemy.transform.position, destinationPosition) > Owner.Data.MinDistance)
            {
                Owner.Enemy.transform.Translate(Owner.Data.MoveSpeed * Time.deltaTime * dir);
            }
            else
            {
                currentPosition = destinationPosition;
                destinationPosition = Vector2.Distance(currentPosition, Owner.Data.LeftPosition) < Owner.Data.MinDistance ?
                                        Owner.Data.RightPosition : Owner.Data.LeftPosition;
            }
        }

        private Vector2 GetRandomDestination()
        {
            int rand = Random.Range(MIN_VAL, MAX_VAL);
            if (rand < ((MIN_VAL + MAX_VAL) / 2))
                return Owner.Data.LeftPosition;

            return Owner.Data.RightPosition;
        }

        private float GetRandomMoveTime()
        {
            return Random.Range(Owner.Data.MoveTimeRange.MinMoveTime, Owner.Data.MoveTimeRange.MaxMoveTime);
        }

    }
}