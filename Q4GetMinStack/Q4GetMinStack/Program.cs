using System;
using System.Collections;

namespace Q4GetMinStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack s = new MyStack();
            s.Push(5);
            s.Push(4);
            s.Push(3);
            s.Push(3);
            Console.WriteLine($"Minimum element: {s.GetMin()}"); //3
            s.Push(6);
            s.Push(6);
            Console.WriteLine($"Minimum element: {s.GetMin()}"); //3
            s.Push(4);
            Console.WriteLine($"Minimum element: {s.GetMin()}"); //3
            s.Push(2);
            s.Push(2);
            Console.WriteLine($"Minimum element: {s.GetMin()}"); //2
            s.Pop();
            Console.WriteLine($"Minimum element: {s.GetMin()}"); //2
            s.Pop();
            Console.WriteLine($"Minimum element: {s.GetMin()}"); //3
            s.Push(6);
            s.Pop();
            s.Push(1);
            Console.WriteLine($"Minimum element: {s.GetMin()}"); //1
        }

        public class MyStack
        {
            public Stack mainStack;
            public Stack sortedStack;

            public MyStack()
            {
                mainStack = new Stack();
                sortedStack = new Stack();
            }

            public void Push(int x)
            {
                mainStack.Push(x);
                if (sortedStack.Count == 0 || (int)mainStack.Peek() <= (int)sortedStack.Peek())
                {
                    sortedStack.Push(x);
                }
            }

            public int Pop()
            {
                if((int)mainStack.Peek() == (int)sortedStack.Peek())
                {
                    sortedStack.Pop();
                }
                return (int)mainStack.Pop();
            }
            
            public int GetMin()
            {
                return (int)sortedStack.Peek();
            }
        }
    }
}
