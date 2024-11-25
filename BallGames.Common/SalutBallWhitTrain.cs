namespace BallGames.Common
{
    public class SalutBallWithTrain : RandomSizeAndDirectionMoveBallFromPoint
    {
        private float g = 0.2f;
        public SalutBallWithTrain(Form mainForm, Point point) : base(mainForm, point)
        {
            vy = -Math.Abs(vy) * 1.3f;
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
        }
        protected override void Move()
        {
            Go();
            Draw(Brush);
        }
    }
}