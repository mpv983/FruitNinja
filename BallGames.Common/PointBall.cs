namespace BallGames.Common
{
    public class PointBall : Ball
    {
        public PointBall(Form mainForm, int x, int y) : base(mainForm)
        {
            CenterX = x;
            CenterY = y;
        }

    }
}
