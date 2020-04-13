using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async4
{
    public static class FileWatcherTask
    {
        static string filePath = @"C:\AsyncTraining";
        static List<Task> tasks = new List<Task>();
        static List<Thread> threads = new List<Thread>();
        static ObservableCollection<FileInfo> filesData = new ObservableCollection<FileInfo>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option">q. Task, 2. MultiThread, 2. Async Task</param>
        public static void Run(int option)
        {
            filesData.CollectionChanged += Tasks_CollectionChanged;
            MonitorDirectory(option);
        }

        private static void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (filesData.Count == 10)
            {
                foreach (var f in filesData)
                {
                    Console.WriteLine($"File: {f.FileName}. Has content: {f.Content}");
                    //Console.WriteLine(f.FileName);
                }
                Environment.Exit(1);
            }
        }

        private static void MonitorDirectory(int option)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            
            watcher.Path = filePath;
            watcher.NotifyFilter = NotifyFilters.CreationTime
                                | NotifyFilters.FileName;

            watcher.Filter = "*.*";
            switch (option)
            {
                case 1:
                    Console.WriteLine("Running on Task based");
                    watcher.Created += OnFileCreated;
                    break;
                case 2:
                    Console.WriteLine("Running on MultiThread");
                    watcher.Created += OnFileCreatedThread;
                    break;
                case 3:
                    Console.WriteLine("Running on Async/await");
                    watcher.Created += OnFileCreatedThread;
                    break;
                default:
                    break;
            }
            watcher.EnableRaisingEvents = true;
        }

        private static void OnFileCreated(object source, FileSystemEventArgs e)
        {
            if (tasks.Where(p => p.Status == TaskStatus.WaitingToRun || p.Status == TaskStatus.Running).ToList().Count == 4)
            {
                Task.WaitAny(tasks.ToArray());
            }

            var t = Task.Factory.StartNew(() =>
            {
                lock (filesData)
                {
                    filesData.Add(new FileInfo
                    {
                        FileName = e.Name,
                        Content = File.ReadAllText(e.FullPath)
                    });
                }
            });

            tasks.Add(t);
        }

        private async static Task OnFileCreatedAsync(object source, FileSystemEventArgs e)
        {
            if (tasks.Where(p => p.Status == TaskStatus.WaitingToRun || p.Status == TaskStatus.Running).ToList().Count == 4)
            {
                await Task.WhenAny(tasks);
            }

            var t = Task.Factory.StartNew(() =>
            {
                lock (filesData)
                {
                    filesData.Add(new FileInfo
                    {
                        FileName = e.Name,
                        Content = File.ReadAllText(e.FullPath)
                    });
                }
            });

            tasks.Add(t);
        }

        private static void OnFileCreatedThread(object source, FileSystemEventArgs e)
        {
            var aliveThreads = threads.Where(p => p.IsAlive).ToList();
            if (aliveThreads.Count == 4)
            {
                aliveThreads.FirstOrDefault().Join();
            }

            var t = new Thread(() =>
            {
                lock (filesData)
                {
                    filesData.Add(new FileInfo
                    {
                        FileName = e.Name,
                        Content = File.ReadAllText(e.FullPath)
                    });
                }
            });

            t.Start();            
            threads.Add(t);
        }
    }
}
