using UnityEngine;

namespace NebulaNexus.Player
{
    [CreateAssetMenu(fileName = "Player SO", menuName = "ScriptableObject/Player")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public float MoveSpeed = 3f;
        public float RateOfFire = 0.2f;
        public int MaxHealth = 100;
    }
}