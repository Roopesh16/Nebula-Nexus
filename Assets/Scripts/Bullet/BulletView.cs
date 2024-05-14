using UnityEngine;
using System.Collections;

namespace NebulaNexus.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer bulletSR;
        private BulletController bulletController;
        private float bulletTimer = 0f;
        private const float MAX_TIME = 2f;

        public void SetController(BulletController bulletController) => this.bulletController = bulletController;

        public void SetupBulletView(Sprite bulletSprite) => bulletSR.sprite = bulletSprite;

        public void StartTimerCoroutine()
        {
            bulletTimer = 0f;
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            while (bulletTimer < MAX_TIME)
            {
                bulletTimer += Time.deltaTime;
                yield return null;
            }

            bulletTimer = MAX_TIME;
            bulletController.ReturnToPool();
            yield return null;
        }

        private void Update() => bulletController?.MoveBullet();

        private void OnTriggerEnter2D(Collider2D other) => bulletController.OnTrigger(other.gameObject);
    }
}