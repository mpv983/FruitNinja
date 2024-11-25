namespace BallGames.Common
{
    public class MoveBall : RandomSizeAndPointBall
    {
        public MoveBall(Form mainForm) : base(mainForm)
        {
            int size = 100;
            int converted = (int)DirectionRandomDiapasone * size;
            while (true)
            {
                vx = ((float)random.Next(-converted, converted))/size;
                if (vx != 0)
                {
                    break;
                }
            }
            while (true)
            {
                vy = ((float)random.Next(-converted, converted)) / size;
                if (vy != 0)
                {
                    break;
                }
            }
        }
    }
}
