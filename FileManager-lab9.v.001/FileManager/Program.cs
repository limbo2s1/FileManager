using ComandsLib;

namespace Program;
class Program
{
    static void Main()
    {
        Manager manager = new Manager();

        while (true)
        {
            string comand = Console.ReadLine();
            ConsoleComandExecute(comand);
            Console.WriteLine(manager.ExecuteComand(comand));
        }
    }
    static void ConsoleComandExecute(string comandName)
    {
        switch (comandName)
        {
            case "exit":
                break;
            case "clear":
                Console.Clear();
                break;
        }
    }
}