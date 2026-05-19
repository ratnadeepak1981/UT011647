namespace Day2_Activity3_Console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Your Weight :");
            double Weight=Double.Parse(Console.ReadLine());

            Console.Write("Enter Your Height :");
            double Height = Double.Parse(Console.ReadLine());

            double BMI = Weight / (Height * Height);
            if (BMI < 18.5)
            {
                Console.WriteLine("Underweight");
            }
            else if(BMI >=18.5 && BMI <=24.9)
            {
                Console.WriteLine("Normalweight");
            }
            else if (BMI > 24.9 && BMI <= 29.9)
            {
                Console.WriteLine("Overweight");
            }
            else
            {
                Console.WriteLine("Obese");
            }
        }
    }
}
