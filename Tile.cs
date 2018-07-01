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
        /// <summary>
        /// Defines its position in the Grid on the Y axis.
        /// </summary>
        public Tile(int x, int y)
        {
            Agents = new Agent(x, y);
        }
        public Agent Agents = new Agent();
        public void Copy(Agent Agents)
        {
            this.Agents = Agents;
        }
    }
}
