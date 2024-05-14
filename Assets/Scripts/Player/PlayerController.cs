using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerScriptableObject playerSO;

        /// <summary>
        /// Initialize Player controller
        /// </summary>
        /// <param name="playerView"></param>
        /// <param name="playerSO"></param>
        public PlayerController(PlayerView playerView, PlayerScriptableObject playerSO)
        {
            this.playerView = playerView;
            this.playerSO = playerSO;
            playerView.SetController(this);
        }

        /// <summary>
        /// Move player based on its direction
        /// </summary>
        /// <param name="direction"></param>
        public void MovePlayer(Direction direction)
        {
            if (direction == Direction.LEFT)
                playerView.transform.Translate(-playerView.transform.right * playerSO.moveSpeed * Time.deltaTime);
            else
                playerView.transform.Translate(playerView.transform.right * playerSO.moveSpeed * Time.deltaTime);
        }
    }
}