using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Renderer
    {
        string tmpL;
        /// <summary>
        /// Initializing with Data.
        /// </summary>
        /// <param name="data"></param>
        public Renderer(DataStoring data)
        {
            this.data = data;
        }
        /// <summary>
        /// Empty initializer so it can be later added the data.
        /// </summary>
        public Renderer()
        {

        }
        DataStoring data = new DataStoring();
        /// <summary>
        /// Renders the menu.
        /// </summary>
        public void RenderMenu()
        {
            Console.WriteLine("--------------------Welcome!----------------------");
            Console.WriteLine("--------------Current Settings are: -------------- \n");
            Console.WriteLine($"          Grid X: {data.MaxX}       Grid Y:" +
                $" {data.MaxY} \n");
            Console.WriteLine($"       Zombie Nº: {data.Zombies}    PC Player Nº:" +
                $" {data.Humans} \n");
            Console.WriteLine($"    PC Zombie Nº: {data.Zombies}    PC Humans Nº:" +
                $" {data.Humans} \n");
            Console.WriteLine($"                 Max Turns: {data.MaxTurn} \n");
            Console.WriteLine($"If");
            Console.WriteLine("           Press any key to begin.     ");
            Console.ReadKey();
        }

        /// <summary>
        /// Renders the contextual information given.
        /// </summary>
        /// <param name="infected"></param>
        /// <param name="grid"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void RenderDirections(int infected, Grid grid, int X, int Y)
        {
            string tmp = "";
            if (infected == 1)
            {
                tmp += "You are infected Nº " + grid.tiles[X, Y].Agents.IdString() +  " \n";
            }
            else if (infected == 0)
            {
                tmp += "You are a Human Nº " + grid.tiles[X, Y].Agents.IdString() + " \n";
            }
            else if (infected == 2)
            {
                tmp += "You are in Auto Mode. Press Any key for next turn.";

            }
            if (infected == 2)
            {
                Console.Write(tmp);
                Console.ReadKey();
                Console.Clear();
            }
            else
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
                            else if (p == -1 && l == -1)
                            {
                                tmp += "(q) NW: ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                            else if (p == -1 && l == 0)
                            {
                                tmp += "(a) W:  ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                            else if (p == -1 && l == 1)
                            {
                                tmp += "(q) SW: ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                            else if (p == 0 && l == -1)
                            {
                                tmp += "(w) N:  ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                            else if (p == 0 && l == 1)
                            {
                                tmp += "(x) S:  ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                            else if (p == 1 && l == -1)
                            {
                                tmp += "(e) NE: ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                            else if (p == -1 && l == 0)
                            {
                                tmp += "(d) E:  ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                            else if (p == -1 && l == 11)
                            {
                                tmp += "(c) SE: ";
                                tmp += grid.tiles[X + p, Y + l].Agents.Description();
                                tmp += "\n";
                            }
                        }
                    }
                }
                Console.Write(tmp);
            }
        }
        /// <summary>
        /// Renders the game's grid and its Agents.
        /// </summary>
        /// <param name="PO"></param>
        /// <param name="grid"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void RenderGame(int PO ,Grid grid, int X, int Y)
        {
            for (int i = 0; i < data.MaxX; i++)
            {
                for (int j = 0; j < data.MaxY; j++)
                {
                    tmpL = grid.tiles[j, i].Agents.Icon + grid.tiles[j, i].Agents.IdString();
                    if (grid.tiles[j, i].Agents.Exists)
                    {
                        if (grid.tiles[j, i].Agents.Infected == 1 &&
                        grid.tiles[j, i].Agents.Playable == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (grid.tiles[j, i].Agents.Infected == 1 &&
                            grid.tiles[j, i].Agents.Playable == false)
                        {
                            if(grid.tiles[j, i].Agents.Selected == true)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                grid.tiles[j, i].Agents.Selected = false;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if (grid.tiles[j, i].Agents.Infected == 0 &&
                            grid.tiles[j, i].Agents.Playable == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (grid.tiles[j, i].Agents.Infected == 0 &&
                            grid.tiles[j, i].Agents.Playable == false)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write(tmpL);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" - ");
                        Console.ResetColor();
                    }
                    tmpL = "  ";
                    Console.Write(tmpL);
                }

                Console.Write("\n \n");
            }
            RenderDirections(PO ,grid, X, Y);
        }
    }
}