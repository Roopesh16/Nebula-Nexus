using UnityEngine;
using NebulaNexus.Main;
using NebulaNexus.Interfaces;

namespace NebulaNexus.Bullet
{
    public class BulletController : IBullet
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletSO;
        private bool canMove = false;

        /// <summary>
        /// Create Bullet controller object
        /// </summary>
        /// <param name="bulletPrefab"></param>
        /// <param name="bulletSO"></param>
        /// <param name="parent">Parent Transform</param>
        public BulletController(BulletView bulletPrefab, BulletScriptableObject bulletSO, Transform parent)
        {
            bulletView = Object.Instantiate(bulletPrefab, parent);
            bulletView.SetController(this);
            bulletView.SetupBulletView(bulletSO.bulletSprite);
            this.bulletSO = bulletSO;
        }

        /// <summary>
        /// Set bullet active for spawning
        /// </summary>
        /// <param name="spawnPosition"></param>
        public virtual void ConfigureBullet(Transform spawnPosition)
        {
            bulletView.gameObject.SetActive(true);
            bulletView.transform.localPosition = spawnPosition.position;
            bulletView.transform.localRotation = spawnPosition.parent.rotation;
            bulletView.StartTimerCoroutine();
            canMove = true;
        }

        /// <summary>
        /// Move bullet in direction
        /// </summary>
        public virtual void MoveBullet()
        {
            if (canMove)
                bulletView.transform.Translate(bulletView.transform.up * bulletSO.moveSpeed * Time.deltaTime);
        }

        /// <summary>
        /// When bullet triggers with collision
        /// </summary>
        /// <param name="other"></param>
        public virtual void OnTrigger(GameObject other)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Return the controller back to pool
        /// </summary>
        public void ReturnToPool()
        {
            canMove = false;
            bulletView.gameObject.SetActive(false);
            GameService.Instance.BulletService.ReturnBullet(this);
        }
    }
}