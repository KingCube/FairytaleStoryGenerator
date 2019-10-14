using System;

namespace FairytaleStoryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            PathManager pathManager = new PathManager();
            pathManager.Start();
            Console.ReadKey();
        }
    }
}
