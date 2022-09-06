using System;
using System.IO;

namespace TestSystemFileWatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //path
            var monitorFolder = @"C:\Documents\MyFolderTest";

            //create a new FileSystemWatcher and set its properties
            var watcher = new FileSystemWatcher(monitorFolder)
            {
                //watch all files
                Filter = "*.*", 
                //watch for all changes specified in the NotifyFilters
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Attributes,
                //start monitoring
                EnableRaisingEvents = true
            };

            //add event handlers.
            watcher.Changed += OnActionOccurOnFolderPath;
            watcher.Created += OnActionOccurOnFolderPath;
            watcher.Deleted += OnActionOccurOnFolderPath;
            watcher.Renamed += OnFileRenameOccur;

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();

        }

        //Methods to define event handlers

        private static void OnActionOccurOnFolderPath(object source, FileSystemEventArgs e)
        {
            // specify what is done when a file is changed.
            Console.WriteLine();
            Console.WriteLine("====== Ocorreu alguma alteração de arquivo ======");
            Console.WriteLine();
            Console.WriteLine(e.ChangeType);
            Console.WriteLine(e.FullPath);
            Console.WriteLine(e.Name);      
            
        }

        private static void OnFileRenameOccur(object source, RenamedEventArgs e)
        {
            //specify what is done when a file is renamed  
            Console.WriteLine();
            Console.WriteLine("====== Nome do arquivo alterado ======");
            Console.WriteLine();
            Console.WriteLine(e.ChangeType);
            Console.WriteLine($"Nome anterior => {e.OldFullPath}");
            Console.WriteLine($"Novo nome => {e.FullPath}");
        }

    }
}
