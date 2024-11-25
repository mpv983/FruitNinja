using System.Drawing;

namespace BallGames.Common
{
    public class ActiveLine
    {
        protected PointF p1;
        protected PointF p2;
        protected Pen pen = new Pen(Color.Black, 1);
        protected Form form;
        protected System.Windows.Forms.Timer timer;
        protected float MaxLength = 190;

        public ActiveLine(PointF p1, PointF p2, Form form)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.form = form;
        }
        public void Draw()
        {
            var graphics = form.CreateGraphics();
            graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
        }
        public void Clear()
        {
            var graphics = form.CreateGraphics();
            pen = new Pen(form.BackColor, 1);
            graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
        }
        public bool IsOverMaxLenght()
        {
            return Measure.DistanceBetween2Points(p1, p2) <= MaxLength;
        }

        public void SetRedPen()
        {
            pen = new Pen(Color.Red, 1);
        }
    }
}
