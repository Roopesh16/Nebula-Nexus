using System.Collections;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class BulletService
    {
        private BulletPool bulletPool;

        public BulletService()
        {
            bulletPool = new BulletPool();
        }

        public BulletController GetBullet(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent)
        {
            return bulletPool.GetBullet(bulletPrefab, bulletSO, parent);
        }

        public void ReturnBullet(BulletController returnBullet) => bulletPool.ReturnItem(returnBullet);
    }
}