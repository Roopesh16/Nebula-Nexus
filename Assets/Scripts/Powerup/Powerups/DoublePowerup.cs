using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    public class DoublePowerup : PowerupController
    {
        public DoublePowerup(PowerupView powerupView, Transform parent, PowerupScriptableObject powerupSO) :
            base(powerupView, parent, powerupSO)
        { }

        public override void OnTrigger(GameObject other)
        {
            Debug.Log("Double");
            base.OnTrigger(other);
        }
    }
}