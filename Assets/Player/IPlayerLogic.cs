using System.CodeDom;
using UnityEngine;

namespace Player
{
    public interface IPlayerLogic
    {
        bool isMoved();
        bool hasBall();

        void setHasBall(bool hasBall);

        bool canThrow();

    }
}