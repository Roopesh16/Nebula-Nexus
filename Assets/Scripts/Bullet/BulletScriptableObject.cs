using UnityEngine;

namespace NebulaNexus.Bullet
{
    [CreateAssetMenu(fileName = "Bullet SO", menuName = "ScriptableObject/Bullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public float MoveSpeed = 6f;
        public Sprite BulletSprite;
        public LayerMask BulletLayer;
        public string Tag;
        public int MaxHealth = 100;
        public int Damage;

    }
}