using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CompleteCSharpSpeedCheck.Collections
{
    [MemoryDiagnoser]
    public class CollectionAddItemsBenchmarks
    {
        private Random _rnd = new Random(100);
        
        [Params(1, 128, 1050, 2048)]
        public int ItemsCount;

        private int GetRandomInt()
        {
            return _rnd.Next(Int32.MinValue, Int32.MaxValue);
        }
        
        [GlobalSetup]
        public void Setup()
        {
        }
        
        [Benchmark]
        public void Array()
        {
            var collection = new int[ItemsCount];

            for (int i = 0; i < ItemsCount; i++)
            {
                collection[i] = GetRandomInt();
            }
        }

        [Benchmark]
        public void List()
        {
            var collection = new List<int>();
            for (var i = 0; i < ItemsCount; i++)
            {
                collection.Add(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void ListWithCapacity()
        {
            var collection = new List<int>(ItemsCount);
            for (var i = 0; i < ItemsCount; i++)
            {
                collection.Add(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void Queue()
        {
            var collection = new Queue<int>();
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Enqueue(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void QueueWithCapacity()
        {
            var collection = new Queue<int>(ItemsCount);
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Enqueue(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void Stack()
        {
            var collection = new Stack<int>();
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Push(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void StackWithCapacity()
        {
            var collection = new Stack<int>(ItemsCount);
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Push(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void Dictionary()
        {
            var collection = new Dictionary<int,int>();
            for (int i = 0; i < ItemsCount; i++)
            {
                collection[i] = GetRandomInt();
            }
        }
        
        [Benchmark]
        public void DictionaryWithCapacity()
        {
            var collection = new Dictionary<int,int>(ItemsCount);
            for (int i = 0; i < ItemsCount; i++)
            {
                collection[i] = GetRandomInt();
            }
        }
        
        
        [Benchmark]
        public void HashSet()
        {
            var collection = new HashSet<int>();
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Add(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void HashSetWithCapacity()
        {
            var collection = new HashSet<int>(ItemsCount);
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.Add(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void LinkedListAddFirst()
        {
            var collection = new LinkedList<int>();
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.AddFirst(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void LinkedListAddLast()
        {
            var collection = new LinkedList<int>();
            for (int i = 0; i < ItemsCount; i++)
            {
                collection.AddLast(GetRandomInt());
            }
        }
        
        [Benchmark]
        public void ArrayList()
        {
            var collection = new ArrayList();
            for (var i = 0; i < ItemsCount; i++)
            {
                collection.Add(GetRandomInt() as object);
            }
        }
        
        [Benchmark]
        public void ArrayListWithCapacity()
        {
            var collection = new ArrayList(ItemsCount);
            for (var i = 0; i < ItemsCount; i++)
            {
                collection.Add(GetRandomInt() as object);
            }
        }
        
    }
}