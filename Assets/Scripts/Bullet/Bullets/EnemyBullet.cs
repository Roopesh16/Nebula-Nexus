using System.Collections;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class EnemyBullet : BulletController
    {
        public EnemyBullet(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent) :
            base(bulletPrefab, bulletSO, parent)
        { }

        public override void MoveBullet()
        {
            bulletView.transform.Translate(bulletSO.moveSpeed * Time.deltaTime * -bulletView.transform.up);
        }

        public override void OnTrigger(GameObject other)
        {
            base.OnTrigger(other);
        }
    }
}