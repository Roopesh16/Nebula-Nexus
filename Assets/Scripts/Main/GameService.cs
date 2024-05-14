using UnityEngine;
using NebulaNexus.UI;
using NebulaNexus.Player;
using NebulaNexus.Utilities;

namespace NebulaNexus.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [SerializeField] private UIService uIService;

        public PlayerService PlayerService { get; private set; }
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
            PlayerService = new PlayerService();
        }
    }
}
