using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class AIMovement
    {
        public Grid AIMovementent(Grid grid, List<Agent> AgentList)
        {
            foreach (Agent agents in AgentList)
            {
                agents.Moved = true;
                bool attacked = false;
                // CHANGE ALL OF THESE ABSOLUTE VALUES LATER.
                if (agents.Infected == 1)
                {
                    for (int p = -1; p <= 1; p++)
                    {
                        if (agents.X == grid.Data.MaxX - 1 && p == 1)
                        {
                        }
                        else if (agents.X == 0 && p == -1)
                        {
                        }
                        else
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                if (agents.Y == grid.Data.MaxY - 1 && l == 1)
                                {
                                }
                                else if (agents.Y == 0 && l == -1)
                                {
                                }
                                else if (agents.Y == 0 && l == 0)
                                {

                                }
                                else if (grid.tiles[agents.X + p, agents.Y + l].Agents.Infected == 0 && grid.tiles[agents.X + p, agents.Y + l].Agents.Exists)
                                {
                                    int tmpx = agents.X + p;
                                    int tmpy = agents.Y + l;
                                    grid.tiles[tmpx, tmpy].Agents.Zombify();
                                    attacked = true;
                                }
                            }
                        }
                    }
                }
                for (bool i = false; i == false;)
                {
                    int tmpx = agents.X;
                    int tmpy = agents.Y;
                    int rng = grid.random.Next(8);
                    if (!attacked)
                    {
                        switch (rng)
                        {
                            case 1:
                                if (agents.Y != 0)
                                {
                                    if (grid.tiles[agents.X, agents.Y - 1].Agents.Moved == false && grid.tiles[agents.X, agents.Y - 1].Agents.Exists == false)
                                    {
                                        agents.Y--;
                                        agents.Moved = true;
                                        grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                        grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                        i = true;
                                    }
                                }
                                break;
                            case 2:
                                if (agents.Y != 0 && agents.X != 0)
                                {
                                    if (grid.tiles[agents.X - 1, agents.Y - 1].Agents.Exists == false)
                                    {
                                        {
                                            if (grid.tiles[agents.X - 1, agents.Y - 1].Agents.Moved == false)
                                            {
                                                agents.Y--;
                                                agents.X--;
                                                agents.Moved = true;
                                                grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                                grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                                i = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 3:
                                if (agents.Y != grid.Data.MaxY - 1 && agents.X != 0)
                                {
                                    if (grid.tiles[agents.X - 1, agents.Y + 1].Agents.Exists == false)
                                    {
                                        {
                                            if (grid.tiles[agents.X - 1, agents.Y + 1].Agents.Moved == false)
                                            {
                                                agents.Y++;
                                                agents.X--;
                                                agents.Moved = true;
                                                grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                                grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                                i = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 4:
                                if (agents.X != 0)
                                {
                                    if (grid.tiles[agents.X - 1, agents.Y].Agents.Exists == false)
                                    {
                                        {
                                            if (grid.tiles[agents.X - 1, agents.Y].Agents.Moved == false)
                                            {
                                                agents.X--;
                                                agents.Moved = true;
                                                grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                                grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                                i = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 5:
                                if (agents.Y != grid.Data.MaxY - 1)
                                {
                                    if (grid.tiles[agents.X, agents.Y + 1].Agents.Exists == false)
                                    {
                                        {
                                            if (grid.tiles[agents.X, agents.Y + 1].Agents.Moved == false)
                                            {
                                                agents.Y++;
                                                agents.Moved = true;
                                                grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                                grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                                i = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 6:
                                if (agents.Y != grid.Data.MaxY- 1 && agents.X != grid.Data.MaxX - 1)
                                {
                                    if (grid.tiles[agents.X + 1, agents.Y + 1].Agents.Exists == false)
                                    {
                                        {
                                            if (grid.tiles[agents.X + 1, agents.Y + 1].Agents.Moved == false)
                                            {
                                                agents.Y++;
                                                agents.X++;
                                                agents.Moved = true;
                                                grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                                grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                                i = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 7:
                                if (agents.Y != 0 && agents.X != grid.Data.MaxX - 1)
                                {
                                    if (grid.tiles[agents.X + 1, agents.Y - 1].Agents.Exists == false)
                                    {
                                        {
                                            if (grid.tiles[agents.X + 1, agents.Y - 1].Agents.Moved == false)
                                            {
                                                agents.Y--;
                                                agents.X++;
                                                agents.Moved = true;
                                                grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                                grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                                i = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 8:
                                if (agents.X != grid.Data.MaxX - 1)
                                {
                                    if (grid.tiles[agents.X + 1, agents.Y].Agents.Exists == false)
                                    {
                                        {
                                            if (grid.tiles[agents.X + 1, agents.Y].Agents.Moved == false)
                                            {
                                                agents.X++;
                                                agents.Moved = true;
                                                grid.tiles[agents.X, agents.Y].Agents.Copy(agents, agents.X, agents.Y);
                                                grid.tiles[tmpx, tmpy].Agents.Exists = false;
                                                i = true;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    i = true;
                }
            }
            return grid;
        }
    }
}
