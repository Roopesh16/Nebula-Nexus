using NebulaNexus.Utilities;

namespace NebulaNexus.Bullet
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        protected override BulletController CreateItem()
        {
            return new BulletController(bulletPrefab, bulletSO);
        }
    }
}