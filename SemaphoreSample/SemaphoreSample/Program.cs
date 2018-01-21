using System;
using System.Collections.Generic;
using System.Threading;

namespace SemaphoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc();

            var count = 10;

            var threads = new List<Thread>();
            for (var i=0;  i < count; i++)
            {
                var thread = new Thread(calc.Work);
                thread.Name = i.ToString();
                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.ReadLine();
        }
    }
}
