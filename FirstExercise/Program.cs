using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FirstExercise
{
    class Program
    {
        static string filePath = @"C:\AsyncTraining";
        static List<FileInfo> filesData = new List<FileInfo>();
            
        public static void Main(string[] args)
        {
            MonitorDirectory(filePath);
            Console.ReadKey();
        }

        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = filePath;
            watcher.NotifyFilter = NotifyFilters.CreationTime
                                | NotifyFilters.FileName;

            watcher.Filter = "*.*";
            watcher.Created += OnFileCreated;
            watcher.EnableRaisingEvents = true;
        }

        private static void OnFileCreated(object source, FileSystemEventArgs e)
        {            
            ThreadPool.QueueUserWorkItem((state) =>
            {
                ThreadPool.GetMinThreads(out int wt, out int cp);
                ThreadPool.SetMinThreads(4, cp);
                ThreadPool.SetMaxThreads(4, cp);
                
                lock (filesData)
                {
                    filesData.Add(new FileInfo { FileName = e.Name, Content = File.ReadAllText(e.FullPath) });
                    if (filesData.Count == 10)
                    {
                        filesData.ForEach(f =>
                        {
                            Console.WriteLine($"File: {f.FileName}, contains data: {f.Content}");
                        });

                        filesData.Clear();
                    }
                }                
            });
        }
    }
}
