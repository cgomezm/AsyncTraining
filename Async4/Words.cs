using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Async4
{
    public static class Words
    {
        static List<Task> tasks = new List<Task>();

        public static void Run()
        {
            var files = Directory.GetFiles(@"C:\dataAsyncTraining", "*", SearchOption.TopDirectoryOnly);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (var file in files)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    return ReadFile(file).Split('\n');
                })
                .ContinueWith((antecedent) =>
                {
                    var t1 = WordCount(antecedent.Result);
                    var t2 = DistinctWordCount(antecedent.Result);
                    var t3 = WordSearch(antecedent.Result, "Camilo");
                    var t4 = GroupByCategory(antecedent.Result);

                    Task.WaitAll(t1, t2, t3, t4);

                    return new
                    {
                        WordCound = t1.Result,
                        DistinctWCount = t2.Result,
                        WordSearchResult = t3.Result,
                        WordGroup = t4.Result
                    };
                }));
            }

            Task.WaitAll(tasks.ToArray());
            stopWatch.Stop();
            Console.WriteLine("Program execution has finished");
            Console.WriteLine($"Elapsed time: {stopWatch.ElapsedMilliseconds} ms");
        }

        private static Task<int> WordCount(string[] text)
        {
            return Task.Factory.StartNew(() => { return text.Length; });
        }

        private static Task<int> DistinctWordCount(string[] text)
        {
            return Task.Factory.StartNew(() => {return text.Distinct().Count(); });
        }

        /// <summary>
        /// Search is case sensitive.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="queryWord"></param>
        /// <returns></returns>
        private static Task<string> WordSearch(string[] text, string queryWord)
        {
            return Task.Factory.StartNew(() => { return text.Any(p => p == queryWord) ? $"File contains word: {queryWord}" : $"Word: {queryWord} not found in file"; });
        }

        private static Task<IEnumerable<IGrouping<int, WordClass>>> GroupByCategory(string[] text)
        {
            return Task.Factory.StartNew(() => 
            {
                var r = new List<WordClass>();
                foreach (var t in text)
                {
                    r.Add(new WordClass() { Text = t, Lenght = t.Length });
                }

                return r.GroupBy(p => p.Lenght); 
            });
        }


        private static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }


    public class WordClass
    {
        public string Text { get; set; }
        public int Lenght { get; set; }
    }
}
