namespace Day3_Activity3_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string SecretWord = "";
            do
            {
                Console.Write("Enter the secret word : ");
                SecretWord = Console.ReadLine();
            }
            while(SecretWord!="CSharp");

            Console.WriteLine("You found the Secret Message sucessfully");
        }
        
    }
}
