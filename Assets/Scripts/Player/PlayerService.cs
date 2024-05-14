namespace NebulaNexus.Player
{
    public class PlayerService
    {
        private PlayerView playerView;
        private PlayerScriptableObject playerSO;
        private PlayerController playerController;

        public PlayerService(PlayerView playerView, PlayerScriptableObject playerSO)
        {
            playerController = new PlayerController(playerView, playerSO);
        }
    }
}
