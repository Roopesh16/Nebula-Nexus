using NebulaNexus.Utilities;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        private Transform parent;

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
            this.parent = parent;
        }

        protected override BulletController CreateItem()
        {
            return new BulletController(bulletPrefab, bulletSO, parent);
        }
    }
}