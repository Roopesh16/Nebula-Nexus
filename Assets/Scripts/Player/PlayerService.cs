namespace NebulaNexus.Player
{
    public class PlayerService
    {
        private PlayerView playerView;
        private PlayerScriptableObject playerSO;
        private PlayerController playerController;

        /// <summary>
        /// Initialize Player Service
        /// </summary>
        /// <param name="playerView"></param>
        /// <param name="playerSO"></param>
        public PlayerService(PlayerView playerView, PlayerScriptableObject playerSO)
        {
            playerController = new PlayerController(playerView, playerSO);
        }
    }
}
