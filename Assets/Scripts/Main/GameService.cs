using NebulaNexus.UI;
using UnityEngine;

namespace NebulaNexus.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [SerializeField] private UIService uIService;

        public PlayerService PlayerService { get; private set; }
        public UIService UIService => uIService;

        protected override void Awake()
        {
            base.Awake();
            CreateInstance();
        }

        private void CreateInstance()
        {
            PlayerService = new PlayerService();
        }
    }
}
