using NebulaNexus.Bullet;
using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        private Transform bulletParent;

        public BulletView BulletPrefab => bulletPrefab;
        public BulletScriptableObject BulletSO => bulletSO;
        public Transform BulletParent => bulletParent;

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
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
            this.bulletParent = bulletParent;
            playerController = new PlayerController(playerView, playerSO);
        }
    }
}
