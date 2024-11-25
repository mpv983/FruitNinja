namespace BallGames.Common
{
    public class ChangeSideEventArgs
    {
        public Side Side;
        public Color Color;
        public ChangeSideEventArgs(DiffusionBall ball)
        {
            Side = ball.Side;
            Color = ball.Color;
        }
    }
}