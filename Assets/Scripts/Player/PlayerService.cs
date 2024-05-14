using NebulaNexus.Bullet;
using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletPool bulletPool;

        public PlayerService(PlayerView playerView, PlayerScriptableObject playerSO, BulletView bulletPrefab,
                                             BulletScriptableObject bulletSO, Transform bulletParent)
        {
            playerController = new PlayerController(playerView, playerSO);
            bulletPool = new BulletPool(bulletPrefab, bulletSO, bulletParent);
        }

        public BulletController GetBullet() => bulletPool.GetItem();

        public void ReturnBullet(BulletController returnBullet) => bulletPool.ReturnItem(returnBullet);
    }
}
