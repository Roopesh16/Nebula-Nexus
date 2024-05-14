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

        /// <summary>
        /// Set Controller for view
        /// </summary>
        /// <param name="bulletController"></param>
        public void SetController(BulletController bulletController) => this.bulletController = bulletController;

        /// <summary>
        /// Initialize Bullet view
        /// </summary>
        /// <param name="bulletSprite">Sprite to add to bullet view</param>
        public void SetupBulletView(Sprite bulletSprite) => bulletSR.sprite = bulletSprite;

        /// <summary>
        /// Reset timer and Start disable timer
        /// </summary>
        public void StartTimerCoroutine()
        {
            bulletTimer = 0f;
            StartCoroutine(StartTimer());
        }

        /// <summary>
        /// Run coroutine for time till view is active
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Move bullet through Update
        /// </summary>
        private void Update() => bulletController?.MoveBullet();

        /// <summary>
        /// Call on collision with other object
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other) => bulletController.OnTrigger(other.gameObject);
    }
}