using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmicExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(GetMiddle("test"));
            Console.WriteLine(GetMiddle("testing"));
            Console.WriteLine(GetMiddle("middle"));
            Console.WriteLine(GetMiddle("A"));

            Console.WriteLine(Encode("hello"));
            Console.WriteLine(Encode("aeiouy"));

            MoveZeroes(new int[] { 0, 1, 2, 14, 0, 4, 5 });
            MoveZeroes(new int[] { 0 });
            MoveZeroes(new int[] { 0, -1 });
            MoveZeroes(new int[] { 0, 0 });

            //MoveZeroesLinq(new int[] { 0, 1, 2, 14, 0, 4, 5 });
            //MoveZeroesLinq(new int[] { 0 });
            //MoveZeroesLinq(new int[] { 0, -1 });
            //MoveZeroesLinq(new int[] { 0, 0 });

            StringLetterCounting("");
            StringLetterCounting("cababccc");
            StringLetterCounting("caBabCcc");

            DirectionReduction(new List<String> { "NORTH", "WEST", "SOUTH", "EAST" });
            DirectionReduction(new List<String> { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" });
            DirectionReduction(new List<String> { "NORTH", "SOUTH", "EAST", "WEST" });
            DirectionReduction(new List<String> { "NORTH", "EAST", "WEST", "SOUTH", "WEST", "WEST" });
            DirectionReduction(new List<String>());

            Solution(10);
            Solution(20);
            

        }

        public static int Solution(int value)
        {
            // Magic Happens
            if (value <= 0)
            {
                return 0;
            }
            List<int> multipliers = new List<int>();
            int index = 3;
            while (index < value)
            {
                multipliers.Add(index);
                index += 3;
            }
            index = 5;
            while (index < value)
            {
                multipliers.Add(index);
                index += 5;
            }
            
            return multipliers.GroupBy(x => x).ToList().Sum(x => x.Key);
        }
        public static string GetMiddle(string s)
        {
            int len = s.Length;
            int k = len / 2;
            int modulo = len % 2;
            return s.Substring(k - 1 + modulo, 2 - modulo);
        }

        public static string Encode(string s)
        {
            string output = String.Empty;
            foreach (var ch in s)
            {
                output += EncodeChar(ch);
            }
            return output;
        }
        public static char EncodeChar(char input)
        {
            var encoding = new Dictionary<Char, Char>();
            encoding['a'] = '1';
            encoding['e'] = '2';
            encoding['i'] = '3';
            encoding['o'] = '4';
            encoding['u'] = '5';

            return encoding.ContainsKey(input) ? encoding[input] : input;
        }

        public static int[] MoveZeroes(int[] input)
        {
            int[] output = new int[input.Length];
            int outIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != 0)
                {
                    output[outIndex++] = input[i];
                }
            }
            return output;
        }

        //public static int[] MoveZeroesLinq(int[] arr)
        //{
        //    var min = arr.Min();
        //    return arr.Select(x=>x+)OrderByDescending(a => Math.Abs(a)).ToArray();
        //}

        public static string StringLetterCounting(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            string ordered = String.Concat(input.ToLower().OrderBy(a => a));
            string output = String.Empty;
            int index = 0;
            while (index < ordered.Length - 1)
            {
                int count = 1;
                while (index < ordered.Length - 1 && ordered[index] == ordered[index + 1])
                {
                    count++;
                    index++;
                }
                output += ordered[index] + count.ToString();
                index++;
            }
            return output;
        }

        public static List<String> DirectionReduction(List<String> input)
        {
            int nortSouth = 0;
            int westEast = 0;
            foreach (var item in input)
            {
                switch (item.ToLower())
                {
                    case "north":
                        nortSouth++;
                        break;
                    case "south":
                        nortSouth--;
                        break;
                    case "east":
                        westEast--;
                        break;
                    case "west":
                        westEast++;
                        break;
                }
            }
            List<String> output = new List<String>();
            for (int i = 0; i < Math.Abs(nortSouth); i++)
            {
                if (nortSouth > 0)
                {
                    output.Add("North");
                }
                else
                {
                    output.Add("South");
                }
            }
            for (int i = 0; i < Math.Abs(westEast); i++)
            {
                if (westEast > 0)
                {
                    output.Add("West");
                }
                else
                {
                    output.Add("East");
                }
            }
            return output;
        }

        public static List<String> DirectionReduction2(List<String> input)
        {
            List<String> output = new List<String>();

            if (input.Count() > 2)
            {
                ;
            }
            else
            {
                if (input[0] == input[1])
                {
                    //return input[0].ToString();
                }
            }
            return output;

        }
    }
}
      
