using UnityEngine;

namespace Player
{
    public interface IPlayer
    {
        void Move();
        void Catch();
        void Throw();

        void ReduceTheTime(float time);
        bool IsOutOfTime();
    }
}