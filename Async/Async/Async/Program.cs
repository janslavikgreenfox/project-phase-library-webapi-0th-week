using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        public static async Task Main()
        {
            var watch = Stopwatch.StartNew();       

            Console.WriteLine(watch.ElapsedMilliseconds + " Hello from main ");
            var messageTask = CreateMessage();
            Task.Run(() => Calculate(watch));
            await CallMethod(watch);
           
            Console.WriteLine(watch.ElapsedMilliseconds + " Hello from main after Tasks");
            while (!messageTask.IsCompleted)
            {
                Console.WriteLine("Message Task is not completed just yet.. let´s give it a few moments");
                Thread.Sleep(3000);
            }

            Console.WriteLine(watch.ElapsedMilliseconds + " Message Task was completed");

            watch.Stop();
            Console.ReadLine();         
        }

        static async Task CallMethod(Stopwatch watch)
        {
            string filePath = "lol.txt";

            Task<int> task = ReadFile(filePath, watch);

            Console.WriteLine(watch.ElapsedMilliseconds + "  Callmethod after task");
            Console.WriteLine(" Other Work 1");
            Console.WriteLine(" Other Work 2");
            Console.WriteLine(" Other Work 3");
            
            int length = await task;
            Console.WriteLine(watch.ElapsedMilliseconds + " Total length of file: " + length);
            Console.WriteLine(" After work 1");
            Console.WriteLine(" After work 2");
        }

        static async Task<int> ReadFile(string file, Stopwatch watch)
        {
            Console.WriteLine(watch.ElapsedMilliseconds + " File reading is starting");

            using StreamReader reader = new StreamReader(file);
            string s = await reader.ReadToEndAsync();

            Console.WriteLine(watch.ElapsedMilliseconds + " File reading is completed");

            int length = s.Length;
            return length;
        }

        static void Calculate(Stopwatch watch)
        {
            var list = new List<long>();
            for (long i = 0; i < 999999999; i++)
            {
                list.Add(i * 50 - 347 * 3);
            }

            Console.WriteLine(watch.ElapsedMilliseconds + " FINISHED CALCULATING");
        }

        static async Task<string[]> CreateMessage()
        {
            var list = new List<Task<string>>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(Task.Run(() => CreateString()));
            }
                var results = await Task.WhenAll(list);
                return results;
        }

        static string CreateString() 
        {
            var result = String.Empty;
            for (int i = 0; i < 99999; i++)
            {
                result += "Hi";
            }
            return result;
        }
    }
}
