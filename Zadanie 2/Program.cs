using System;
using System.Diagnostics;
using System.Threading;

namespace Zadanie_2
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

            for (double i = p; i < k; i += dx)
            {
                lock (zamek)
                {
                    sum += dx * WartoscFunkcji(i);
                }

            }

        }

        static void LiczWielow()
        {
            Thread t1 = new Thread(() => Calka(1, 14));
            t1.Start();
            Thread t2 = new Thread(() => Calka(14, 27));
            t2.Start();
            Thread t3 = new Thread(() => Calka(27, 40));
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine(sum);
        }

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();
            LiczWielow();
            stopwatch.Stop();

            Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds + "ms");

            Console.ReadKey();
        }
    }
}
