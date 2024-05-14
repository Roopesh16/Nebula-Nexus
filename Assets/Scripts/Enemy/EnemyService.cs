using NebulaNexus.Bullet;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyService
    {
        private EnemyController enemyController;
        private BulletPool bulletPool;

        public EnemyService(EnemyView enemyView, EnemyScriptableObject enemyScriptableObject,
                            BulletScriptableObject bulletSO, BulletView bulletPrefab, Transform parent)
        {
            EnemyController enemyController = new EnemyController(enemyView, enemyScriptableObject);
            BulletPool bulletPool = new BulletPool(bulletPrefab, bulletSO, parent);
        }

        public BulletController GetBullet() => bulletPool.GetItem();

        public void ReturnBullet(BulletController returnBullet) => bulletPool.ReturnItem(returnBullet);
    }
}
