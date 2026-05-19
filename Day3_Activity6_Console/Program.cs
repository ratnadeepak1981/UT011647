namespace Day3_Activity6_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Number = 0;
            Console.Write("Enter the Number : ");
            if(int.TryParse(Console.ReadLine(),out Number))
            for(int i = 1; i <= 1000; i++)
            {
                if((i% Number)  == 0)
                {
                        Console.WriteLine(i);
                        break;
                }
                 
            }
            Console.ReadKey();
        }
    }
}
