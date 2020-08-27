using System;
using System.Collections.Generic;
using System.Linq;

namespace Q1NextGreaterElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 5, 3, 2, 10, 6, 8, 1, 4, 12, 7, 4};
            NGE(arr1);
            int[] arr2 = { 4, 5, 2, 25 };
            NGE(arr2);
            int[] arr3 = { 13, 7, 6, 12 };
            NGE(arr3);
        }

        public static void NGE(int [] a)
        {
            var s = new Stack<int>();
            
            if (a.Length > 0)
            {
                s.Push(a[0]); //push the first element to stack
            }
            
            for (int i = 1; i < a.Length; i++)
            {
                if(s.Count() > 0) //if stack is not empty, then
                {
                    if(a[i] < s.Peek())
                    {
                        s.Push(a[i]);
                    }
                    while(a[i] > s.Peek())
                    {
                        Console.WriteLine($"{s.Peek()}\t--->\t{a[i]}");
                        s.Pop();
                        if(s.Count == 0)
                        {
                            break;
                        }
                        if (a[i] < s.Peek())
                        {
                            s.Push(a[i]);
                        }
                    }
                    if(s.Count == 0)
                    {
                        s.Push(a[i]);
                    }
                }
            }
            while(s.Count > 0)
            {
                Console.WriteLine($"{s.Peek()}\t--->\t-1");
                s.Pop();
            }
            Console.WriteLine("============================");
        }
    }
}
