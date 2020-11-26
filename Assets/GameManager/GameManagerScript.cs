
using Ball;
using Enemy;
using Player;
using UnityEngine;
using UnityEngine.Audio;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private Transform _fenceTransform;
    public GameObject WinText;
    public GameObject LooseText;
    
    private IPlayer _player;
    private IEnemy _enemy;
    private IBall _ball;

    AudioSource _audioData;

    void Start()
    {
        _audioData = GetComponent<AudioSource>();
        _audioData.Play(0);
    }
    
    private void Update()
    {
        _player = GameObject.Find("Player").GetComponent<IPlayer>();
        _enemy = GameObject.Find("Enemy").GetComponent<IEnemy>();
        _ball = GameObject.Find("Ball").GetComponent<IBall>();

        if (_ball.CollidedWithEnemyWall() || _enemy.IsOutOfTime())
        {
            YouWin();
        }

        if (_ball.CollidedWithPlayerWall() || _player.IsOutOfTime())
        {
            YouLoose();
        }
        
        var ballPositionY = _ballTransform.position.y;
        var fencePositionY = _fenceTransform.position.y;

        if (ballPositionY < fencePositionY)
        {
            _player.ReduceTheTime(Time.deltaTime);
            return;
        }
        
        _enemy.ReduceTheTime(Time.deltaTime);
    }

    private void YouWin()
    {
        WinText.SetActive(true);
    }
    
    private void YouLoose()
    {
        LooseText.SetActive(true);
    }

    private void PlayMusic()
    {
        
    }
}
