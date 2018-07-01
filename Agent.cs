using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Agent
    {
        /// <summary>
        /// True Equal Zombie, False Equal Human
        /// </summary>
        public int Infected { get; set; }
        public int X;
        public int Y;
        public int Id { get; set; } = -1;
        public bool Moved = false;
        public bool Exists { get; set; }
        public bool Playable { get; set; }
        public bool Selected { get; set; }
        public string Icon { get; set; } = "-";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Infected">True Equal Zombie, False Equal Human</param>
        /// <param name="Playable"></param>
        /// <param name="x"></param>
        /// <param name="Y"></param>
        /// <param name="id"></param>
        public Agent(int Infected, bool Playable, int x, int Y, int id)
        {
            this.Infected = Infected;
            if (Infected == 1)
            {
                Icon = "z";
            }
            if (Infected == 0)
            {
                Icon = "p";
            }
            this.X = x;
            this.Y = Y;
            this.Moved = false;
            this.Playable = Playable;
            this.Exists = true;
            this.Id = id;
        }
        /// <summary>
        /// Used to change the agent's infected status.
        /// </summary>
        public void Zombify()
        {
            Icon = "z";
            Playable = false;
            Infected = 1;
        }
        /// <summary>
        /// Used to copy the Agent's information from one to another.
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Copy(Agent agent, int x, int y)
        {
            this.Id = agent.Id;
            this.X = x;
            this.Y = y;
            this.Infected = agent.Infected;
            this.Playable = agent.Playable;
            this.Selected = agent.Selected;
            this.Exists = true;
            this.Icon = agent.Icon;
            this.Moved = true;
        }
        /// <summary>
        /// Self explanatory.
        /// </summary>
        public void MakePlayable()
        {
            this.Playable = true;
        }

        /// <summary>
        /// Returns the id of the unit in HEX in a string.
        /// </summary>
        /// <returns></returns>
        public string IdString()
        {
            string result = Id.ToString("X2");
            return result;
        }
        /// <summary>
        /// Creates the agent with just the X and Y, so it can be filled later.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Y"></param>
        public Agent(int x, int Y)
        {
            Exists = false;
            this.X = x;
            this.Y = Y;
        }
        /// <summary>
        /// Used to give the renderer what it requires to render properly.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tmp = null;
            if (Exists == true)
                tmp += Icon;
            else
                tmp += "-";
            return tmp;
        }
        /// <summary>
        /// Creates "empty" agent.
        /// </summary>
        public Agent()
        {
            this.Exists = false;
        }
        /// <summary>
        /// Handles all of the player movement. Returns a grid which is modified
        /// with the players wish.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="renderer"></param>
        /// <returns></returns>
        public Grid Movement(Grid grid, Renderer renderer)
        {
            this.Moved = true;
            // Sets up everything required.
            for (bool i = false; i == false;)
            {
                Console.Clear();
                Selected = true;
                renderer.RenderGame(Convert.ToInt32(Infected), grid, X, Y);
                int tmpx = this.X;
                int tmpy = this.Y;
                ConsoleKeyInfo input;
                input = Console.ReadKey();
                // Handles all of the 8 directional inputs possible.
                switch (input.KeyChar)
                {
                    case 'w':
                        if (Y != 0)
                        {
                            if (grid.tiles[this.X, this.Y - 1].Agents.Moved == false && grid.tiles[this.X, this.Y - 1].Agents.Exists == false)
                            {
                                Y--;
                                Moved = true;
                                grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                grid.tiles[tmpx, tmpy].Agents.X = tmpx;
                                grid.tiles[tmpx, tmpy].Agents.Y = tmpy;
                                Exists = false;
                                i = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'q':
                        if (Y != 0 && X != 0)
                        {
                            if (grid.tiles[this.X - 1, this.Y - 1].Agents.Exists == false)
                            {
                                if (grid.tiles[this.X - 1, this.Y - 1].Agents.Moved == false)
                                {
                                    Y--;
                                    X--;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    grid.tiles[tmpx, tmpy].Agents.X = tmpx;
                                    grid.tiles[tmpx, tmpy].Agents.Y = tmpy;
                                    Exists = false;
                                    i = true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'z':
                        if (Y != grid.Data.MaxY && X != 0)
                        {
                            if (grid.tiles[this.X - 1, this.Y + 1].Agents.Exists == false)
                            {
                                {
                                    if (grid.tiles[this.X - 1, this.Y + 1].Agents.Moved == false)
                                    {
                                        Y++;
                                        X--;
                                        Moved = true;
                                        grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                        grid.tiles[tmpx, tmpy].Agents.X = tmpx;
                                        grid.tiles[tmpx, tmpy].Agents.Y = tmpy;
                                        Exists = false;
                                        i = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'a':
                        if (X != 0)
                        {
                            if (grid.tiles[this.X - 1, this.Y].Agents.Exists == false)
                            {
                                {
                                    if (grid.tiles[this.X - 1, this.Y].Agents.Moved == false)
                                    {
                                        X--;
                                        Moved = true;
                                        grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                        grid.tiles[tmpx, tmpy].Agents.X = tmpx;
                                        grid.tiles[tmpx, tmpy].Agents.Y = tmpy;
                                        Exists = false;
                                        i = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'x':
                        if (Y != grid.Data.MaxY - 1)
                        {
                            if (grid.tiles[this.X, this.Y + 1].Agents.Exists == false)
                            {

                                {
                                    if (grid.tiles[this.X, this.Y + 1].Agents.Moved == false)
                                    {
                                        Y++;
                                        Moved = true;
                                        grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                        grid.tiles[tmpx, tmpy].Agents.X = tmpx;
                                        grid.tiles[tmpx, tmpy].Agents.Y = tmpy;
                                        Exists = false;
                                        i = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'c':
                        if (Y != grid.Data.MaxY && X != grid.Data.MaxX)
                        {
                            if (grid.tiles[this.X + 1, this.Y + 1].Agents.Exists == false)
                            {
                                {
                                    if (grid.tiles[this.X + 1, this.Y + 1].Agents.Moved == false)
                                    {
                                        Y++;
                                        X++;
                                        Moved = true;
                                        grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                        grid.tiles[tmpx, tmpy].Agents.X = tmpx;
                                        grid.tiles[tmpx, tmpy].Agents.Y = tmpy;
                                        Exists = false;
                                        i = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'e':
                        if (Y != 0 && X != grid.Data.MaxX)
                        {
                            if (grid.tiles[this.X + 1, this.Y - 1].Agents.Exists == false)
                            {
                                {
                                    if (grid.tiles[this.X + 1, this.Y - 1].Agents.Moved == false)
                                    {
                                        Y--;
                                        X++;
                                        Moved = true;
                                        grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                        grid.tiles[tmpx, tmpy].Agents.X = tmpx;
                                        grid.tiles[tmpx, tmpy].Agents.Y = tmpy;
                                        Exists = false;
                                        i = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'd':
                        if (X != grid.Data.MaxX - 1)
                        {
                            if (grid.tiles[this.X + 1, this.Y].Agents.Exists == false)
                            {
                                {
                                    if (grid.tiles[this.X + 1, this.Y].Agents.Moved == false)
                                    {
                                        X++;
                                        Moved = true;
                                        grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                        Exists = false;
                                        i = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Space Ocupied, press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    case 'f':
                        if (Infected == 1)
                        {
                            for (int p = -1; p <= 1; p++)
                            {
                                if (X == grid.Data.MaxX - 1 && p == 1)
                                {
                                }
                                else if (X == 0 && p == -1)
                                {
                                }
                                else
                                {
                                    for (int l = -1; l <= 1; l++)
                                    {
                                        if (Y == grid.Data.MaxY - 1 && l == 1)
                                        {
                                        }
                                        else if (Y == 0 && l == -1)
                                        {
                                        }
                                        else if (Y == 0 && l == 0)
                                        {

                                        }
                                        else if (grid.tiles[X + p, Y + l].Agents.Infected == 0 && grid.tiles[X + p, Y + l].Agents.Exists)
                                        {
                                            grid.tiles[X + p, Y + l].Agents.Zombify();
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Input. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            return grid;
        }
        /// <summary>
        /// Used to add the description of the Agent.
        /// </summary>
        /// <returns></returns>
        public string Description()
        {
            string tmp = "";
            if (Exists == true)
            {
                if (Infected == 1)
                {
                    tmp += "You see a zombie.";
                }
                else if (Infected == 0)
                {
                    tmp += "You see a human.";
                }
            }
            else
            {
                tmp += "You see nothing there.";
            }
            return tmp;
        }
    }
}