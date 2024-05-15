using UnityEngine;

namespace NebulaNexus.Enemy
{
    [CreateAssetMenu(fileName = "Enemy SO", menuName = "ScriptableObject/Enemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public float moveSpeed = 4f;
        public float RateOfFire = 0.1f;
    }
}