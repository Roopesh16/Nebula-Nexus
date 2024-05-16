using NebulaNexus.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class PowerupService
    {
        private PowerupSOs powerupSOs;
        private float delayTime;
        private List<Transform> spawnPositions = new();
        private PowerupPool powerupPool;
        private float timer = 0f;
        private const int MIN_VAL = 0;
        private const int MAX_VAL = 100;

        public PowerupService(PowerupView powerupPrefab, float delayTime, PowerupSOs powerupSOs, List<Transform> spawnPositions)
        {
            this.delayTime = delayTime;
            this.spawnPositions = spawnPositions;
            this.powerupSOs = powerupSOs;
            powerupPool = new(powerupPrefab);
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
            int posRand = Random.Range(0, spawnPositions.Count);
            int randVal = Random.Range(MIN_VAL, MAX_VAL);
            PowerupType typeRand;

            if (randVal < ((MIN_VAL + MAX_VAL) / 2))
            {
                typeRand = PowerupType.DOUBLE;
            }
            else
                typeRand = PowerupType.MULTIPLE;

            switch (typeRand)
            {
                case PowerupType.DOUBLE:
                    PowerupController doublePowerup = powerupPool.GetPowerup<DoublePowerup>
                        (spawnPositions[posRand], powerupSOs.DoubleSO);
                    doublePowerup.ConfigurePowerup(spawnPositions[posRand]);
                    break;

                case PowerupType.MULTIPLE:
                    PowerupController multiplePowerup = powerupPool.GetPowerup<MultiplePowerup>
                        (spawnPositions[posRand], powerupSOs.MultipleSO);
                    multiplePowerup.ConfigurePowerup(spawnPositions[posRand]);
                    break;
            }
        }

        public void ReturnPowerup(PowerupController returnPowerup) => powerupPool.ReturnPowerup(returnPowerup);
    }
}