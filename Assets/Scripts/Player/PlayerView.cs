﻿using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform spawnPosition;
        private PlayerController playerController;

        /// <summary>
        /// Set Player controller to view
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
                playerController.ShootBullet(spawnPosition);

        }
    }
}