using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{
    internal class ComandDirectoryInfo:IComands
    {
        public string ComandInfo()
        {
            return "folder information";
        }
        private Dictionary<string, string> _comands = new Dictionary<string, string>()
        {
            {"DirectoryInfo",    "DirectoryInfo" },
            {"DI",               "DirectoryInfo" },
            {"di",               "DirectoryInfo" },
            {"directoryinfo",    "DirectoryInfo" }
        };
        public Dictionary<string, string> ComandName()
        {
            return _comands;
        }

        public string Execute(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(args[1]);

            string str = $"информация о файле:\n Имя: {directoryInfo.Name}" +
               $"|" +
               $"|Выполнен: {directoryInfo.CreationTime}" +
               $"|Атрибуты: {directoryInfo.Attributes}" +
               $"\n Полный путь: {directoryInfo.FullName}";

            return str;
            
        }
    }
}
