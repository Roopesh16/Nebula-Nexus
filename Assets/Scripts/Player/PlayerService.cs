using NebulaNexus.Bullet;
using UnityEngine;

namespace NebulaNexus.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletScriptableObject bulletSO;
        private Transform bulletParent;

        public BulletScriptableObject BulletSO => bulletSO;
        public Transform BulletParent => bulletParent;

        /// <summary>
        /// Initialize Player Service object
        /// </summary>
        /// <param name="playerView"></param>
        /// <param name="playerSO"></param>
        /// <param name="bulletSO"></param>
        /// <param name="bulletParent"></param>
        public PlayerService(PlayerView playerView, PlayerScriptableObject playerSO,
                                             BulletScriptableObject bulletSO, Transform bulletParent)
        {
            this.bulletSO = bulletSO;
            this.bulletParent = bulletParent;
            playerController = new PlayerController(playerView, playerSO);
        }
    }
}
