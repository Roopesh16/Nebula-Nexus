using NebulaNexus.Powerup;
using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class MultiplePowerup : PowerupController
    {
        public MultiplePowerup(PowerupView powerupView, Transform parent, PowerupType powerupType, Sprite powerupSprite) :
            base(powerupView, parent, powerupType, powerupSprite)
        { }

        public override void OnTrigger(GameObject other)
        {
            Debug.Log("Multiple");
            base.OnTrigger(other);
        }
    }
}