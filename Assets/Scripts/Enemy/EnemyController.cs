using NebulaNexus.Bullet;
using NebulaNexus.Main;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyController
    {
        private EnemyView enemyView;
        private EnemyScriptableObject enemySO;
        private float rateOfFire = 0f;

        private EnemyService enemyService => GameService.Instance.EnemyService;

        public EnemyController(EnemyView enemyView, EnemyScriptableObject enemySO)
        {
            this.enemyView = enemyView;
            this.enemyView.SetController(this);
            this.enemySO = enemySO;
        }

        public void ShootBullet()
        {
            if (rateOfFire < enemySO.RateOfFire)
                rateOfFire += Time.deltaTime;
            else
            {
                BulletController bullet = GameService.Instance.BulletService.GetBullet(enemyService.BulletPrefab,
                    enemyService.BulletSO, enemyService.BulletParent);
                bullet.ConfigureBullet(enemyView.SpawnPosition);
                rateOfFire = 0f;
            }
        }
    }
}