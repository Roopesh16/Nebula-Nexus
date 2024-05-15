using NebulaNexus.Utilities;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        private Transform parent;

        /// <summary>
        /// Create Bullet Pool 
        /// </summary>
        /// <param name="bulletPrefab"></param>
        /// <param name="bulletSO"></param>
        /// <param name="parent"></param>
        public BulletController GetBullet(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent)
        {
            this.bulletPrefab = bulletPrefab;
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