using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.EnterNumbers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            try
            {
                var input = new List<int>();

                for (int i = 0; i < 10; i++)
                {
                    int number = int.Parse(Console.ReadLine());
                    input.Add(number);
                }
                ReadNumber(input[0], 100);
            }
            catch (FormatException ae)
            {
                Console.WriteLine("Invalid Number!");
            }
        }

        static void ReadNumber(int start, int end)
        {
            int lastNumber = 0;
            for (int i = start; i < end; i++)
            {
                if (lastNumber < i)
                {

                }
                lastNumber = i;
            }
        }
    }
}
