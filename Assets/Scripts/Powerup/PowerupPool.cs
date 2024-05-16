using NebulaNexus.Utilities;
using System;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class PowerupPool : GenericObjectPool<PowerupController>
    {
        private PowerupView powerupPrefab;
        private PowerupScriptableObject powerupSO;
        private Transform parent;

        public PowerupPool(PowerupView powerupPrefab)
        {
            this.powerupPrefab = powerupPrefab;
        }

        public PowerupController GetPowerup<U>(PowerupType powerupType, Transform parent, PowerupScriptableObject powerupSO) where U : PowerupController
        {
            this.powerupSO = powerupSO;
            this.parent = parent;
            return GetItem<U>();
        }

        protected override PowerupController CreateItem<U>() where U : class
        {
            if (typeof(U) == typeof(DoublePowerup))
                return new DoublePowerup(powerupPrefab, parent, powerupSO);
            else if (typeof(U) == typeof(MultiplePowerup))
                return new MultiplePowerup(powerupPrefab, parent, powerupSO);

            throw new NotSupportedException("Invalid Powerup type!");
        }

        public void ReturnPowerup(PowerupController returnPowerup) => ReturnItem(returnPowerup);
    }
}