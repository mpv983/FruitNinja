namespace BallGames.Common
{
    public class HitEventArgs
    {
        public Side Side { get; set; }
        public Color Color { get; set; }
        public HitEventArgs(Side side, Ball ball)
        {
            Side = side;
            Color = ball.Color;
        }
    }
}
