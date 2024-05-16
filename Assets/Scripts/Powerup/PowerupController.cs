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

        public PowerupController(PowerupView powerupPrefab, Transform parent, PowerupScriptableObject powerupSO)
        {
            powerupView = Object.Instantiate(powerupPrefab, parent);
            powerupView.SetController(this);
            powerupPrefab.SetPowerupSprite(powerupSO.PowerupSprite);
            this.powerupSO = powerupSO;
        }

        public void ConfigurePowerup(Transform parent)
        {
            powerupView.gameObject.SetActive(true);
            powerupView.transform.position = parent.position;
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

        public virtual void OnTrigger(GameObject other) => ReturnToPool();

        private void ReturnToPool()
        {
            timer = 0f;
            powerupView.gameObject.SetActive(false);
            GameService.Instance.PowerupService.ReturnPowerup(this);
        }
    }
}