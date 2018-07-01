using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class GameManager
    {
        DataStoring data = new DataStoring();
        Grid grid = new Grid();
        bool auto = false;
        public int survivors = 0;
        public int zombies = 0;
        public GameManager(Grid grid, DataStoring data)
        {
            this.data = data;
            this.grid = grid;
        }
        public GameManager()
        {

        }
        List<Agent> AIList = new List<Agent>();
        public Grid ManageGame(Renderer renderer)
        {
            this.zombies = 0;
            this.survivors = 0;
            AIMovement AI = new AIMovement();
            for (int i = 0; i < data.MaxX; i++)
            {
                for (int j = 0; j < data.MaxY; j++)
                {
                    if (grid.tiles[j, i].Agents.Playable == true && grid.tiles[j, i].Agents.Moved == false && grid.tiles[j, i].Agents.Exists == true)
                    {
                        grid.Copy(grid.tiles[j, i].Agents.Movement(grid, renderer));
                    }
                    else if (grid.tiles[j, i].Agents.Exists)
                    {
                        if (grid.tiles[j, i].Agents.Infected == 1)
                        {
                            zombies += 1;
                        }
                        else if (grid.tiles[j, i].Agents.Infected == 0)
                        {
                            survivors += 1;
                        }
                        AIList.Add(grid.tiles[j, i].Agents);
                    }
                }
            }
           
            grid.Copy(AI.AIMovementent(grid, AIList));
                for (int i = 0; i < data.MaxX; i++)
                {
                    for (int j = 0; j < data.MaxY; j++)
                    {
                        grid.tiles[j, i].Agents.Moved = false;
                    }
                }
            AIList.Clear();
            if (survivors == 0)
            {
                Console.Clear();
                Console.WriteLine("SIMULATION FINISHED.");
                Console.WriteLine("Zombies are the only Agents left. Press any Key to close");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return grid;
        }
    }
}
