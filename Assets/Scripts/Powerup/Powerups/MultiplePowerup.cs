using NebulaNexus.Powerup;
using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class MultiplePowerup : PowerupController
    {
        public MultiplePowerup(PowerupView powerupView, Transform parent, PowerupScriptableObject powerupSO) :
            base(powerupView, parent, powerupSO)
        { }

        public override void OnTrigger(GameObject other)
        {
            Debug.Log("Multiple");
            base.OnTrigger(other);
        }
    }
}