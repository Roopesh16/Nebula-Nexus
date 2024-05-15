using NebulaNexus.Bullet;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyService
    {
        private EnemyController enemyController;
        private BulletScriptableObject bulletSO;
        private Transform bulletParent;

        public BulletScriptableObject BulletSO => bulletSO;
        public Transform BulletParent => bulletParent;

        public EnemyService(EnemyView enemyView, EnemyScriptableObject enemyScriptableObject,
                            BulletScriptableObject bulletSO, Transform bulletParent)
        {
            this.bulletSO = bulletSO;
            this.bulletParent = bulletParent;
            EnemyController enemyController = new EnemyController(enemyView, enemyScriptableObject);
        }
    }
}
