﻿using NebulaNexus.Enemy;
using NebulaNexus.Player;
using System.Collections;
using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class EnemyBullet : BulletController
    {
        public EnemyBullet(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent) :
            base(bulletPrefab, bulletSO, parent)
        { }

        public override void ConfigureBullet(Transform spawnPosition)
        {
            bulletView.transform.localRotation = spawnPosition.rotation;
            bulletView.gameObject.layer = 9 << bulletSO.BulletLayer;
            bulletView.gameObject.tag = bulletSO.BulletTag;
            base.ConfigureBullet(spawnPosition);

        }

        public override void MoveBullet()
        {
            bulletView.transform.Translate(bulletSO.MoveSpeed * Time.deltaTime * -bulletView.transform.up);
        }

        public override void OnTrigger(GameObject other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerView>().DecreaseHealth(bulletSO.Damage);
                base.OnTrigger(other);
            }
        }
    }
}