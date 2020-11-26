using Player;
using System;
using Ball;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private IEnemy _enemy;
        private IEnemyLogic _enemyLogic;


        private void Awake()
        {
            _enemyLogic = gameObject.AddComponent<EnemyLogic>();
            _enemy = gameObject.GetComponent<Enemy>();
        }

        private void Update()
        {
            if (_enemyLogic.canThrow())
            {
                _enemy.Throw();
                _enemyLogic.setHasBall(false);
                return;
            }

            if (_enemyLogic.canFollow())
            {
                _enemy.Follow();
                return;
            }

            if (_enemyLogic.canPursuit())
            {
                _enemy.Pursuit();
                return;
            }

            if (!_enemyLogic.hasBall())
            {
                _enemy.Move();
                return;
            }

            if (_enemyLogic.hasBall() && _enemyLogic.canCatch())
            {
                _enemy.Catch();
            }

            if (_enemyLogic.hasBall())
            {
                _enemy.PrepareToStrike();
            }
        }
    }
}