using UnityEngine;

namespace NebulaNexus.Player
{
    [CreateAssetMenu(fileName = "Player SO", menuName = "ScriptableObject/Player")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public float moveSpeed = 3f;

    }
}