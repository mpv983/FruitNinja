namespace BallGames.Common
{
    public class BallBrushes
    {
        static Random random = new Random();
        public static Color GetRandomFromPallete(Pallete pallete)
        {
            var index = random.Next(0, pallete.Colors.Count);
            return pallete.Colors[index];
        }
    }
}
