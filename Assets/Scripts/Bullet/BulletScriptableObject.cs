using UnityEngine;

namespace NebulaNexus.Bullet
{
    [CreateAssetMenu(fileName = "Bullet SO", menuName = "ScriptableObject/Bullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public float moveSpeed = 6f;
        public Sprite bulletSprite;
    }
}