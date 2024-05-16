using NebulaNexus.Main;
using UnityEngine;
using UnityEngine.UI;

namespace NebulaNexus.UI
{
    public class UIService : MonoBehaviour
    {
        [Header("BG Scroll")]
        [SerializeField] private RawImage bgImage;
        [SerializeField] private float yScroll;
        [Header("Home Screen")]
        [SerializeField] private GameObject homeScreen;
        [SerializeField] private Button playButton;

        private void Awake()
        {
            playButton.onClick.AddListener(OnPlay);
        }

        private void Update()
        {
            bgImage.uvRect = new Rect(bgImage.uvRect.position + (new Vector2(0, yScroll) * Time.deltaTime),
                                      bgImage.uvRect.size);
        }

        private void OnPlay()
        {
            homeScreen.SetActive(false);
            GameService.Instance.GameManager.SetGameState(GameStates.PLAY);
            GameService.Instance.EventService.OnPlayClick.Invoke();
        }
    }
}
