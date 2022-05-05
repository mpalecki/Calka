using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie_4
{

    public class Program
    {

        static double sum = 0;
        private static Object zamek = new Object();

        static public void Calka(int p, int k)
        {

            double WartoscFunkcji(double x)
            {
                return 3 * Math.Pow(x, 3) + Math.Cos(7 * x) - Math.Log(2 * x);
            }

            double dx = 0.0000001;
            double lokalna = 0;

            for (double i = p; i < k; i += dx)
            {
                lokalna += dx * WartoscFunkcji(i);
            }
            lock (zamek)
            {
                sum += lokalna;
            }

        }

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();
            Parallel.Invoke(
                   () => Calka(1, 14),
                   () => Calka(14, 27),
                   () => Calka(27, 40)
               );
            stopwatch.Stop();

            Console.WriteLine(sum);

            Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds + "ms");


            Console.ReadKey();
        }
    }
}
