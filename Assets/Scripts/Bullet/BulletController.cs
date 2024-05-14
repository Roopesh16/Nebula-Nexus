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

        public BulletController(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            bulletView = Object.Instantiate(bulletPrefab);
            bulletView.SetController(this);
            bulletView.SetupBulletView(bulletSO.bulletSprite);
            this.bulletSO = bulletSO;
        }

        public void ConfigureBullet(Transform spawnPosition)
        {
            bulletView.gameObject.SetActive(true);
            bulletView.transform.localPosition = spawnPosition.position;
            bulletView.transform.localRotation = spawnPosition.rotation;
            bulletView.StartTimerCoroutine();
            canMove = true;
        }

        public void MoveBullet()
        {
            if (canMove)
                bulletView.transform.Translate(bulletView.transform.up * bulletSO.moveSpeed * Time.deltaTime);
        }

        public void OnTrigger(GameObject other)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnToPool()
        {
            canMove = false;
            bulletView.gameObject.SetActive(false);
            GameService.Instance.PlayerService.ReturnBullet(this);
        }
    }
}