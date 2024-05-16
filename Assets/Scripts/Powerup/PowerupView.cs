using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class PowerupView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer powerupSR;

        private PowerupController powerupController;

        public void SetController(PowerupController powerupController) => this.powerupController = powerupController;

        public void SetPowerupSprite(Sprite powerupSprite) => powerupSR.sprite = powerupSprite;

        public PowerupType GetPowerupType() => powerupController.PowerupSO.PowerupType;

        private void Update() => powerupController?.MovePowerup();

        private void OnTriggerEnter2D(Collider2D other) => powerupController?.OnTrigger(other.gameObject);
    }
}