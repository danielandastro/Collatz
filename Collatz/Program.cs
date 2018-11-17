using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Collatz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Sequential (y/n)");
            if (Console.ReadLine().Equals("y"))
            {
                Sequential();
            }
            else Random(random);
        }

        private static void Random(Random random)
        {
            while (true)
            {
                int rand = random.Next();
                rand = Math.Abs(rand);
                Console.WriteLine(rand);
                CalcCollatzConjecture(rand);
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"numbers.txt"))
                {
                    file.WriteLine(rand + Environment.NewLine);
                }
            }
        }
        private static void Sequential()
        {
            var file = File.CreateText("numbers.txt");
            Console.WriteLine("Start at number: ");
            ulong num = ulong.Parse(Console.ReadLine());
            ulong last = 0;
            while (true)
            {

                num++;
                if (num<last) break;
                Console.WriteLine(num);
                CalcCollatzConjecture(num);
                {
                    file.WriteLineAsync(num.ToString());
                }

                last = num;
            }
        }

        private static void CalcCollatzConjecture(int number)
        {
            while (number != 1)
            {
                if (number % 2 == 0)
                {
                    number = number / 2;
                }
                else
                {
                    number = number * 3;
                    number++;
                }
                #if DEBUG 
                Console.WriteLine("            "+number);
                #endif
            }
        }
        private static void CalcCollatzConjecture(ulong number)
        {
            while (number != 1)
            {
                if (number % 2 == 0)
                {
                    number = number / 2;
                }
                else
                {
                    number = number * 3;
                    number++;
                }
                #if DEBUG 
                Console.WriteLine("            "+number);
                #endif
            }
        }

    }
}