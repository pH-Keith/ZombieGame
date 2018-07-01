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
            if (!auto)
            {
                bool found = false;
                for (int i = 0; i < data.MaxX; i++)
                {
                    for (int j = 0; j < data.MaxY; j++)
                    {
                        if (grid.tiles[j, i].Agents.Playable)
                        {
                            found = true;
                        }
                    }
                }
                if (!found)
                {
                    auto = true;
                }
            }
            if(!auto)
            {
                for (int i = 0; i < data.MaxX; i++)
                {
                    for (int j = 0; j < data.MaxY; j++)
                    {
                        if (grid.tiles[j, i].Agents.Playable && !grid.tiles[j, i].Agents.Moved && grid.tiles[j, i].Agents.Exists)
                        {
                            grid.Copy(grid.tiles[j, i].Agents.Movement(grid, renderer));
                            grid.tiles[j, i].Agents.Moved = false;
                        }
                        else if(grid.tiles[j, i].Agents.Exists)
                        {
                            AIList.Add(grid.tiles[j, i].Agents);
                        }
                    }
                }
                AIMovement AI = new AIMovement();
                AI.AIMovementent(grid, AIList);

            }
            else
            {
                for (int i = 0; i < data.MaxX; i++)
                {
                    for (int j = 0; j < data.MaxY; j++)
                    {
                        if (grid.tiles[j, i].Agents.Moved == false && grid.tiles[j, i].Agents.Exists)
                        {
                            AIList.Add(grid.tiles[j, i].Agents);
                        }
                    }
                }
                AIMovement AI = new AIMovement();
                AI.AIMovementent(grid, AIList);
                for (int i = 0; i < data.MaxX; i++)
                {
                    for (int j = 0; j < data.MaxY; j++)
                    {
                        grid.tiles[j, i].Agents.Moved = false;
                    }
                }
                Console.ReadKey();
            }
            AIList.Clear();
        return grid;
        }
    }
}
