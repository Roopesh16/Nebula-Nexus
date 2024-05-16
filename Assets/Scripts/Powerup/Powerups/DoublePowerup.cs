using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class DoublePowerup : PowerupController
    {
        public DoublePowerup(PowerupView powerupView, Transform parent, PowerupType powerupType, Sprite powerupSprite) :
            base(powerupView, parent, powerupType, powerupSprite)
        { }

        public override void OnTrigger(GameObject other)
        {
            Debug.Log("Double");
            base.OnTrigger(other);
        }
    }
}