using UnityEngine;
using NebulaNexus.Main;
using NebulaNexus.Bullet;

namespace NebulaNexus.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerScriptableObject playerSO;

        private float rateOfFire = 0f;

        /// <summary>
        /// Initialize Player controller object
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
        /// Move player based on direction
        /// </summary>
        /// <param name="direction"></param>
        public void MovePlayer(Direction direction)
        {
            if (direction == Direction.LEFT)
                playerView.transform.Translate(playerSO.MoveSpeed * Time.deltaTime * -playerView.transform.right);
            else
                playerView.transform.Translate(playerSO.MoveSpeed * Time.deltaTime * playerView.transform.right);
        }

        /// <summary>
        /// Get Bullet controller and spawn based on rate of fire
        /// </summary>
        /// <param name="spawnPosition"></param>
        public void ShootBullet(Transform spawnPosition)
        {
            if (rateOfFire < playerSO.RateOfFire)
                rateOfFire += Time.deltaTime;
            else
            {
                BulletController bullet = GameService.Instance.PlayerService.GetBullet();
                bullet.ConfigureBullet(spawnPosition);
                rateOfFire = 0f;
            }
        }
    }
}