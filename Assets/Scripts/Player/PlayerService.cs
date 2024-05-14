using NebulaNexus.Bullet;

namespace NebulaNexus.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletPool bulletPool;

        public PlayerService(PlayerView playerView, PlayerScriptableObject playerSO, BulletView bulletPrefab,
                                                                            BulletScriptableObject bulletSO)
        {
            playerController = new PlayerController(playerView, playerSO);
            bulletPool = new BulletPool(bulletPrefab, bulletSO);
        }
    }
}
