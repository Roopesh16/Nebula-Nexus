using NebulaNexus.Utilities;
using System;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class PowerupPool : GenericObjectPool<PowerupController>
    {
        private PowerupView powerupPrefab;
        private PowerupType powerupType;
        private Sprite powerupSprite;
        private Transform parent;

        public PowerupPool(PowerupView powerupPrefab)
        {
            this.powerupPrefab = powerupPrefab;
        }

        public PowerupController GetPowerup<U>(PowerupType powerupType, Transform parent, Sprite powerupSprite) where U : PowerupController
        {
            this.powerupType = powerupType;
            this.powerupSprite = powerupSprite;
            this.parent = parent;
            return GetItem<U>();
        }

        protected override PowerupController CreateItem<U>() where U : class
        {
            if (typeof(U) == typeof(DoublePowerup))
                return new DoublePowerup(powerupPrefab, parent, powerupType, powerupSprite);
            else if (typeof(U) == typeof(DoublePowerup))
                return new MultiplePowerup(powerupPrefab, parent, powerupType, powerupSprite);

            throw new NotSupportedException("Invalid Powerup type!");
        }

        public void ReturnPowerup(PowerupController returnPowerup) => ReturnItem(returnPowerup);
    }
}