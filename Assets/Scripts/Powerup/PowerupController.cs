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
        private float timer = 0f;
        public PowerupScriptableObject PowerupSO => powerupSO;

        public PowerupController(PowerupView powerupView, Transform parent, PowerupScriptableObject powerupSO)
        {
            this.powerupView = Object.Instantiate(powerupView, parent);
            this.powerupView.SetController(this);
            powerupView.SetPowerupSprite(powerupSO.PowerupSprite);
            this.powerupSO = powerupSO;
        }

        public void ConfigurePowerup()
        {
            powerupView.gameObject.SetActive(true);
        }

        public void StartTimer()
        {
            if (GameService.Instance.GameManager.GetGameState() == GameStates.PLAY)
            {
                if (timer < powerupSO.MaxTime)
                    timer += Time.deltaTime;
                else
                    ReturnToPool();
            }
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
            timer = 0f;
            powerupView.gameObject.SetActive(false);
            GameService.Instance.PowerupService.ReturnPowerup(this);
        }
    }
}