using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    public class DataStoring
    {
        public int MaxX { get; set; } = 20;
        public int MaxY { get; set; } = 20;
        public int Zombies { get; set; } = 10;
        public int Humans { get; set; } = 30;
        public int PZombies { get; set; } = 1;
        public int PHumans { get; set; } = 2;
        public int MaxTurn { get; set; } = 1000;
        public int CurrentTurn { get; set; } = 0;
    }
}
