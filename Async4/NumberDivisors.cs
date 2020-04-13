using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Async4
{
    public static class NumberDivisors
    {
        public static void Run()
        {
            Console.WriteLine("Running single thread");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = CountDivisor();
            stopwatch.Stop();
            Console.WriteLine($"The number: {result.Item1}, has the larger number of divisor: {result.Item2}");
            Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("Running multi thread");
            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var result2 = CountDivisorThreads();
            stopwatch2.Stop();            
            Console.WriteLine($"The number: {result2.Item1}, has the larger number of divisor: {result2.Item2}");
            Console.WriteLine("Elapsed time: " + stopwatch2.ElapsedMilliseconds + " ms");
            Console.WriteLine("-------------------------------------------------------------------");
        }

        static Tuple<int, int> result = new Tuple<int, int>(0, 0);

        public static Tuple<int, int> CountDivisorThreads(int from = 1, int to = 100000)
        {
            List<Thread> threads = new List<Thread>();
            int threadCount = 10;
            int numbersInThread = to / threadCount;
            int start = from;
            int end = start + numbersInThread;
            for (int i = 0; i < threadCount; i++)
            {
                if (i == threadCount - 1)
                    end = to;

                var thread = new Thread(() =>
                {
                    CountDivisor(start, end, threadSafe: true);
                });

                threads.Add(thread);
                thread.Start();
                start = end + 1;
                end = start + numbersInThread;
            }

            threads.ForEach(p => { while (p.IsAlive) p.Join(); });

            return result;
        }

        public static Tuple<int, int> CountDivisor(int from = 1, int to = 100000, bool threadSafe = false)
        {
            for (int i = from; i <= to; i++)
            {
                int count = 0;
                for (int f = 1; f < i; f++)
                {
                    if (i % f == 0)
                        count++;
                }

                if (threadSafe)
                {
                    lock (result)
                    {
                        if (result.Item2 < count)
                            result = new Tuple<int, int>(i, count);
                    }
                }
                else
                {
                    if (result.Item2 < count)
                        result = new Tuple<int, int>(i, count);
                }
            }

            return result;
        }


        //couldn´t get this work IDEAS??
        public static Tuple<int, int> CalculateDivisorThreadPool(int from = 1, int to = 100000)
        {
            for (int i = from; i <= to; i++)
            {
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    int counter = 0;
                    for (int f = 1; f <= i; f++)
                    {
                        if (i % f == 0)
                            counter++;
                    }

                    lock (result)
                    {
                        if (result.Item2 < counter)
                            result = new Tuple<int, int>(i, counter);
                    }
                });
            }

            return result;
        }        
    }
}
