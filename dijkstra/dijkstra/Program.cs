using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] topologie = new int[8,8];
            topologie[0, 0] = 0;
            topologie[0, 1] = 5;
            topologie[0, 4] = 9;
            topologie[1, 2] = 2;
            topologie[1, 3] = 3;
            topologie[3, 6] = 6;
            topologie[3, 8] = 10;
            topologie[4, 5] = 8;
            topologie[4, 8] = 20;
            topologie[5, 7] = 3;
            topologie[6, 7] = 5;
            topologie[6, 8] = 2;
            
        }

        public int dijkstra(int[,] hrany, int cil)
        {
            
            bool[] vrcholy = new bool[hrany.GetUpperBound(0)];
            
            
            
            
            return 0;
        }
    }
}
