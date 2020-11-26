using System;
using UnityEngine;

namespace Ball
{
    public class BallController : MonoBehaviour
    {
        private IBall _ball;
        private IBallLogic _ballLogic;
        
        private void Awake()
        {
            _ballLogic = gameObject.AddComponent<BallLogic>();
            _ball = gameObject.AddComponent<Ball>();
        }

        private void Update()
        {
            _ballLogic.setOverTheFence(false);
            
            if (gameObject.transform.position.y > 0)
            {
                _ballLogic.setOverTheFence(true);
            }

            if (_ballLogic.isCollided())
            {
                _ball.Rotate();
            }

            if (!_ballLogic.canFly()) return;

            _ball.Fly();
            _ballLogic.setFlying(true);
            _ballLogic.setThrown(false);
        }
    }
    
    
}