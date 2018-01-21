using System;
using System.Threading;

namespace SemaphoreSample
{
    public class Calc
    {
        private Semaphore _semaphore;

        public Calc()
        {
            _semaphore = new Semaphore(3, 3);
        }

        public void Work()
        {
            Console.WriteLine("start... " + Thread.CurrentThread.Name);

            _semaphore.WaitOne();
            Console.WriteLine("work start " + Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            Console.WriteLine("work end " + Thread.CurrentThread.Name);
            _semaphore.Release();

            Console.WriteLine("end... " + Thread.CurrentThread.Name);
        }
    }
}
