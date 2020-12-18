using System;
using System.Diagnostics;

namespace TailRec1
{
    class Program
    {
        static ulong TailRecIter(int b, int counter, int product)
        {
            return counter == 0 ? (ulong)product : TailRecIter(b, counter - 1, b * product);
        }

        static ulong TailRec(int b, int power)
        {
            return TailRecIter(b, power, 1);
        }

        static ulong UsualRec(int b, int power)
        {
            return power == 0 ? 1 : (ulong)b * UsualRec(b, power - 1);
        }

        static void Main(string[] args)
        {
            var y = 1;
            var x = 1;
            for (; x <= 30 && y <=15; x += 2, ++y)
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                Console.WriteLine($"x = {x}; y = {y}; x^y = {UsualRec(x, y)}");

                stopWatch.Stop();

                Console.WriteLine(stopWatch.Elapsed);
            }

            Console.ReadKey();
        }
    }
}
