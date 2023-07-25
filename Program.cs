using Mastery.Engine;
using Mastery.States.Dev;
using Mastery.States.Splash;

namespace Mastery
{
    public static class Program
    {
        private const int Width = 1280;
        private const int Height = 720;

        public static void Main(string[] args)
        {
            using (var game = new MainGame(Width, Height, new SplashState()))
                game.Run();
        }
    }
}