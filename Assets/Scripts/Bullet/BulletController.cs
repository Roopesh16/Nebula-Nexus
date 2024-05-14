using UnityEngine;
using NebulaNexus.Interfaces;

namespace NebulaNexus.Bullet
{
    public class BulletController : IBullet
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletSO;

        public BulletController(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            bulletView = Object.Instantiate(bulletPrefab);
            bulletView.SetController(this);
            this.bulletSO = bulletSO;
        }

        public void ConfigureBullet(Transform spawnPosition)
        {
            bulletView.gameObject.SetActive(true);
            bulletView.transform.localPosition = spawnPosition.position;
            bulletView.transform.localRotation = spawnPosition.rotation;
        }

        public void MoveBullet()
        {
            bulletView.transform.Translate(bulletView.transform.up * bulletSO.moveSpeed * Time.deltaTime);
        }

        public void OnTrigger(GameObject other)
        {
            throw new System.NotImplementedException();
        }
    }
}