using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStoring data = new DataStoring();
            Console.OutputEncoding = Encoding.UTF8;
            /*
            for (int i = 0; i >= 13; i++)
            {
                if(args[i] == "-x")
                {
                    data.MaxX = Convert.ToInt32(args[i + 1]);
                }
                else if(args[i] == "-y")
                {
                    data.MaxY = Convert.ToInt32(args[i + 1]);
                }
                else if (args[i] == "-z")
                {
                    data.Zombies = Convert.ToInt32(args[i + 1]);
                }
                else if (args[i] == "-h")
                {
                    data.Humans = Convert.ToInt32(args[i + 1]);
                }
                else if (args[i] == "-Z")
                {
                    data.PZombies = Convert.ToInt32(args[i + 1]);
                }
                else if (args[i] == "-H")
                {
                    data.PHumans = Convert.ToInt32(args[i + 1]);
                }
                else if (args[i] == "-t")
                {
                    data.MaxTurn = Convert.ToInt32(args[i + 1]);
                }
            }
        }
        */
            Grid grid = new Grid(data);
            grid.Fill();
            Renderer renderer = new Renderer(data);
            GameLoop gameloop = new GameLoop(data, grid);
            gameloop.GameLoopStart();
        }
    }
}
