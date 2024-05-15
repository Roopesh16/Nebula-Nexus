using NebulaNexus.Bullet;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyService
    {
        private EnemyController enemyController;
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        private Transform bulletParent;

        public BulletView BulletPrefab => bulletPrefab;
        public BulletScriptableObject BulletSO => bulletSO;
        public Transform BulletParent => bulletParent;

        public EnemyService(EnemyView enemyView, EnemyScriptableObject enemyScriptableObject,
                            BulletScriptableObject bulletSO, BulletView bulletPrefab, Transform bulletParent)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
            this.bulletParent = bulletParent;
            EnemyController enemyController = new EnemyController(enemyView, enemyScriptableObject);
        }
    }
}
