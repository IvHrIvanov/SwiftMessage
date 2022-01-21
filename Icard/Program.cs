using Icard.EventMethods;
using Icard.Paths;
using Swift.Db;
using SwiftInitializator;
using System;
using System.IO;

namespace Icard
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new SwiftContext();
            DbInitializer.ResetDatabase(dbContext);
            Console.WriteLine("Db is Created!");
            WatcherMethod methods = new WatcherMethod();
            FileSystemWatcher watcher = new FileSystemWatcher(FolderPath.Folder_Path);
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.Size;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;
         
            watcher.Created += methods.OnActionOnFolderPath;
            watcher.Renamed += methods.OnFileRename;

            Console.WriteLine("Press eny key to exit");
            Console.ReadLine();
        }
    }
}