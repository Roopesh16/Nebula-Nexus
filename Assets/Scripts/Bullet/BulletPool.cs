using NebulaNexus.Utilities;
using UnityEngine;
using System;

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
        public BulletController GetBullet<U>(BulletScriptableObject bulletSO, Transform parent) where U : BulletController
        {
            this.bulletSO = bulletSO;
            this.parent = parent;
            return GetItem<U>();
        }

        /// <summary>
        /// Create Bullet Controller object
        /// </summary>
        /// <returns>Bullet Controller</returns>
        protected override BulletController CreateItem<U>() where U : class
        {
            if (typeof(U) == typeof(PlayerBullet))
                return new PlayerBullet(bulletPrefab, bulletSO, parent);
            else if (typeof(U) == typeof(EnemyBullet))
                return new EnemyBullet(bulletPrefab, bulletSO, parent);

            throw new NotSupportedException("Not correct sub type!");
        }
    }
}