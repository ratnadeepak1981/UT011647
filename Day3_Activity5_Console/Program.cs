using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day3_Activity5_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0; 
            do
            {
                Console.Clear();
                Console.WriteLine("1 for Hello");
                Console.WriteLine("2 for GoodBye");
                Console.WriteLine("3 for Exit");

                Console.Write("Enter your choice > ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Hello");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("GoodBye");
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Exiting the menu");
                                choice = 3;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Choice");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }
                    Console.ReadKey();
            } while (choice!=3);
        }
    }
}
