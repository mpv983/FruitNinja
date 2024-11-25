namespace BallGames.Common
{
    public class PalletsRepository
    {
        static Random random = new Random();
        public static readonly List<Pallete> All = new List<Pallete>();
        
        public Pallete Pallete1 = new Pallete(new List<Color>()
        {
            Color.FromArgb(41, 191, 18),
            Color.FromArgb(171, 255, 79),
            Color.FromArgb(242, 27, 63)
        });
        public Pallete Pallete2 = new Pallete(new List<Color>()
        {
            Color.FromArgb(141, 153, 174),
            Color.FromArgb(239, 35, 60),
            Color.FromArgb(217, 4, 41)
        });
        public Pallete Pallete3 = new Pallete(new List<Color>()
        {
            Color.FromArgb(255, 234, 0),
            Color.FromArgb(255, 170, 0),
            Color.FromArgb(255, 123, 0)
        });
        public Pallete Pallete4 = new Pallete(new List<Color>()
        {
            Color.FromArgb(254, 74, 73),
            Color.FromArgb(254, 215, 102),
            Color.FromArgb(0, 159, 183)
        });
        public Pallete Pallete5 = new Pallete(new List<Color>()
        {
            Color.FromArgb(1, 22, 39),
            Color.FromArgb(255, 51, 102),
            Color.FromArgb(46, 196, 182)
        });

        public PalletsRepository()
        {
            All.Add(Pallete1);
            All.Add(Pallete2);
            All.Add(Pallete3);
            All.Add(Pallete4);
            All.Add(Pallete5);
        }
        public Pallete GetRandom()
        {
            return All[random.Next(0, All.Count)];
        }
    }
}
