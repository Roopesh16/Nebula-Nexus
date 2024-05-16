using NebulaNexus.Enemy;
using System.Collections;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class PlayerBullet : BulletController
    {
        public PlayerBullet(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent) :
            base(bulletPrefab, bulletSO, parent)
        { }

        public override void ConfigureBullet(Transform spawnPosition)
        {
            bulletView.transform.localRotation = spawnPosition.rotation;
            bulletView.gameObject.layer = 1 << bulletSO.BulletLayer;
            bulletView.gameObject.tag = bulletSO.BulletTag;
            base.ConfigureBullet(spawnPosition);
        }

        public override void MoveBullet()
        {
            base.MoveBullet();
        }

        public override void OnTrigger(GameObject other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyView>().DecreaseHealth(bulletSO.Damage);
            }
        }
    }
}