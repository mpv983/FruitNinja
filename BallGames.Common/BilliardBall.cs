namespace BallGames.Common
{
    public class BilliardBall : MoveBall
    {

        public event EventHandler<HitEventArgs> OnHited;

        public BilliardBall(Form mainForm) : base(mainForm)
        {
        }
        protected override void Go()
        {
            base.Go();
            if (CenterX <= LeftSide())
            {
                vx = -vx;
                OnHited.Invoke(this, new HitEventArgs(Side.Left, this));
            }
            if (CenterX >= RightSide())
            {
                vx = -vx;
                OnHited.Invoke(this, new HitEventArgs(Side.Right, this));
            }
            if (CenterY <= TopSide())
            {
                vy = -vy;
                OnHited.Invoke(this, new HitEventArgs(Side.Top, this));
            }
            if (CenterY >= DownSide())
            {
                vy = -vy;
                OnHited.Invoke(this, new HitEventArgs(Side.Down, this));
            }
        }
    }
}
