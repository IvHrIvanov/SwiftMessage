using Icard.FileReader;
using System;
using System.IO;
using System.Text;

namespace Icard.EventMethods
{
    public class WatcherMethod
    {
        private static StringBuilder sb;
        private readonly TextFileReader reader = new TextFileReader();
        public void OnFileRename(object sender, RenamedEventArgs e) //Use method when file is Renamed
        {
            sb = new StringBuilder();
            string result = reader.FileReader(e.Name);
            sb.AppendLine("==File Name Changed==");
            sb.AppendLine($"Old Name -> {e.OldName}");
            sb.AppendLine($"New Name -> {e.Name}");
            sb.AppendLine(result);
            Console.WriteLine(sb.ToString());
        }
        public void OnActionOnFolderPath(object sender, FileSystemEventArgs e)//Use method when file is created
        {
            sb = new StringBuilder();
            sb.AppendLine($"==File {e.ChangeType}==");
            sb.AppendLine($"{e.ChangeType} -> {e.Name}");

            string result = reader.FileReader(e.Name);
            sb.AppendLine(result);
            Console.WriteLine(sb.ToString());
        }
    }
}