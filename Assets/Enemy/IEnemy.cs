namespace Enemy
{
    public interface IEnemy
    {
        void Move();
        void Catch();
        void Throw();
        void Pursuit();
        void Follow();
        void PrepareToStrike();

        void ReduceTheTime(float time);

        bool IsOutOfTime();
    }
}