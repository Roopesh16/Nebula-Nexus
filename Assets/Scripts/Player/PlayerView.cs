using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;

        /// <summary>
        /// Set controller for Player view
        /// </summary>
        /// <param name="playerController"></param>
        public void SetController(PlayerController playerController) => this.playerController = playerController;

        /// <summary>
        /// Get player input for movement
        /// </summary>
        private void Update()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
                playerController.MovePlayer(Direction.RIGHT);
            if (Input.GetAxisRaw("Horizontal") < 0)
                playerController.MovePlayer(Direction.LEFT);
        }
    }
}