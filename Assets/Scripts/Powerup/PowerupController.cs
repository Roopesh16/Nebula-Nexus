using NebulaNexus.Interfaces;
using NebulaNexus.Main;
using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class PowerupController : IPowerup
    {
        protected PowerupView powerupView;
        protected PowerupScriptableObject powerupSO;

        public PowerupScriptableObject PowerupSO => powerupSO;

        public PowerupController(PowerupView powerupView, Transform parent, PowerupScriptableObject powerupSO)
        {
            this.powerupView = Object.Instantiate(powerupView, parent);
            this.powerupView.SetController(this);
            this.powerupSO = powerupSO;
            this.powerupView.SetPowerupSprite(powerupSO.PowerupSprite);
        }

        public void MovePowerup()
        {
            if (GameService.Instance.GameManager.GetGameState() == GameStates.PLAY)
                powerupView.transform.Translate(powerupSO.MoveSpeed * Time.deltaTime * -powerupView.transform.up);
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