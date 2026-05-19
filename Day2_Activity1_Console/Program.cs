namespace Day2_Activity1_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Console.Write("Entry your age :");
            int Age = Convert.ToInt32(Console.ReadLine());
            if(Age>17)
            {
                Console.WriteLine("You are elegible to vote");
            }
            else
            {
                Console.WriteLine("You are not elegible to vote");
            }
            Console.Read();
        }
    }
}
