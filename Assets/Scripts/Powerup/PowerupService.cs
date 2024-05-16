using NebulaNexus.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class PowerupService
    {
        private PowerupView powerupPrefab;
        private PowerupSOs powerupSOs;
        private float delayTime;
        private List<Transform> spawnPositions = new();
        private PowerupPool powerupPool;

        private float timer = 0f;


        public PowerupService(PowerupView powerupPrefab, float delayTime, PowerupSOs powerupSOs, List<Transform> spawnPositions)
        {
            this.powerupPrefab = powerupPrefab;
            this.delayTime = delayTime;
            this.spawnPositions = spawnPositions;
            this.powerupSOs = powerupSOs;
            powerupPool = new(this.powerupPrefab);
        }

        public void Update()
        {
            if (GameService.Instance.GameManager.GetGameState() == GameStates.PLAY)
            {
                if (timer < delayTime)
                    timer += Time.deltaTime;
                else
                {
                    SpawnRandomPowerup();
                    timer = 0f;
                }
            }
        }

        private void SpawnRandomPowerup()
        {
            PowerupController powerupController;
            int posRand = Random.Range(0, spawnPositions.Count);
            PowerupType typeRand = (PowerupType)Random.Range(0, 2);

            switch (typeRand)
            {
                case PowerupType.DOUBLE:
                    powerupController = powerupPool.GetPowerup<DoublePowerup>
                        (PowerupType.DOUBLE, spawnPositions[posRand], powerupSOs.DoubleSO);
                    powerupController.ConfigurePowerup();
                    break;

                case PowerupType.MULTIPLE:
                    powerupController = powerupPool.GetPowerup<MultiplePowerup>
                        (PowerupType.MULTIPLE, spawnPositions[posRand], powerupSOs.MultipleSO);
                    powerupController.ConfigurePowerup();
                    break;
            }
        }

        public void ReturnPowerup(PowerupController returnPowerup) => powerupPool.ReturnPowerup(returnPowerup);
    }
}