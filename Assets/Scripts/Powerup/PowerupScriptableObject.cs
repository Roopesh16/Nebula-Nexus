using System.Collections;
using UnityEngine;

namespace NebulaNexus.Powerup
{
    [CreateAssetMenu(fileName = "Powerup SO", menuName = "ScriptableObject/Powerups")]
    public class PowerupScriptableObject : ScriptableObject
    {
        public PowerupType PowerupType;
        public Sprite PowerupSprite;
        public float MoveSpeed = 6f;
        public float MaxTime = 2f;
    }
}