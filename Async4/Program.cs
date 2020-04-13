using System;
using System.Diagnostics;
using System.Threading;

namespace Async4
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "0";

            while (option == "0")
            {
                Console.WriteLine("Select program: 1. Divisors, 2. WordCounter");
                Console.WriteLine("1. Divisors");
                Console.WriteLine("2. WordCounter");
                Console.WriteLine("3. FileWatcherTask");
                Console.WriteLine("");
                Console.WriteLine("");

                option = Console.ReadLine();
                Console.Clear();
            }

            switch (option)
            {
                case "1":
                    Console.WriteLine("Running Program Divisors");
                    NumberDivisors.Run();
                    break;
                case "2":
                    Console.WriteLine("Running Program Words");
                    Words.Run();
                    break;
                case "3":
                    Console.WriteLine("Running Program FileWatcher Task");
                    Console.WriteLine("Select execution: 1. Task, 2. MultiThread, 3. Async/Await");                    
                    FileWatcherTask.Run(int.Parse(Console.ReadLine()));
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
