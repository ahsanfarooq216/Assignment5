using System;
using System.Collections;

namespace Q3StackUsingQs
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.Push('a');
            s.Push('b');
            s.Push('c');
            Console.WriteLine(s.Size());
            Console.WriteLine(s.Pop());
            s.Push('d');
            Console.WriteLine(s.Pop());
        }

        public class Stack
        {
            public Queue q1 = new Queue();
            public Queue q2 = new Queue();
            public void Push(char e)
            {
                if (q1.Count == 0)
                {
                    q2.Enqueue(e);
                }
                else
                {
                    q1.Enqueue(e);
                }
            }

            public char Pop()
            {
                if(q1.Count == 0)
                {
                    if(q2.Count == 0)
                    {
                        Console.WriteLine("Stack Underflow!");
                        return '\0';
                    }
                    else
                    {
                        while(q2.Count > 1)
                        {
                            q1.Enqueue(q2.Dequeue());
                        }
                        return (char)q2.Dequeue();
                    }
                }
                else
                {
                    while(q1.Count > 1)
                    {
                        q2.Enqueue(q1.Dequeue());
                    }
                    return (char)q1.Dequeue();
                }
            }

            public int Size()
            {
                return q1.Count + q2.Count;
            }
        }

    }
}
