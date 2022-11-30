using FileManagerComandsLib.Comands;
using System.Reflection;

namespace ComandsLib
{
    public class Manager
    {

        public Manager()
        {
            SetComandsList();
        }

        private string[] _args;                 
        private static List<IComands> _comands = new List<IComands>();
        private void SetComandsList()
        {
            Assembly asm = Assembly.LoadFrom("FileManagerComandsLib.dll");
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if ((type.IsInterface == false) &&
                    (type.IsAbstract == false)&&
                    (type.GetInterface("IComands")!=null))
                {
                    IComands value = (IComands)Activator.CreateInstance(type);
                    _comands.Add(value);
                }
            }
        }
        public string ExecuteComand(string comand)
        {
            ParseComandString(comand);
            string result = "";
            foreach (IComands com in _comands)
            {
                if (com.ComandName().ContainsKey(_args[0]))
                {
                    result = com.Execute(_args);
                }
            }
            if (result == "")
                return "Error!";
            else
                return result;

        }
        /// <summary>
        /// "парсит" строку команды
        /// </summary>
        private void ParseComandString(string comand)
        {
            _args = comand.Split(' ');
            
        }
        /// <summary>
        /// Возвращает справку по всем командам
        /// </summary>
        /// <returns></returns>
        public string ComandsInfo()
        {
            return "Какую-то информацию";
        }

    }
}