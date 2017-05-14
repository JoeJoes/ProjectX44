using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            Stopwatch millis = new Stopwatch();
            int[] num = new int[20];
            //num[0] = 0;
            int n, o;
            n = num.Length;
            o = n / 5;
            int c;
            //string read = "0";
            Random r = new Random();
            Console.Write("Generuji náhodná čísla");
            millis.Start();
            for (int i = 0; i < n; i++)
            {
                num[i] = r.Next(-500000, 500001);
            }
            millis.Stop();
            Console.WriteLine("Čísla vygenerována ("+millis.Elapsed+")");
            Console.WriteLine("Začínám řadit čísla");
            int p = 0;
            bool s=false;
            time.Start();
            //while (s == false)
            for (int y = 0; y < n - 1; y++) 
            {
                millis.Restart();
                //millis.Start();
                p++;
                s = true;
                for (int i = 0; i < n - p; i++)
                {
                    if (num[i] > num[i + 1])
                    {
                        s = false;
                        c = num[i];
                        num[i] = num[i + 1];
                        num[i + 1] = c;
                    }
                }
                millis.Stop();
                Console.WriteLine(p + ". pass (" + millis.Elapsed + ")");

            }
            time.Stop();
            Console.WriteLine("Čísla seřazena za " + p + " cyklů (" + time.Elapsed + ")");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Convert.ToString(num[i]));
            }
            Console.WriteLine("Stiskem jakéhokoli tlačítka ukončíte");
            Console.ReadKey();
            
        }
    }
}
