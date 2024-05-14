using UnityEngine;

namespace NebulaNexus.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer bulletSR;
        private BulletController bulletController;

        public void SetController(BulletController bulletController) => this.bulletController = bulletController;

        public void SetupBulletView(Sprite bulletSprite) => bulletSR.sprite = bulletSprite;

        private void Update() => bulletController?.MoveBullet();

        private void OnTriggerEnter2D(Collider2D other) => bulletController.OnTrigger(other.gameObject);
    }
}