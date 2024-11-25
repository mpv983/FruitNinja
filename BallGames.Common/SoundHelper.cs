using System.Media;

namespace BallGames.Common
{
    public static class SoundHelper
    {
        public static void Play(string path)
        {
            SoundPlayer player = new SoundPlayer(path);
            player.Play();
        }
    }

}
