using NebulaNexus.Interfaces;
using System.Collections;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyView : MonoBehaviour, IDamage
    {
        [SerializeField] private Transform spawnPosition;
        private EnemyController enemyController;

        public Transform SpawnPosition => spawnPosition;

        public void SetController(EnemyController enemyController) => this.enemyController = enemyController;

        private void Update() => enemyController?.Update();

        public void DecreaseHealth(int damage) => enemyController.DecreaseHealth(damage);

    }
}