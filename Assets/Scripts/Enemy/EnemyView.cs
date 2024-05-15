using System.Collections;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosition;
        private EnemyController enemyController;

        public Transform SpawnPosition => spawnPosition;

        public void SetController(EnemyController enemyController) => this.enemyController = enemyController;

        private void Update()
        {
            enemyController.ShootBullet();
        }

    }
}