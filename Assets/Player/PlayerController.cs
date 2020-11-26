using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayer _player;
        private IPlayerLogic _playerLogic;

        private void Awake()
        {
            _playerLogic = gameObject.AddComponent<PlayerLogic>();
            _player = gameObject.GetComponent<Player>();
        }

        private void Update()
        {
            if (_playerLogic.canThrow())
            {
                _player.Throw();
                _playerLogic.setHasBall(false);
            }

            if (_playerLogic.isMoved())
            {
                _player.Move();
            }

            if (_playerLogic.hasBall())
            {
                _player.Catch();
            }
        }
    }
    
}
