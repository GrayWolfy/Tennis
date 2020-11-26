using System;
using System.Collections;
using Ball;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] Transform playerTransform;
        [SerializeField] Transform ballTransform;

        private Vector3 _previousPosition;
        private Rigidbody2D _rb;
        private int _pursuitSpeed = 5;
        public int maxTime = 120;
        public float currentTime;
        public HealthBar.HealthBar healthBar;

        private void Awake()
        {
            currentTime = maxTime;
            healthBar.SetMaxHealth(maxTime);
            
            _previousPosition = playerTransform.position;
            _rb = gameObject.GetComponent<Rigidbody2D>();
        }

        public void Move()
        {
            var position = playerTransform.position;
            Vector3 deltaPlayerPos = position - _previousPosition;
            _previousPosition = position;

            var o = gameObject;

            Vector3 enemyPosition = o.transform.position;

            Vector3 pos = enemyPosition;

            pos.x = position.x;
            pos.y -= deltaPlayerPos.y;

            gameObject.transform.position =
                Vector3.MoveTowards(transform.position, pos, 3 * Time.deltaTime);
        }

        public void Follow()
        {
            var position = ballTransform.position;

            _previousPosition = position;

            var o = gameObject;

            Vector3 enemyPosition = o.transform.position;

            Vector3 pos = enemyPosition;

            pos.x = position.x;

            gameObject.transform.position =
                Vector3.MoveTowards(transform.position, pos, 5 * Time.deltaTime);
        }

        public void PrepareToStrike()
        {
            var position = playerTransform.position;
            _previousPosition = position;

            var o = gameObject;

            Vector3 enemyPosition = o.transform.position;

            Vector3 pos = enemyPosition;

            pos.x = -position.x;
            pos.y = -position.y;

            gameObject.transform.position =
                Vector3.MoveTowards(transform.position, pos, 5 * Time.deltaTime);
        }

        public void ReduceTheTime(float time)
        {
            currentTime -= time;
            healthBar.SetHealth(currentTime);
        }

        public bool IsOutOfTime()
        {
            return currentTime <= 0;
        }

        public void Pursuit()
        {
            gameObject.transform.position =
                Vector3.MoveTowards(transform.position, ballTransform.position, _pursuitSpeed * Time.deltaTime);
        }

        public void Catch()
        {
            GameObject ball = GameObject.Find("Ball");
            ball.transform.SetParent(transform);
            ball.GetComponent<IBallLogic>().setThrown(false);
            ball.GetComponent<IBallLogic>().setThrownByPlayer(false);
            ball.GetComponent<IBallLogic>().setCollided(true);
        }

        public void Throw()
        {
            GameObject ball = GameObject.Find("Ball");
            ball.transform.SetParent(null);
            ball.GetComponent<IBallLogic>().setThrown(true);
            ball.GetComponent<IBallLogic>().setCollided(false);
        }
    }
}