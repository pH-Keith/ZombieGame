using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Tile
    {
        /// <summary>
        /// Defines its position in the Grid on the X axis.
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// Defines its position in the Grid on the Y axis.
        /// </summary>
        public int y { get; set; }
        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
            Agents = new Agent(x, y);
        }
        public Agent Agents = new Agent();
        public void Generation(Grid grid)
        {

        }
    }
}
