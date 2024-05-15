using System;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class BulletService
    {
        private BulletPool bulletPool;

        public BulletService(BulletView bulletPrefab)
        {
            bulletPool = new BulletPool(bulletPrefab);
        }

        public BulletController GetBullet(BulletType bulletType, BulletScriptableObject bulletSO, Transform parent)
        {
            switch (bulletType)
            {
                case BulletType.PLAYER: return bulletPool.GetBullet<PlayerBullet>(bulletSO, parent);

                case BulletType.ENEMY: return bulletPool.GetBullet<EnemyBullet>(bulletSO, parent);
            }

            throw new NotSupportedException("Wrong subtype!");
        }

        public void ReturnBullets(BulletController returnBullet) => bulletPool.ReturnItem(returnBullet);
    }
}