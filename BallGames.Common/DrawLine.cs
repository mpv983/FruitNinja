namespace BallGames.Common
{
    public class DrawLine
    {
        protected Form form;
        protected System.Windows.Forms.Timer timer;

        public DrawLine(Form form)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.form = form;
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            CenterLine();
        }

        public void CenterLine()
        {
            var graphics = form.CreateGraphics();

            Pen blackPen = new Pen(Color.Black, 1);

            int x1 = form.ClientSize.Width / 2;
            int y1 = 0;
            int x2 = form.ClientSize.Width / 2;
            int y2 = form.ClientSize.Height;

            graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }
    }
}
