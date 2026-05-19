namespace Day3_Activity2_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Number;
            Console.Write("Enter the Number between 1 to 12 : ");
            if (int.TryParse(Console.ReadLine(), out Number))
            {
                if (Number < 1 || Number > 12)
                {
                    Console.WriteLine("Number out of range (1-12)");
                }
                else
                {
                    for(int i = 1; i <= 12; i++)
                    {
                        int Multiply=i * Number;
                        Console.WriteLine($"{Number} X {i} = {Multiply} ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
            Console.ReadKey();
        }
    }
}
