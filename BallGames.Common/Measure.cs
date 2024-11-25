namespace BallGames.Common
{
    public class Measure
    {
        public static double DistanceBetween2Points(PointF p1, PointF p2)
        {
            var dist = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            return dist;
        }
    }
}
