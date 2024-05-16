using NebulaNexus.Interfaces;
using NebulaNexus.Main;
using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class PowerupController : IPowerup
    {
        protected PowerupView powerupView;
        protected PowerupType powerupType;

        public PowerupType PowerupType => powerupType;

        public PowerupController(PowerupView powerupView, Transform parent, PowerupType powerupType, Sprite powerupSprite)
        {
            this.powerupView = Object.Instantiate(powerupView, parent);
            this.powerupView.SetController(this);
            this.powerupType = powerupType;
            this.powerupView.SetPowerupSprite(powerupSprite);
        }

        public virtual void OnTrigger(GameObject other)
        {
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            powerupView.gameObject.SetActive(false);
            GameService.Instance.PowerupService.ReturnPowerup(this);
        }
    }
}