using NebulaNexus.Main;
using System.Collections;
using Unity.VisualScripting;
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

        [Header("Game Over Screen")]
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private float maxTime = 3f;

        private float timer;

        private void Awake()
        {
            playButton.onClick.AddListener(OnPlay);
            GameService.Instance.EventService.OnGameOver.AddListener(DisplayGameOver);
        }

        private void Start()
        {
            EnableHomeScreen();
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

        private void DisplayGameOver() => StartCoroutine(GameOverTimer());

        private IEnumerator GameOverTimer()
        {
            while (timer < maxTime)
            {
                gameOverScreen.SetActive(true);
                timer += Time.deltaTime;
                yield return null;
            }
            EnableHomeScreen();
        }

        private void EnableHomeScreen()
        {
            GameService.Instance.GameManager.SetGameState(GameStates.HOME);
            gameOverScreen.SetActive(false);
            homeScreen.SetActive(true);
            timer = 0f;
        }
    }
}
