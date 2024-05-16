using NebulaNexus.Bullet;
using NebulaNexus.Main;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyController
    {
        private EnemyView enemyView;
        private EnemyScriptableObject enemySO;

        private EnemyStateMachine stateMachine;

        public EnemyView Enemy => enemyView;
        public EnemyStateMachine StateMachine => stateMachine;
        public EnemyScriptableObject Data => enemySO;

        public EnemyController(EnemyView enemyView, EnemyScriptableObject enemySO)
        {
            this.enemyView = enemyView;
            this.enemyView.SetController(this);
            this.enemySO = enemySO;
            stateMachine = new(this);
            SubscribeEvents();
        }

        private void SubscribeEvents() => GameService.Instance.EventService.OnPlayClick.AddListener(SetToIdle);

        public void Update()
        {
            if (GameService.Instance.GameManager.GetGameState() == GameStates.PLAY)
                stateMachine?.Update();
        }

        private void SetToIdle() => stateMachine.ChangeState(NebulaNexus.Enemy.StateMachine.States.IDLE);
    }
}