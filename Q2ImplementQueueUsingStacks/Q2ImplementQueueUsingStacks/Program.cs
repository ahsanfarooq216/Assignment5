using System;
using System.Collections;

namespace Q2ImplementQueueUsingStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue();
            q.Enqueue('a');
            q.Enqueue('b');
            q.Enqueue('c');
            Console.WriteLine($"{q.Dequeue()} ");
            q.Enqueue('d');
            Console.WriteLine(q.Count());
            Console.WriteLine($"{q.Dequeue()} ");
            Console.WriteLine(q.Count());

            Console.Write($"{q.Dequeue()} ");
            Console.Write($"{q.Dequeue()} ");
            Console.Write($"{q.Dequeue()} ");
        }

        public class Queue
        {
            public Stack s1 = new Stack();
            public Stack s2 = new Stack();

            public void Enqueue(char e)
            {
                s1.Push(e);
            }

            public char Dequeue()
            {
                if (s2.Count == 0)
                {
                    while(s1.Count != 0)
                    {
                        s2.Push(s1.Pop());
                    }
                }
                return (s2.Count == 0) ? '\0' :(char)s2.Pop();
            }

            public int Count()
            {
                return s1.Count + s2.Count;
            }
        }
    }
}
