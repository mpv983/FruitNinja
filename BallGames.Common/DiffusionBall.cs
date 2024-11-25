namespace BallGames.Common
{
    public class DiffusionBall : BilliardBall
    {
        public Side Side;
        public event EventHandler<ChangeSideEventArgs> ChangeSide;
        protected override void Go()
        {
            base.Go();
            if (Side == Side.Left)
            {
                if (CenterX >= VerticalCenterSide())
                {
                    Side = Side.Right;
                    ChangeSide.Invoke(this, new ChangeSideEventArgs(this));
                }
            }
            if (Side == Side.Right)
            {
                if (CenterX <= VerticalCenterSide())
                {
                    Side = Side.Left;
                    ChangeSide.Invoke(this, new ChangeSideEventArgs(this));
                }
            }
        }

            public DiffusionBall(Form mainForm, Side side, Color color) : base(mainForm)
        {
            Color = color;
            Brush = new SolidBrush(Color);
            Side = side;
            if (side == Side.Left)
            {
                CenterX = random.Next(LeftSide(), VerticalCenterSide());
            }
            if (side == Side.Right)
            {
                CenterX = random.Next(VerticalCenterSide(), RightSide());
            }
        }
    }
}
