namespace BallGames.Common
{
    public class RandomPointBall : Ball
    {
        protected static Random random = new Random();

        public RandomPointBall(Form mainForm) : base(mainForm)
        {
            CenterX = random.Next(LeftSide(), RightSide());
            CenterY = random.Next(TopSide(), DownSide());
        }
    }
}
