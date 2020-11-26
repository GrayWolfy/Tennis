using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour, IBall
    {
        private const string PlayerWall = "BackWall_2";
        private const string EnemyWall = "BackWall_1";
        private const int BackWall = 13;
        private float _radius;
        private int _turns;
        private Rigidbody2D _rb;
        private Vector3 _startPos;
        private Vector3 _direction;
        private int _rotations = 0;
        private float _rotationTime = 0;
        private float _speed = 0f;
        private int _angle = 360;
        private bool _rotatedOnce;
        private bool _collidedWithPlayerWall;
        private bool _collidedWithEnemyWall;
        private void Awake()
        {
            _radius = GetComponent<CircleCollider2D>().radius;
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _angle = 360;
        }

        public void Fly()
        {
            gameObject.transform.SetParent(null);
            
            _rb.AddForce(_speed * _direction.normalized, ForceMode2D.Impulse);
            
            _angle = 360;
            _rotations = 0;
            _rotationTime = 0;
            _rotatedOnce = false;
        }

        public void Rotate()
        {
            float angularVelocity = _angle * Time.deltaTime;
            
            int period = Mathf.RoundToInt(2 * Mathf.PI / (angularVelocity));
           
            _speed = angularVelocity * _radius;
            _rotationTime += Time.deltaTime;
            _rotations = Mathf.RoundToInt(_rotationTime / period);
            
            if (_rotations == 1 && _angle > 10)
            {
                _angle -= 10;
                _rotations = 0;
                _rotationTime = 0;
                _rotatedOnce = true;
            }
            
            Vector3 pos = transform.position;

            _direction = pos - _startPos;
            _startPos = pos;
            
            var playerPosition = gameObject.transform.parent.position;
            var dir = pos - playerPosition;

            dir = Vector3.ClampMagnitude(dir, _radius);

            transform.position = playerPosition + dir;
            
            transform.RotateAround(playerPosition, Vector3.forward, angularVelocity);
        }

        public Vector3 GetDirection()
        {
            return _direction;
        }

        public bool GetRotated()
        {
            return _rotatedOnce;
        }

        public bool CollidedWithPlayerWall()
        {
            return _collidedWithPlayerWall;
        }

        public bool CollidedWithEnemyWall()
        {
            return _collidedWithEnemyWall;
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Player" || other.gameObject.name == "Enemy")
            {
                _startPos = transform.position;
                _rb.velocity = Vector3.zero;
            }
            
            
            if (other.gameObject.layer == BackWall)
            {
                if (other.gameObject.name == PlayerWall)
                {
                    _collidedWithPlayerWall = true;
                }
                
                if (other.gameObject.name == EnemyWall)
                {
                    _collidedWithEnemyWall = true;
                }
                
                _rb.velocity = Vector3.zero;
            }
        }
        
    }
}