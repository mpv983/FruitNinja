namespace BallGames.Common
{
    public class BallBurst : Ball
    {
        private System.Windows.Forms.Timer timer;
        private int countTicks = 5;
        private float penWidth = 9;
        private int step = 12;
        private int interval = 30;


        public BallBurst(Form mainForm, Ball ball) : base(mainForm)
        {
            CenterX = ball.CenterX;
            CenterY = ball.CenterY;
            Color = ball.Color;
            Radius = ball.Radius;
            timer = new System.Windows.Forms.Timer();
        }
        public void Burst()
        {
            DrawBurst();
            TimerStart();
            ClearBurst();
        }

        private void TimerStart()
        {
            timer.Interval = interval;
            DrawBurst();
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (countTicks != 0)
            {
                ClearBurst();
                Animation();
                DrawBurst();
            }
            else
            {
                ClearBurst();
                timer.Stop();
            }
        }

        private void Animation()
        {
            countTicks--;
            step -= 3;
            Radius += step;
            penWidth -= 2;
        }

        private void DrawBurst()
        {
            var graphics = form.CreateGraphics();
            Rectangle = new RectangleF(CenterX - Radius, CenterY - Radius, Radius*2, Radius*2);
            var pen = new Pen(Color, penWidth);
            graphics.DrawEllipse(pen, Rectangle);
        }
        private void ClearBurst()
        {
            var graphics = form.CreateGraphics();
            Rectangle = new RectangleF(CenterX - Radius, CenterY - Radius, Radius*2, Radius*2);
            var pen = new Pen(form.BackColor, penWidth);
            graphics.DrawEllipse(pen, Rectangle);
        }
    }
}
