namespace BallGames.Common
{
    public class AngryBall : RandomSizeAndDirectionMoveBallFromPoint
    {
        private float g = 0.2f;
        public event EventHandler<HitEventArgs> StopOnTheGround;
        public bool IsStarted = false;
        public bool IsDeleted = false;
        public float massFactor = 1;

        public event EventHandler<GoAwayEventArgs> BirdGoAwayEvent;

        public AngryBall(Form mainForm, Point point) : base(mainForm, point)
        {
            vx = 0;
            vy = 0;
            g = 0;
            CalculateMassFactor();
        }
        protected override void Move()
        {
            Clear();
            Go();
            if (!IsDeleted)
            {
                Draw(Brush);
            }
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
            if (CenterY >= DownSide())
            {
                CenterY = DownSide();
                var ky = 0.5f;
                var kx = 0.8f;
                var newVx = vx * kx;
                var newVy = vy * ky;
                if (newVy < 0.9f)
                {
                    newVy = 0;
                }
                if (newVx < 0.3f)
                {
                    newVx = 0;
                }
                vx = newVx;
                vy = -newVy;
            }
            if (vx == 0 && vy == 0 && IsStarted)
            {
                IsDeleted = true;
                StopOnTheGround.Invoke(this, new HitEventArgs(Side.Down, this));
            }
            if (CenterX > RightSide())
            {
                IsDeleted = true;
                BirdGoAwayEvent.Invoke(this, new GoAwayEventArgs());
            }
        }
        public void SetSpeedVector(float vx, float vy)
        {
            CalculateMassFactor();
            this.vx = vx * 1 / massFactor;
            this.vy = vy * 1 / massFactor;
            g = 0.2f * 1 / massFactor;
            IsStarted = true;
        }
        public void CalculateMassFactor()
        {
            var average = (minRandomRadius + maxRandomRadius) / 2f;
            massFactor = Radius / average * 1f;
        }
    }
}
