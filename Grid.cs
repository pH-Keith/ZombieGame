using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Grid : DataStoring
    {
        Random random = new Random();
        public DataStoring Data { get; set; }
        public Grid(DataStoring Data)
        {
            this.Data = Data;
            tiles = new Tile[Data.MaxY, Data.MaxY];
        }
        public Grid()
        {

        }

        public void Copy(Grid grid)
        {
            this.tiles = grid.tiles;
            this.Data = grid.Data;
        }

        public Tile[,] tiles= new Tile[,] { };



        public void Fill()
        {
            for (int i = 0; i < Data.MaxX; i++)
            {
                for (int j = 0; j < Data.MaxY; j++)
                {
                    tiles[j, i] = new Tile(j, i);
                }
            }
            List<double> XZombcup = new List<double>();
            List<double> YZombcup = new List<double>();
            List<double> XHumacup = new List<double>();
            List<double> YHumacup = new List<double>();
            int id = 0;
            double tmp1;
            double tmp2;
            int tmp3;
            int tmp4;
            int safe = 0;
            //GENERIC ZOMBIES
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
                    tiles[tmp3, tmp4].Agents = new Agent(true, false, tmp3, tmp4, id);
                    id++;
                    i++;
                }
                else
                {
                    safe = 0;
                }
            }
            // PLAYABLE ZOMBIES
            for(int i = 0; i < Data.PZombies; i++)
            {
                int rng = random.Next(0, XZombcup.Count - 1);
                double[] Xarray = XZombcup.ToArray();
                double[] Yarray = YZombcup.ToArray();
                double xtmp = Xarray[rng];
                double ytmp = Yarray[rng];
                tiles[Convert.ToInt32(xtmp), Convert.ToInt32(ytmp)].Agents.Playable = true;
                XZombcup.RemoveAt(rng);
                YZombcup.RemoveAt(rng);
            }
            
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
                if(safe > 0)
                {
                    tmp3 = Convert.ToInt32(Math.Round(tmp1, MidpointRounding.ToEven));
                    XHumacup.Add(tmp3);
                    tmp4 = Convert.ToInt32(Math.Round(tmp2, MidpointRounding.ToEven));
                    YHumacup.Add(tmp4);
                    tiles[tmp3, tmp4].Agents = new Agent(false, false, tmp3, tmp4, id);
                    id++;
                    i++;
                }
                else
                {
                    safe = 0;
                }
            }
        }
    }
}
