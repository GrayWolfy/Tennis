using System;
using UnityEngine;

namespace Ball
{
    public class BallLogic : MonoBehaviour, IBallLogic
    {
        private bool _thrown;
        private bool _collided;
        private bool _flying;
        private bool _overTheFence;
        private bool _thrownByPlayer;
        private bool _canBeThrown;
        
        public bool canFly()
        {
            return _thrown;
        }

        public void setThrown(bool thrown)
        {
            _thrown = thrown;
        }

        public void setCollided(bool collided)
        {
            _collided = collided;
        }

        public bool isCollided()
        {
            return _collided;
        }

        public bool isFlying()
        {
            return _flying;
        }

        public bool isOverTheFence()
        {
            return _overTheFence;
        }

        public void setThrownByPlayer(bool thrownByPlayer)
        {
            _thrownByPlayer = thrownByPlayer;
        }

        public void setOverTheFence(bool overTheFence)
        {
            _overTheFence = overTheFence;
        }

        public void setCanBeThrown(bool canBeThrown)
        {
            _canBeThrown = canBeThrown;
        }

        public bool isThrownByPlayer()
        {
            return _thrownByPlayer;
        }

        public void setFlying(bool flying)
        {
            _flying = flying;
        }
    }
}