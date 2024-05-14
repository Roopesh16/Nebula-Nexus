using UnityEngine;
using NebulaNexus.Main;
using NebulaNexus.Bullet;

namespace NebulaNexus.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerScriptableObject playerSO;

        public PlayerController(PlayerView playerView, PlayerScriptableObject playerSO)
        {
            this.playerView = playerView;
            this.playerSO = playerSO;
            playerView.SetController(this);
        }

        public void MovePlayer(Direction direction)
        {
            if (direction == Direction.LEFT)
                playerView.transform.Translate(-playerView.transform.right * playerSO.moveSpeed * Time.deltaTime);
            else
                playerView.transform.Translate(playerView.transform.right * playerSO.moveSpeed * Time.deltaTime);
        }

        public void ShootBullet(Transform spawnPosition)
        {
            BulletController bullet = GameService.Instance.PlayerService.GetBullet();
            bullet.ConfigureBullet(spawnPosition);
        }
    }
}