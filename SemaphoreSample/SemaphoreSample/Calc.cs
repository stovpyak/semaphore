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
            try
            {
                Console.WriteLine("start... " + Thread.CurrentThread.Name);

                _semaphore.WaitOne();
                try
                {
                    Console.WriteLine("work start " + Thread.CurrentThread.Name);
                    Thread.Sleep(1000);
                    int b = 0;
                    var a = 123 / b;
                    Console.WriteLine("work end " + Thread.CurrentThread.Name);
                }
                finally
                {
                    _semaphore.Release();
                }

                Console.WriteLine("end... " + Thread.CurrentThread.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
