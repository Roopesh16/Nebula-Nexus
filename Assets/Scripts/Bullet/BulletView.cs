using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        public void SetController(BulletController bulletController) => this.bulletController = bulletController;

        private void Update() => bulletController?.MoveBullet();

        private void OnTriggerEnter2D(Collider2D other) => bulletController.OnTrigger(other.gameObject);
    }
}