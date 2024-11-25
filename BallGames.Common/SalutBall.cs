
namespace BallGames.Common
{
    public class SalutBall : RandomSizeAndDirectionMoveBallFromPoint
    {
        private float g = 0.2f;
        public SalutBall(Form mainForm, Point point) : base(mainForm, point)
        {
            vy = - Math.Abs(vy) * 1.3f;
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
        }
    }
}
