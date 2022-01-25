using System.Media;

namespace Game
{
    public class MusicPlayer
    {

        // constructor to initialize streams and clip
        SoundPlayer player;
        public MusicPlayer(string filePath)
        {
            player = new SoundPlayer();
            player.SoundLocation = filePath;
        }
        public MusicPlayer() { }


        public void play()
        {
            player.Play();
        }

        public void loop()
        {
            player.PlayLooping();
        }

        public void close()
        {
            player.Stop();
        }
    }
}