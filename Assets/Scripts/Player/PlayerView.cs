using NebulaNexus.Enemy;
using NebulaNexus.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerView : MonoBehaviour, IDamage
    {
        [Header("Default")]
        [SerializeField] private Transform spawnPosition;

        [Header("Double")]
        [SerializeField] private List<Transform> doubleSpawns = new();

        [Header("Multiple")]
        [SerializeField] private List<Transform> multipleSpawns = new();

        public Transform DefaultSpawn => spawnPosition;
        public List<Transform> DoubleSpawns => doubleSpawns;
        public List<Transform> MultipleSpawns => multipleSpawns;

        private PlayerController playerController;

        /// <summary>
        /// Set controller for Player view
        /// </summary>
        /// <param name="playerController"></param>
        public void SetController(PlayerController playerController) => this.playerController = playerController;

        /// <summary>
        /// Update to get move and shoot input
        /// </summary>
        private void Update()
        {
            MovementInput();
            ShootInput();
        }

        /// <summary>
        /// Get Move input from user
        /// </summary>
        private void MovementInput()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
                playerController.MovePlayer(Direction.RIGHT);
            if (Input.GetAxisRaw("Horizontal") < 0)
                playerController.MovePlayer(Direction.LEFT);
        }

        /// <summary>
        /// Get Shoot input from user
        /// </summary>
        private void ShootInput()
        {
            if (Input.GetMouseButton(0))
                playerController.ShootBullet();
        }

        public void DecreaseHealth(int damage) => playerController.DecreaseHealth(damage);

        private void OnTriggerEnter2D(Collider2D other) => playerController.OnTrigger(other.gameObject);
    }
}