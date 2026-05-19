namespace Day2_Activity2_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your marks :");
            int Marks =int.Parse(Console.ReadLine());

            if (Marks >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            else if(Marks >= 80)
            {
                Console.WriteLine("Grade: B");
            }
            else if (Marks >= 70)
            {
                Console.WriteLine("Grade: C");
            }
            else if (Marks >= 60)
            {
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Grade F");
            }
            Console.ReadKey();
        }
    }
}
