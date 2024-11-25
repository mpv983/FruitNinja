namespace BallGames.Common
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        protected int minRandomRadius = 20;
        protected int maxRandomRadius = 60;
        public RandomSizeAndPointBall(Form mainForm) : base(mainForm)
        {
            Radius = random.Next(minRandomRadius, maxRandomRadius);
        }
        public void SetRandomRadius(int min, int max)
        {
            minRandomRadius = min;
            maxRandomRadius = max;
            Radius = random.Next(minRandomRadius, maxRandomRadius);
        }
    }
}
