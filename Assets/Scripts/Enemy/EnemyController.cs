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
            stateMachine.ChangeState(StateMachine.States.IDLE);
        }

        public void Update()
        {
            stateMachine?.Update();
        }

        public void ShootBullet()
        {
            if (rateOfFire < enemySO.RateOfFire)
                rateOfFire += Time.deltaTime;
            else
            {
                BulletController bullet = GameService.Instance.BulletService.GetBullet(BulletType.ENEMY,
                                                       enemyService.BulletSO, enemyService.BulletParent);
                bullet.ConfigureBullet(enemyView.SpawnPosition);
                rateOfFire = 0f;
            }
        }
    }
}