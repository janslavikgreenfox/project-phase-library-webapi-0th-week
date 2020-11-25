using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncApp
{
    class Program
    {
        static void Main(string[] args)
        {
            static void PrintMenu()
            {
               Console.WriteLine("Hello there, try to ask for tasks and while you wait, ask for more." + Environment.NewLine +
              "Options you can pick from:\t" + "\n1. Create a terribly big List and print its count  " + "\n2. Calc fibonacci of nTh element\n"
                                 );
            };
            Task<int> task = null;
            while (true)
            {
                PrintMenu();
                bool isSuccess = Int32.TryParse(Console.ReadLine(), out int choice);
                if (isSuccess)
                {
                    switch (choice)
                    {
                        case 1:
                        default:
                            Task.Run(() => CreateListAndSum());
                            break;
                        case 2:
                            task = Task.Run(() => CalculateFib(40));
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, go again");
                }

                Console.WriteLine("\nNow the stuff is calculating, but you can go with another run and ask for input while calculating... Let´s start again");
                if (task is not null && task.IsCompleted)
                {
                    Console.WriteLine("\n" + task.Result);
                }
            }
        }

        private static int CalculateFib(int number)
        {
            if (number == 0 || number == 1)
                return number;

            return CalculateFib(number - 2) + CalculateFib(number - 1);
        }

        private static void CreateListAndSum()
        {
            Console.WriteLine("Starting list creation\n");
            var list = new List<long>();
            for (int i = 1; i < 99999999; i++)
            {
                list.Add(i * 50);
            }
            Console.WriteLine("\n\nList creation finished. The sum of the list is " + list.Sum() + "\n\n");
        }
    }
}
