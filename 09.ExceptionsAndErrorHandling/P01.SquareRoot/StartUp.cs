using System;

namespace P01.SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                double squareRoot = Math.Sqrt(number);
                Console.WriteLine(squareRoot);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
