using Mastery.Engine;
using Mastery.States.Splash;

namespace Mastery
{
    public static class Program
    {
        private const int WIDTH = 1280;
        private const int HEIGHT = 720;

        public static void Main(string[] args)
        {
            using (var game = new MainGame(WIDTH, HEIGHT, new SplashState()))
                game.Run();
        }
    }
}