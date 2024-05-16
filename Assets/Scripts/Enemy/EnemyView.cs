using System.Collections.Generic;
using NebulaNexus.Interfaces;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    public class EnemyView : MonoBehaviour, IDamage
    {
        [SerializeField] private List<Transform> spawnPositions = new();
        private EnemyController enemyController;

        public List<Transform> SpawnPositions => spawnPositions;

        public void SetController(EnemyController enemyController) => this.enemyController = enemyController;

        private void Update() => enemyController?.Update();

        public void DecreaseHealth(int damage) => enemyController.DecreaseHealth(damage);

    }
}