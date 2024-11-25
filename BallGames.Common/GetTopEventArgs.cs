namespace BallGames.Common
{
    public class GetTopEventArgs
    {
        public GetTopEventArgs(Ball ball)
        {
            Point = new Point((int)ball.CenterX, (int)ball.CenterY);
        }

        public Point Point {  get; set; }
    }
}