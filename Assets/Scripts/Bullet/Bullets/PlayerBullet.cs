using System.Collections;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class PlayerBullet : BulletController
    {
        public PlayerBullet(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent) :
            base(bulletPrefab, bulletSO, parent)
        { }

        public override void MoveBullet()
        {
            base.MoveBullet();
        }

        public override void OnTrigger(GameObject other)
        {
            base.OnTrigger(other);
        }
    }
}