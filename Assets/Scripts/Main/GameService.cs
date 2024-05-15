using UnityEngine;
using NebulaNexus.UI;
using NebulaNexus.Player;
using NebulaNexus.Utilities;
using NebulaNexus.Bullet;
using NebulaNexus.Enemy;

namespace NebulaNexus.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("UI Service")]
        [SerializeField] private UIService uIService;

        [Header("Player Service")]
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerScriptableObject playerSO;
        [SerializeField] private BulletView bulletPrefab;
        [SerializeField] private BulletScriptableObject bulletSO;
        [SerializeField] private Transform bulletParent;

        [Header("Enemy Service")]
        [SerializeField] private EnemyView enemyView;
        [SerializeField] private EnemyScriptableObject enemyScriptableObject;
        [SerializeField] private BulletView enemyBulletPrefab;
        [SerializeField] private BulletScriptableObject enemyBulletSO;
        [SerializeField] private Transform enemyBulletParent;


        public PlayerService PlayerService { get; private set; }
        public EnemyService EnemyService { get; private set; }
        public BulletService BulletService { get; private set; }
        public UIService UIService => uIService;

        /// <summary>
        /// Override Singleton Awake
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            CreateInstance();
        }

        /// <summary>
        /// Method to create all services
        /// </summary>
        private void CreateInstance()
        {
            PlayerService = new PlayerService(playerView, playerSO, bulletPrefab, bulletSO, bulletParent);
            EnemyService = new EnemyService(enemyView, enemyScriptableObject, enemyBulletSO,
                                            enemyBulletPrefab, enemyBulletParent);
            BulletService = new BulletService();
        }
    }
}
