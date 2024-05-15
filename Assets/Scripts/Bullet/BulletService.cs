using System.Collections;
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

        public BulletController GetBullet(BulletScriptableObject bulletSO, Transform parent)
        {
            return bulletPool.GetBullet(bulletSO, parent);
        }

        public void ReturnBullet(BulletController returnBullet) => bulletPool.ReturnItem(returnBullet);
    }
}