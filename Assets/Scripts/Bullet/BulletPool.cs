using NebulaNexus.Utilities;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        private Transform parent;

        public BulletPool(BulletView bulletPrefab)
        {
            this.bulletPrefab = bulletPrefab;
        }

        /// <summary>
        /// Create Bullet Pool 
        /// </summary>
        /// <param name="bulletPrefab"></param>
        /// <param name="bulletSO"></param>
        /// <param name="parent"></param>
        public BulletController GetBullet(BulletScriptableObject bulletSO, Transform parent)
        {
            this.bulletSO = bulletSO;
            this.parent = parent;
            return GetItem();
        }

        /// <summary>
        /// Create Bullet Controller object
        /// </summary>
        /// <returns>Bullet Controller</returns>
        protected override BulletController CreateItem()
        {
            return new BulletController(bulletPrefab, bulletSO, parent);
        }
    }
}