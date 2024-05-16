namespace NebulaNexus.Main
{
    public class GameManager
    {
        private GameStates gameState;

        public GameManager() => gameState = GameStates.HOME;

        public void SetGameState(GameStates gameState) => this.gameState = gameState;

        public GameStates GetGameState() => gameState;
    }
}