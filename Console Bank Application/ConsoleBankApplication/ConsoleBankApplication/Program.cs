using static System.Net.Mime.MediaTypeNames;

namespace ConsoleBankApplication
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
           ConsoleMenu menu = new ConsoleMenu();
           menu.Run();
        }
    }
}
