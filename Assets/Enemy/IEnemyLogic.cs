using System.CodeDom;
using UnityEngine;

namespace Enemy
{
    public interface IEnemyLogic
    {
        bool hasBall();

        void setHasBall(bool hasBall);

        bool canThrow();

        bool canFollow();

        bool canPursuit();

        bool canCatch();
    }
}