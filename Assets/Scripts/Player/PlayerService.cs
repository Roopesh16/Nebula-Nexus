using NebulaNexus.Bullet;
using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletPool bulletPool;

        /// <summary>
        /// Initialize Player Service object
        /// </summary>
        /// <param name="playerView"></param>
        /// <param name="playerSO"></param>
        /// <param name="bulletPrefab"></param>
        /// <param name="bulletSO"></param>
        /// <param name="bulletParent"></param>
        public PlayerService(PlayerView playerView, PlayerScriptableObject playerSO, BulletView bulletPrefab,
                                             BulletScriptableObject bulletSO, Transform bulletParent)
        {
            playerController = new PlayerController(playerView, playerSO);
            bulletPool = new BulletPool(bulletPrefab, bulletSO, bulletParent);
        }

        /// <summary>
        /// Get Bullet from bullet pool
        /// </summary>
        /// <returns></returns>
        public BulletController GetBullet() => bulletPool.GetItem();

        /// <summary>
        /// Send Bullet back to Bullet pool
        /// </summary>
        /// <param name="returnBullet"></param>
        public void ReturnBullet(BulletController returnBullet) => bulletPool.ReturnItem(returnBullet);
    }
}
