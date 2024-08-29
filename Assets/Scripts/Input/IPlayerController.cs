using UnityEngine;

namespace Input
{
    public interface IPlayerController
    {
        void Move(Vector2 direction);
        void Rotate(Vector2 direction);
    }
}