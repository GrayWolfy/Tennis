using System;
using Ball;
using UnityEngine;

namespace Player
{
    public class PlayerLogic : MonoBehaviour, IPlayerLogic
    {
        private bool _hasBall;
        
        public bool isMoved()
        {
            if (Input.touchCount <= 0) return false;
            
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) return true;
           
            return false;

        }

        public bool hasBall()
        {
            return _hasBall;
        }

        public void setHasBall(bool hasBall)
        {
            _hasBall = hasBall;
        }

        public bool canThrow()
        {
            IBall ball = GameObject.Find("Ball").GetComponent<IBall>();
            bool rotated = ball.GetRotated();
            return !isMoved() && hasBall() && rotated;
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name != "Ball") return;

            _hasBall = true;
        }
    }
}