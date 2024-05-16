using UnityEngine;
using NebulaNexus.UI;
using NebulaNexus.Player;
using NebulaNexus.Utilities;
using NebulaNexus.Bullet;
using NebulaNexus.Enemy;
using NebulaNexus.Events;
using NebulaNexus.Powerup;
using System.Collections.Generic;
using System;

namespace NebulaNexus.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("UI Service")]
        [SerializeField] private UIService uIService;

        [Header("Player Service")]
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerScriptableObject playerSO;
        [SerializeField] private BulletScriptableObject bulletSO;
        [SerializeField] private Transform bulletParent;

        [Header("Enemy Service")]
        [SerializeField] private EnemyView enemyView;
        [SerializeField] private EnemyScriptableObject enemyScriptableObject;
        [SerializeField] private BulletScriptableObject enemyBulletSO;
        [SerializeField] private Transform enemyBulletParent;

        [Header("Bullet Service")]
        [SerializeField] private BulletView bulletPrefab;

        [Header("Powerup Service")]
        [SerializeField] private PowerupView powerupPrefab;
        [SerializeField] private PowerupSprites powerupSprites;
        [SerializeField] private List<Transform> spawnPostions = new();


        public EventService EventService { get; private set; }
        public GameManager GameManager { get; private set; }
        public PlayerService PlayerService { get; private set; }
        public EnemyService EnemyService { get; private set; }
        public BulletService BulletService { get; private set; }
        public PowerupService PowerupService { get; private set; }
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
            EventService = new EventService();
            GameManager = new GameManager();
            PlayerService = new PlayerService(playerView, playerSO, bulletSO, bulletParent);
            EnemyService = new EnemyService(enemyView, enemyScriptableObject, enemyBulletSO, enemyBulletParent);
            BulletService = new BulletService(bulletPrefab);
            PowerupService = new PowerupService(powerupPrefab, powerupSprites, spawnPostions);
        }
    }

    [Serializable]
    public struct PowerupSprites
    {
        public Sprite DoubleSprite;
        public Sprite MultipleSprite;
    }
}
