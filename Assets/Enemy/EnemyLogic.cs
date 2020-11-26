using System;
using System.Collections.Generic;
using Ball;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyLogic : MonoBehaviour, IEnemyLogic
    {
        private bool _hasBall;

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
            if (!_hasBall)
            {
                return false;
            }
            
            GameObject ball = GameObject.Find("Ball");
            List<bool> canThrow = new List<bool>{true, false};
            Vector3 throwDir = new Vector3(1, - 1 , 0);

            bool rotated = ball.GetComponent<IBall>().GetRotated();  
            
            var rightDirection = Vector3.Dot(ball.GetComponent<IBall>().GetDirection().normalized, throwDir) > 0;
            if (!rightDirection) return false;
            
            var index = Random.Range(0, canThrow.Count - 1);;
            
            return (canThrow[index]) && rotated;
        }

        public bool canFollow()
        {
            GameObject ball = GameObject.Find("Ball");
            IBallLogic ballLogic = ball.GetComponent<IBallLogic>();
            bool flying= ballLogic.isFlying();
            bool overTheFence = ballLogic.isOverTheFence();
            bool isThrownByPlayer = ballLogic.isThrownByPlayer();
            return flying && !overTheFence && isThrownByPlayer && !_hasBall;
        }

        public bool canPursuit()
        {
            GameObject ball = GameObject.Find("Ball");
            IBallLogic ballLogic = ball.GetComponent<IBallLogic>();
            bool flying= ballLogic.isFlying();
            bool overTheFence = ballLogic.isOverTheFence();
            bool isThrownByPlayer = ballLogic.isThrownByPlayer();

            return flying && overTheFence && isThrownByPlayer && !_hasBall;
        }

        public bool canCatch()
        {
            GameObject ball = GameObject.Find("Ball");
            
            return ball.GetComponent<IBallLogic>().isThrownByPlayer();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name != "Ball") return;
            _hasBall = true;
        }
    }
}