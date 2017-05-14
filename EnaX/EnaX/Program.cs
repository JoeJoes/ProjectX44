using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 01010111011001010110001001100101011100110111010001101111011011110110110001110011
namespace EnaX
{
    class Program
    {

        // Faktoriál
        static long fac(long n) {
            return n <= 1 ? 1 : n * fac(n - 1);
        }

        // Pozice první "platné cifry"
        static int mantissaPos(double n) {
            return (int) Math.Floor( Math.Log10( Math.Abs(n) ) + 1 );
        }

        // Výpočet taylorova rozvoje užitím double
        static double taylorDouble(double x, int precis) {
            // Hodnota pro porovnání
            double reference = Math.Exp(x);
            // Odchylka (podle počtu požadovaných platných cif.)
            double deviance = Math.Pow(10, - precis + mantissaPos(reference) );
            int i = 1;
            double res = 1;
            // Současný výsledek menší (nebo větší pro ref < 1) než reference-odchylka  =>  počítat další
            while ( reference < 1 ? Math.Abs(res) > Math.Abs(reference - deviance) : Math.Abs(res) < Math.Abs(reference - deviance) ) {
                res += (Math.Pow(x, i) / fac(i));
                i++;
            }
            return res;
        }

        // Výpočet taylorova rozvoje užitím float, postup stejný jako u double
        static float taylorFloat(double x, int precis) {
            float reference = (float)Math.Exp(x);
            float deviance = (float)Math.Pow(10, -precis + mantissaPos(reference));
            int i = 1;
            float res = 1;
            while (reference < 1 ? Math.Abs(res) > Math.Abs(reference - deviance) : Math.Abs(res) < Math.Abs(reference - deviance)) {
                res += (float)(Math.Pow(x, i) / fac(i));
                i++;
            }
            return res;
        }

        static void Main(string[] args) {
            // Požadovaná x
            double[] x = { -5.8, -1, 1, 5.8 };
            // Požadované přesnosti
            int[] precision = { 5, 7, 9 };

            // Vypsání výsledků do konzoly
            Console.Title = "Taylor a jeho rozvoj";
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < x.Length; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format("Vypocty pro x = {0}", x[i]));
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < precision.Length; j++) {
                    Console.WriteLine("------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(string.Format("e^{0} pro {1} platnych cifer:", x[i], precision[j]));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(string.Format("{0} | Math.Exp reference", Math.Exp(x[i])));
                    Console.WriteLine(string.Format("{0} | Double Taylor", taylorDouble(x[i], precision[j])));
                    Console.WriteLine(string.Format("{0}         | Float Taylor", taylorFloat(x[i], precision[j])));
                }
                Console.WriteLine("\n");
            }

            Console.Read();
        }
    }
}
