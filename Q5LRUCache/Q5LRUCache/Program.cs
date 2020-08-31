using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Q5LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            var cash = new LRUCache(5);
            cash.Set(1, 11);
            cash.Set(2, 13);
            cash.Set(3, 14);
            cash.Set(4, 17);
            cash.Set(6, 20);
            Console.WriteLine(cash.Get(1));
            Console.WriteLine(cash.Get(3));
            cash.Set(1, 15);
            cash.Set(12, 17);
            cash.Set(5, 12);
            Console.WriteLine(cash.Get(4));
        }
    }
    public class LRUCache
    {
        private readonly int _capacity = 0;
        private readonly LinkedList<int[]> _recentlyUsedList = new LinkedList<int[]>();
        private readonly LinkedListNode<int[]> _dummyHead = new LinkedListNode<int[]>(new int[] { 0, 0 });
        private readonly Dictionary<int, LinkedListNode<int[]>> _cache = new Dictionary<int, LinkedListNode<int[]>>();

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _recentlyUsedList.AddFirst(_dummyHead);
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                return -1;
            }

            Reorder(_cache[key]);
            return _cache[key].Value[1];
        }

        public void Set(int key, int value)
        {
            if (_cache.ContainsKey(key))
            { 
                _cache[key].Value[1] = value;
            }
            else
            {
                if (_cache.Count == _capacity)
                {
                    _cache.Remove(_recentlyUsedList.Last.Value[0]);
                    _recentlyUsedList.RemoveLast();
                }
                _cache.Add(key, new LinkedListNode<int[]>(new int[] { key, value }));
            }
            Reorder(_cache[key]);
        }

        private void Reorder(LinkedListNode<int[]> node)
        {
            if (node.Previous != null)
            {
                _recentlyUsedList.Remove(node);
            }
            _recentlyUsedList.AddAfter(_dummyHead, node);
        }
    }
    //public class LRUCache
    //{
    //    public class Node
    //    {
    //        public int key;
    //        public int value;
    //        public Node pre;
    //        public Node next;
    //        public Node(int key, int value)
    //        {
    //            this.key = key;
    //            this.value = value;
    //        }
    //    }

    //    Dictionary<int, Node> map;
    //    int capicity, count;
    //    Node head, tail;

    //    public LRUCache(int capacity)
    //    {
    //        this.capicity = capacity;
    //        map = new Dictionary<int, Node>();
    //        head = new Node(0, 0);
    //        tail = new Node(0, 0);
    //        head.next = tail;
    //        tail.pre = head;
    //        head.pre = null;
    //        tail.next = null;
    //        count = 0;
    //    }

    //    public void DeleteNode(Node node)
    //    {
    //        node.pre.next = node.next;
    //        node.next.pre = node.pre;
    //        //tail.pre = node;
    //    }

    //    public int GetCount()
    //    {
    //        return count;
    //    }

    //    public void AddNode(Node node)
    //    {
    //        node.next = head.next;
    //        node.next.pre = node;
    //        node.pre = head;
    //        head.next = node;
    //    }

    //    public int Get(int key)
    //    {
    //        if (map.ContainsKey(key))
    //        {
    //            Node node = map[key];
    //            int result = node.value;
    //            DeleteNode(node);
    //            AddNode(node);
    //            return result;
    //        }
    //        return -1;
    //    }

    //    public void Set(int key, int value)
    //    {
    //        if (!map.ContainsKey(key))
    //        {
    //            Node node = new Node(key, value);
    //            map[key] = node;
    //            if (count < capicity)
    //            {
    //                count++;
    //                AddNode(node);
    //            }
    //            else
    //            {
    //                map.Remove(tail.pre.key);
    //                DeleteNode(tail.pre);
    //                AddNode(node);
    //            }
    //        }
    //        else
    //        {
    //            Node node = map[key];
    //            node.value = value;
    //            DeleteNode(node);
    //            AddNode(node);
    //        }
    //    }
    //}
}
