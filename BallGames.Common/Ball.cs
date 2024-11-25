namespace BallGames.Common
{
    public class Ball
    {
        protected Form form;
        protected System.Windows.Forms.Timer timer;

        protected float vx = 1;
        protected float vy = 1;
        public float CenterX = 150;
        public float CenterY = 150;
        public int Radius = 35;
        public float DirectionRandomDiapasone = 6;
        public Brush Brush = Brushes.Gray;
        public Color Color = Color.White;
        public RectangleF Rectangle;


        public Ball(Form mainForm)
        {
            this.form = mainForm;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }
        public void Draw(Brush brush)
        {
            var graphics = form.CreateGraphics();
            Rectangle = new RectangleF(CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);
            graphics.FillEllipse(brush, Rectangle);
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void SetTimerInterval(int interval)
        {
            timer.Interval = interval;
        }
        protected virtual void Move()
        {
            Clear();
            Go();
            Draw(Brush);
        }
        protected virtual void Go()
        {
            CenterX += vx;
            CenterY += vy;
        }
        public void Clear()
        {
            var brush = new SolidBrush(form.BackColor);
            Draw(brush);
        }
        public bool IsPointInside(PointF point)
        {
            var center = GetCenterPoint();
            var distance = Measure.DistanceBetween2Points(center, point);
            return distance <= Radius;
        }
        public PointF GetCenterPoint()
        {
            var x = CenterX;
            var y = CenterY;
            return new PointF(x, y);
        }
        public int LeftSide()
        {
            return Radius;
        }
        public int RightSide()
        {
            return form.ClientSize.Width - Radius;
        }
        public int TopSide()
        {
            return Radius;
        }
        public int DownSide()
        {
            return form.ClientSize.Height - Radius;
        }
        public int VerticalCenterSide()
        {
            return form.ClientSize.Width / 2;
        }

        public bool OnForm()
        {
            return CenterX >= LeftSide() && CenterX <= RightSide() && CenterY >= TopSide() && CenterY <= DownSide();
        }
        public bool IsTimerEnabled()
        {
            return timer.Enabled == true;
        }

    }
}
