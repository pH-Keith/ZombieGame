﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class GameLoop
    {
        DataStoring data = new DataStoring();
        Grid grid = new Grid();
        Renderer renderer = new Renderer();
        GameManager gamemanager = new GameManager();
        /// <summary>
        /// Constructor to initialize all of its components.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="grid"></param>
        public GameLoop(DataStoring data, Grid grid)
        {
            this.data = data;
            this.grid = grid;
            this.renderer = new Renderer(data);
            gamemanager = new GameManager(grid, data);

        }
        /// <summary>
        /// Starts the gameLoop and keeps it until max turns are done.
        /// </summary>
        public void GameLoopStart()
        {
            renderer.RenderMenu();
            Console.Clear();
            for(bool i = false; i == false;)
            {
                Console.Clear();
                grid.Copy(gamemanager.ManageGame(renderer));
                data.CurrentTurn += 1;
                if (data.CurrentTurn == data.MaxTurn)
                {
                    int Survivors = 0;
                    int Zombies = 0;
                    for (int j = 0; j < data.MaxX; j++)
                    {
                        for (int k = 0; k < data.MaxY; k++)
                        {
                            if(grid.tiles[j, k].Agents.Infected == 1 && grid.tiles[j, k].Agents.Exists == true)
                            {
                                Zombies++;
                            }
                            if (grid.tiles[j, k].Agents.Infected == 0 && grid.tiles[j, k].Agents.Exists == true)
                            {
                                Survivors++;
                            }
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("SIMULATION FINISHED.");
                    Console.WriteLine("Remaining Survivors: " + Survivors);
                    Console.WriteLine("Total Zombies: " + Zombies);
                    Environment.Exit(0);
                }
            }
        }
    }
}
