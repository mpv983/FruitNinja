namespace BallGames.Common
{
    public class SalutBallFromDownSide : SalutBall
    {
        public event EventHandler<GetTopEventArgs> GetTopEvent;
        private bool isOnTop = false;

        public SalutBallFromDownSide(Form mainForm, Point point) : base(mainForm, point)
        {
            CenterY = DownSide() + Radius * 2;
            CenterX = random.Next(0, RightSide());
            if (CenterX < VerticalCenterSide() && vx < 0)
            {
                vx = -vx;
            }
            if (CenterX > VerticalCenterSide() && vx > 0)
            {
                vx = -vx;
            }
            vy = random.Next(10, 14);
            vy = -vy;
        }
        protected override void Go()
        {
            base.Go();

            if (vy > -1 && isOnTop == false)
            {
                isOnTop = true;
                GetTopEvent.Invoke(this, new GetTopEventArgs(this));
            }
        }
    }
}
