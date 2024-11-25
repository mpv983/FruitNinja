namespace BallGames.Common
{
    public class RandomSizeAndDirectionMoveBallFromPoint : MoveBall
    {
        public RandomSizeAndDirectionMoveBallFromPoint(Form mainForm, Point point) : base(mainForm)
        {
            CenterX = point.X;
            CenterY = point.Y;            
        }
    }
}
