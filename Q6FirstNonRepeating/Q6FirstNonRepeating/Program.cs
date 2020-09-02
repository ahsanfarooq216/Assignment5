using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Q6FirstNonRepeating
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] stream1 = { 'a', 'a', 'b', 'c' };
            FirstNonRepeating(stream1);
            string stream2 = "ahsan";
            FirstNonRepeating(stream2.ToCharArray());
            string stream3 = "zzzxxyabc";
            FirstNonRepeating(stream3.ToCharArray());
            string stream4 = "abcabccbadabc";
            FirstNonRepeating(stream4.ToCharArray());

        }
        public static void FirstNonRepeating(char[] stream)
        {
            var frequency = new Dictionary<char, int>();
            var uniqueCharQ = new Queue<char>();

            for (int i = 0; i < stream.Length; i++)
            {
                if (!frequency.ContainsKey(stream[i]))
                {
                    frequency.Add(stream[i], 1);
                    uniqueCharQ.Enqueue(stream[i]);
                }
                else
                {
                    frequency[stream[i]]++;
                    if (uniqueCharQ.Count != 0 && uniqueCharQ.Peek() == stream[i])
                    {
                        uniqueCharQ.Dequeue();
                    }
                }
                Console.Write($"{stream[i]} goes to stream: ");
                if(uniqueCharQ.Count == 0)
                {
                    Console.WriteLine("no non repeating element - 1");
                }
                else
                {
                    Console.WriteLine($"1st non repeating element {uniqueCharQ.Peek()} ");
                }
            }
            Console.WriteLine($"==================");
        }
    }
}
