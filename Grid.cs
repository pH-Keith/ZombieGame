using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Grid : DataStoring
    {
        public Random random = new Random();
        public DataStoring Data { get; set; }
        /// <summary>
        /// Constructor that gives the grid the data it will require.
        /// </summary>
        /// <param name="Data"></param>
        public Grid(DataStoring Data)
        {
            this.Data = Data;
            tiles = new Tile[Data.MaxY, Data.MaxY];
        }
        /// <summary>
        /// Constructor that is empty for later use.
        /// </summary>
        public Grid()
        {

        }

        /// <summary>
        /// Used for copying the grid's information from one grid to another.
        /// The important information at least.
        /// </summary>
        /// <param name="grid"></param>
        public void Copy(Grid grid)
        {
            this.tiles = grid.tiles;
            this.Data = grid.Data;
        }

        public Tile[,] tiles= new Tile[,] { };



        /// <summary>
        /// Used to create the tiles with its information.
        /// </summary>
        public void Fill()
        {
            for (int i = 0; i < Data.MaxX; i++)
            {
                for (int j = 0; j < Data.MaxY; j++)
                {
                    tiles[j, i] = new Tile(j, i);
                }
            }
            // Lists to hold X and Y information of the zombies and human's location
            List<double> XZombcup = new List<double>();
            List<double> YZombcup = new List<double>();
            List<double> XHumacup = new List<double>();
            List<double> YHumacup = new List<double>();
            int id = 0;
            double tmp1;
            double tmp2;
            int tmp3;
            int tmp4;
            // Variable to make sure it does not place a Agent on an ocupied grid.
            int safe = 0;
            //Creates AI zombies and uses the lists to store information on
            // their location.
            for (int i = 0; i <= Data.Zombies;)
            {
                tmp1 = (random.Next(Data.MaxX));
                if (!XZombcup.Contains(tmp1))
                {
                    safe++;
                }
                tmp2 = (random.Next(Data.MaxY));
                if (!YZombcup.Contains(tmp2))
                {
                    safe++;
                }
                if (safe >= 0)
                {
                    tmp3 = Convert.ToInt32(Math.Round(tmp1, MidpointRounding.ToEven));
                    XZombcup.Add(tmp3);
                    tmp4 = Convert.ToInt32(Math.Round(tmp2, MidpointRounding.ToEven));
                    YZombcup.Add(tmp4);
                    tiles[tmp3, tmp4].Agents = new Agent(1, false, tmp3, tmp4, id);
                    id++;
                    i++;
                }
                else
                {
                    safe = 0;
                }
            }
            // Playable zombie generation.
            for (int i = 0; i < Data.PZombies; i++)
            {
                int rng = random.Next(0, XZombcup.Count - 1);
                double[] Xarray = XZombcup.ToArray();
                double[] Yarray = YZombcup.ToArray();
                double xtmp = Xarray[rng];
                double ytmp = Yarray[rng];
                tiles[Convert.ToInt32(xtmp), Convert.ToInt32(ytmp)].Agents.MakePlayable();
                XZombcup.RemoveAt(rng);
                YZombcup.RemoveAt(rng);
            }

            // AI human generation.
            for (int i = 0; i < Data.Humans;)
            {
                tmp1 = (random.Next(Data.MaxX));
                if (!XZombcup.Contains(tmp1) && !XHumacup.Contains(tmp1))
                {
                    safe++;
                }
                tmp2 = (random.Next(Data.MaxY));
                if (!YZombcup.Contains(tmp2) && !YHumacup.Contains(tmp2))
                {
                    safe++;
                }
                if (safe > 0)
                {
                    tmp3 = Convert.ToInt32(Math.Round(tmp1, MidpointRounding.ToEven));
                    XHumacup.Add(tmp3);
                    tmp4 = Convert.ToInt32(Math.Round(tmp2, MidpointRounding.ToEven));
                    YHumacup.Add(tmp4);
                    tiles[tmp3, tmp4].Agents = new Agent(0, false, tmp3, tmp4, id);
                    id++;
                    i++;
                }
                else
                {
                    safe = 0;
                }
            }
            // Playable human Generation.
            for (int i = 0; i < Data.PHumans; i++)
            {
                int rng = random.Next(0, XHumacup.Count - 1);
                double[] Xarray = XHumacup.ToArray();
                double[] Yarray = YHumacup.ToArray();
                double xtmp = Xarray[rng];
                double ytmp = Yarray[rng];
                tiles[Convert.ToInt32(xtmp), Convert.ToInt32(ytmp)].Agents.MakePlayable();
                XHumacup.RemoveAt(rng);
                YHumacup.RemoveAt(rng);
            }
        }
    }
}
