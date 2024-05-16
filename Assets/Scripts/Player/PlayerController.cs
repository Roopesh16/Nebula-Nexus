using UnityEngine;
using NebulaNexus.Main;
using NebulaNexus.Bullet;
using NebulaNexus.Interfaces;
using NebulaNexus.Powerup;

namespace NebulaNexus.Player
{
    public class PlayerController : IDamage
    {
        private PlayerView playerView;
        private PlayerScriptableObject playerSO;
        private float rateOfFire = 0f;
        private bool canMoveFire = false;
        private int currentHealth;
        private PowerupType currentPowerup = PowerupType.NULL;

        private PlayerService playerService => GameService.Instance.PlayerService;

        /// <summary>
        /// Initialize Player controller object
        /// </summary>
        /// <param name="playerView"></param>
        /// <param name="playerSO"></param>
        public PlayerController(PlayerView playerView, PlayerScriptableObject playerSO)
        {
            this.playerView = playerView;
            playerView.SetController(this);
            this.playerSO = playerSO;
            ResetPlayer();
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            GameService.Instance.EventService.OnPlayClick.AddListener(ActivatePlayer);
            GameService.Instance.EventService.OnEnemyActive.AddListener(EnableMoveFire);
            GameService.Instance.EventService.OnGameOver.AddListener(ResetPlayer);
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
        public void ShootBullet()
        {
            if (GameService.Instance.GameManager.GetGameState() == GameStates.PLAY && canMoveFire)
            {
                if (rateOfFire < playerSO.RateOfFire)
                    rateOfFire += Time.deltaTime;
                else
                {
                    switch (currentPowerup)
                    {
                        case PowerupType.NULL:
                            BulletController bullet = GameService.Instance.BulletService.GetBullet(BulletType.PLAYER,
                                                            playerService.BulletSO, playerService.BulletParent);
                            bullet.ConfigureBullet(playerView.DefaultSpawn);
                            break;

                        case PowerupType.DOUBLE:
                            for (int i = 0; i < playerView.DoubleSpawns.Count; i++)
                            {
                                BulletController dBullet = GameService.Instance.BulletService.GetBullet(BulletType.PLAYER,
                                                            playerService.BulletSO, playerService.BulletParent);
                                dBullet.ConfigureBullet(playerView.DoubleSpawns[i]);
                            }
                            break;

                        case PowerupType.MULTIPLE:
                            for (int i = 0; i < playerView.MultipleSpawns.Count; i++)
                            {
                                BulletController mBullet = GameService.Instance.BulletService.GetBullet(BulletType.PLAYER,
                                                            playerService.BulletSO, playerService.BulletParent);
                                mBullet.ConfigureBullet(playerView.MultipleSpawns[i]);
                            }
                            break;
                    }

                    rateOfFire = 0f;
                }
            }
        }

        public void DecreaseHealth(int damage)
        {
            if (currentHealth <= 0)
            {
                GameService.Instance.GameManager.OnGameOver();
                return;
            }
            currentHealth -= damage;
        }

        public void OnTrigger(GameObject other)
        {
            if (other.CompareTag("Powerup"))
            {
                PowerupType powerupType = other.GetComponent<PowerupView>().GetPowerupType();

                if (powerupType == PowerupType.DOUBLE)
                    currentPowerup = PowerupType.DOUBLE;
                else
                    currentPowerup = PowerupType.MULTIPLE;
            }
        }

        private void ActivatePlayer() => playerView.gameObject.SetActive(true);
        private void EnableMoveFire() => canMoveFire = true;

        private void ResetPlayer()
        {
            playerView.gameObject.SetActive(false);
            currentHealth = playerSO.MaxHealth;
        }
    }
}