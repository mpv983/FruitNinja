namespace BallGames.Common
{
    public class PigBall : RandomSizeAndDirectionMoveBallFromPoint
    {
        public List<PointF> ContactPoints = new List<PointF>();
        public PointF BirdCenterPoint = new PointF();
        public Ball bird;
        public event EventHandler<HitPigEventArgs> PigHitEvent;


        public PigBall(Form mainForm, Point point, Ball bird) : base(mainForm, point)
        {
            this.bird = bird;
            vx = 0;
            vy = 0;
            BirdCenterPoint.X = bird.CenterX;
            BirdCenterPoint.Y = bird.CenterY;
            CalculateContactPoints();
        }

        private void CalculateContactPoints()
        {
            ContactPoints.Clear();
            ContactPoints.Add(new PointF(CenterX, CenterY - Radius));//Top
            ContactPoints.Add(new PointF(CenterX + Radius, CenterY));//Right
            ContactPoints.Add(new PointF(CenterX, CenterY + Radius));//Bottom
            ContactPoints.Add(new PointF(CenterX - Radius, CenterY));//Left
        }
        protected override void Move()
        {
            Draw(Brush);
            foreach (var point in ContactPoints)
            {
                if (bird.Rectangle.IntersectsWith(Rectangle))
                {
                    PigHitEvent.Invoke(this, new HitPigEventArgs());
                    break;
                }
            }
        }
    }
}
