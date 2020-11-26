using System;
using Ball;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        public int maxTime = 120;
        public float currentTime;
        public HealthBar.HealthBar healthBar;

        public void Awake()
        {
            currentTime = maxTime;
            healthBar.SetMaxHealth(maxTime);
        }

        public void Move()
        {
            var touch = Input.GetTouch(0);

            var touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

             transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
        }

        public void Catch()
        {
           GameObject ball = GameObject.Find("Ball");
           ball.transform.SetParent(transform);
           ball.GetComponent<IBallLogic>().setThrown(false);
           ball.GetComponent<IBallLogic>().setCollided(true);
        }

        public void Throw()
        {
            GameObject ball = GameObject.Find("Ball");
            ball.transform.SetParent(null);
            ball.GetComponent<IBallLogic>().setThrown(true);
            ball.GetComponent<IBallLogic>().setCollided(false);
            ball.GetComponent<IBallLogic>().setThrownByPlayer(true);
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
    }
}