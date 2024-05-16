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
        private bool canMoveFire = false;

        private PlayerService playerService => GameService.Instance.PlayerService;

        /// <summary>
        /// Initialize Player controller object
        /// </summary>
        /// <param name="playerView"></param>
        /// <param name="playerSO"></param>
        public PlayerController(PlayerView playerView, PlayerScriptableObject playerSO)
        {
            this.playerView = playerView;
            this.playerView.gameObject.SetActive(false);
            playerView.SetController(this);
            this.playerSO = playerSO;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            GameService.Instance.EventService.OnPlayClick.AddListener(ActivatePlayer);
            GameService.Instance.EventService.OnEnemyActive.AddListener(EnableMoveFire);
        }

        /// <summary>
        /// Move player based on direction
        /// </summary>
        /// <param name="direction"></param>
        public void MovePlayer(Direction direction)
        {
            if (GameService.Instance.GameManager.GetGameState() == GameStates.PLAY && canMoveFire)
            {
                if (direction == Direction.LEFT)
                    playerView.transform.Translate(playerSO.MoveSpeed * Time.deltaTime * -playerView.transform.right);
                else
                    playerView.transform.Translate(playerSO.MoveSpeed * Time.deltaTime * playerView.transform.right);
            }
        }

        /// <summary>
        /// Get Bullet controller and spawn based on rate of fire
        /// </summary>
        /// <param name="spawnPosition"></param>
        public void ShootBullet(Transform spawnPosition)
        {
            if (GameService.Instance.GameManager.GetGameState() == GameStates.PLAY && canMoveFire)
            {
                if (rateOfFire < playerSO.RateOfFire)
                    rateOfFire += Time.deltaTime;
                else
                {
                    BulletController bullet = GameService.Instance.BulletService.GetBullet(BulletType.PLAYER,
                                                            playerService.BulletSO, playerService.BulletParent);
                    bullet.ConfigureBullet(spawnPosition);
                    rateOfFire = 0f;
                }
            }
        }

        private void ActivatePlayer() => playerView.gameObject.SetActive(true);

        private void EnableMoveFire() => canMoveFire = true;

    }
}