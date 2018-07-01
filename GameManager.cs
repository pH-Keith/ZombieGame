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
            if(auto == false)
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
                        else
                        {
                            grid = grid.tiles[j, i].Agents.AIMovement(grid);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < data.MaxX; i++)
                {
                    for (int j = 0; j < data.MaxY; j++)
                    {
                        if (grid.tiles[j, i].Agents.Moved == false)
                        {
                            grid = grid.tiles[j, i].Agents.AIMovement(grid);
                        }
                    }
                }
                for (int i = 0; i < data.MaxX; i++)
                {
                    for (int j = 0; j < data.MaxY; j++)
                    {
                        grid.tiles[j, i].Agents.Moved = false;
                    }
                }
            }
            
        return grid;
        }
    }
}
