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
        public bool Infected { get; set; } = false;
        public int X;
        public int Y;
        private int Id { get; set; } = -1;
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
        public Agent(bool Infected, bool Playable, int x, int Y, int id)
        {
            this.Infected = Infected;
            if (Infected == true)
            {
                Icon = "z";
            }
            if (Infected == false)
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
        public Agent(bool Playable)
        {
            this.Playable = Playable;
            if (Infected == false)
            {
                Icon = "P";
            }
            if (Infected == true)
            {
                Icon = "Z";
            }
        }
        public void Zombify()
        {
            Icon = "z";
            Playable = false;
            Infected = true;
        }
        public void Copy(Agent agent, int x, int y)
        {
            this.Id = agent.Id;
            this.X = x;
            this.Y = y;
            this.Infected = agent.Infected;
            this.Playable = agent.Playable;
            this.Exists = true;
            this.Icon = agent.Icon;
        }

        public string IdString()
        {
            string result = Id.ToString("X2");
            return result;
        }
        public Agent(int x, int Y)
        {
            Exists = false;
            this.X = x;
            this.Y = Y;
        }
        public override string ToString()
        {
            string tmp = null;
            if (Exists == true)
                tmp += Icon;
            else
                tmp += "-";
            return tmp;
        }
        public Agent()
        {
            this.Exists = false;
        }
        public Grid Movement(Grid grid, Renderer renderer)
        {
            this.Moved = true;
            // CHANGE ALL OF THESE ABSOLUTE VALUES LATER.
            for (bool i = false; i == false;)
            {
                Console.Clear();
                Selected = true;
                renderer.RenderGame(Infected ,grid, X, Y);
                int tmpx = this.X;
                int tmpy = this.Y;
                switch (Console.ReadKey().KeyChar)
                {
                    case 'w':
                        if (Y != 0)
                        {
                            if(grid.tiles[this.X, this.Y - 1].Agents.Moved == false && grid.tiles[this.X, this.Y - 1].Agents.Exists == false)
                            {
                                Y--;
                                Selected = false;
                                Moved = true;
                                grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
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
                                    Selected = false;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
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
                                        Selected = false;
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
                    case 'a':
                        if (X != 0)
                        {
                            if (grid.tiles[this.X - 1, this.Y].Agents.Exists == false)
                            {
                                {
                                    if (grid.tiles[this.X - 1, this.Y].Agents.Moved == false)
                                    {
                                        X--;
                                        Selected = false;
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
                    case 'x':
                        if (Y != grid.Data.MaxY - 1)
                        {
                            if (grid.tiles[this.X, this.Y + 1].Agents.Exists == false)
                            {

                                {
                                    if (grid.tiles[this.X, this.Y + 1].Agents.Moved == false)
                                    {
                                        Y++;
                                        Selected = false;
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
                                        Selected = false;
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
                                        Selected = false;
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
                    case 'd':
                        if (X != grid.Data.MaxX - 1)
                        {
                            if (grid.tiles[this.X + 1, this.Y].Agents.Exists == false)
                            {
                                {
                                    if (grid.tiles[this.X + 1, this.Y].Agents.Moved == false)
                                    {
                                        X++;
                                        Selected = false;
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
                        if (Infected == true)
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
                                        else if (grid.tiles[X + p, Y + l].Agents.Infected == false && grid.tiles[X + p, Y + l].Agents.Exists)
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

        public string Description()
        {
            string tmp = "";
            if (Exists == true)
            {
                if (Infected == true)
                {
                    tmp += "You see a zombie.";
                }
                else if (Infected == false)
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
        /*
        public Grid AIMovement(Grid grid)
        {
            this.Moved = true;
            bool attacked = false;
            // CHANGE ALL OF THESE ABSOLUTE VALUES LATER.
            for (bool i = false; i == false;)
            {
                if (Infected == true)
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
                                else if (grid.tiles[X + p, Y + l].Agents.Infected == false && grid.tiles[X + p, Y + l].Agents.Exists)
                                {
                                    grid.tiles[X + p, Y + l].Agents.Zombify();
                                    attacked = true;
                                }
                            }
                        }
                    }
                }
                int tmpx = this.X;
                int tmpy = this.Y;
                if (!attacked)
                {
                    switch (grid.random.Next(1, 8))
                    {
                        case '1':
                            if (Y != 0)
                            {
                                if (grid.tiles[this.X, this.Y - 1].Agents.Moved == false && grid.tiles[this.X, this.Y - 1].Agents.Exists == false)
                                {
                                    Y--;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    Exists = false;
                                    i = true;
                                }
                            }
                            break;
                        case '2':
                            if (Y != 0 && X != 0 && grid.tiles[this.X - 1, this.Y - 1].Agents.Exists == false)
                            {
                                if (grid.tiles[this.X - 1, this.Y - 1].Agents.Moved == false)
                                {
                                    Y--;
                                    X--;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    Exists = false;
                                    i = true;
                                }
                            }
                            break;
                        case '3':
                            if (Y != grid.Data.MaxY && X != 0 && grid.tiles[this.X - 1, this.Y + 1].Agents.Exists == false)
                            {
                                if (grid.tiles[this.X - 1, this.Y + 1].Agents.Moved == false)
                                {
                                    Y++;
                                    X--;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    Exists = false;
                                    i = true;
                                }
                            }
                            break;
                        case '4':
                            if (X != 0 && grid.tiles[this.X - 1, this.Y].Agents.Exists == false)
                            {
                                if (grid.tiles[this.X - 1, this.Y].Agents.Moved == false)
                                {
                                    X--;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    Exists = false;
                                    i = true;
                                }
                            }
                            break;
                        case '5':
                            if (Y != grid.Data.MaxY - 1 && grid.tiles[this.X, this.Y + 1].Agents.Exists == false)
                            {
                                if (grid.tiles[this.X, this.Y + 1].Agents.Moved == false)
                                {
                                    Y++;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    Exists = false;
                                    i = true;
                                }
                            }
                            break;
                        case '6':
                            if (Y != grid.Data.MaxY && X != grid.Data.MaxX && grid.tiles[this.X + 1, this.Y + 1].Agents.Exists == false)
                            {
                                if (grid.tiles[this.X + 1, this.Y + 1].Agents.Moved == false)
                                {
                                    Y++;
                                    X++;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    Exists = false;
                                    i = true;
                                }
                            }
                            break;
                        case '7':
                            if (Y != 0 && X != grid.Data.MaxX && grid.tiles[this.X + 1, this.Y - 1].Agents.Exists == false)
                            {
                                if (grid.tiles[this.X + 1, this.Y - 1].Agents.Moved == false)
                                {
                                    Y--;
                                    X++;
                                    Moved = true;
                                    grid.tiles[this.X, this.Y].Agents.Copy(this, X, Y);
                                    Exists = false;
                                    i = true;
                                }
                            }
                            break;
                        case '8':
                            if (X != grid.Data.MaxX - 1 && grid.tiles[this.X + 1, this.Y].Agents.Exists == false)
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
                            break;
                    }
                }
            }
            return grid;
        } */
        public bool Confirm()
        {
            bool check = false;
            for (bool i = false; i == false;)
            {
                Console.WriteLine("Is this the outcome you wish? y or n");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    check = true;
                    i = true;
                }
                else if (answer == "n" || answer == "N")
                {
                    check = false;
                    i = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
            return check;
        }
    }
}
