using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Game/Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        public float MoveSpeed = 5.0f;
        public float RotationSpeed = 720f;
        public float SmoothTime = 0.1f;
    }
}