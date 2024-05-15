using System;
using UnityEngine;

namespace NebulaNexus.Enemy
{
    [Serializable]
    public struct MoveTimeRange
    {
        public float MinMoveTime;
        public float MaxMoveTime;
    }

    [CreateAssetMenu(fileName = "Enemy SO", menuName = "ScriptableObject/Enemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public float MoveSpeed = 4f;
        public float DownSpeed = 2f;
        public float RateOfFire = 0.1f;
        public float MinDistance = 0.1f;
        public float MaxShootTime = 3f;
        public MoveTimeRange MoveTimeRange;
        public Vector2 StartPostion;
        public Vector2 EndPosition;
        public Vector2 LeftPosition;
        public Vector2 RightPosition;
    }

}