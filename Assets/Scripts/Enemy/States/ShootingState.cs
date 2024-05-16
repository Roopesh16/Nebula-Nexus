using NebulaNexus.Bullet;
using NebulaNexus.Enemy.StateMachine;
using NebulaNexus.Main;
using UnityEngine;

namespace NebulaNexus.Enemy.States
{
    public class ShootingState : IState
    {
        public EnemyController Owner { get; set; }
        private float shootTimer;
        private float rateOfFire = 0f;
        private EnemyService enemyService => GameService.Instance.EnemyService;

        public void OnStateEnter()
        {
            shootTimer = 0f;
            rateOfFire = 0f;
        }

        public void Update()
        {
            if (shootTimer < Owner.Data.MaxShootTime)
            {
                ShootBullet();
                shootTimer += Time.deltaTime;
            }
            else
                Owner.StateMachine.ChangeState(StateMachine.States.MOVEMENT);
        }

        public void OnStateExit()
        {
            shootTimer = 0f;
            rateOfFire = 0f;
        }

        private void ShootBullet()
        {
            if (rateOfFire < Owner.Data.RateOfFire)
                rateOfFire += Time.deltaTime;
            else
            {
                for (int i = 0; i < Owner.Enemy.SpawnPositions.Count; i++)
                {
                    BulletController bullet = GameService.Instance.BulletService.GetBullet(BulletType.ENEMY,
                                                           enemyService.BulletSO, enemyService.BulletParent);
                    bullet.ConfigureBullet(Owner.Enemy.SpawnPositions[i]);
                    rateOfFire = 0f;
                }
            }
        }


    }
}