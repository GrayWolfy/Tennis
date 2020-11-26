using UnityEngine;

namespace Ball
{
    public interface IBall
    {
        void Fly();
        void Rotate();

        Vector3 GetDirection();

        bool GetRotated();

        bool CollidedWithPlayerWall();
        bool CollidedWithEnemyWall();
    }
}