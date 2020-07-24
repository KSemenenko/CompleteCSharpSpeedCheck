using System;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CompleteCSharpSpeedCheck.Collections
{
    [MemoryDiagnoser]
    public class CollectionRemoveItemsBenchmarks
    {
        [Params(1, 128, 1050, 2048)]
        public int ItemsCount;

        private List<int> _list;
        private int[] _array;
        private Queue<int> _queue;
        private Stack<int> _stack;
        private Dictionary<int,int> _dictionary;
        private HashSet<int> _hashSet;
        private LinkedList<int> _linkedList;
        private ArrayList _arrayList;


        [IterationSetup]
        public void Setup()
        {
            int items = 2500;
            Random rnd = new Random(items);
            _array = new int[items];
            _dictionary = new Dictionary<int, int>();
            
            for (int i = 0; i < items; i++)
            {
                var randomInt = rnd.Next(Int32.MinValue, Int32.MaxValue);
                _array[i] = randomInt;
                _dictionary[i] = randomInt;
            }
            
            _list = new List<int>(_array);
            _queue = new Queue<int>(_array);
            _stack = new Stack<int>(_array);
            _hashSet = new HashSet<int>(_array);
            _linkedList = new LinkedList<int>(_array);
            _arrayList = new ArrayList(_array);
        }
        
        [Benchmark]
        public void List()
        {
            for (var i = 0; i < ItemsCount; i++)
            {
                _list.Remove(i);
            }
        }
        
        [Benchmark]
        public void Queue()
        {
            for (var i = 0; i < ItemsCount; i++)
            {
                _queue.Dequeue();
            }
        }
        
        [Benchmark]
        public void Stack()
        {
            for (var i = 0; i < ItemsCount; i++)
            {
                _stack.Pop();
            }
        }
        
        [Benchmark]
        public void HashSet()
        {
            for (var i = 0; i < ItemsCount; i++)
            {
                _hashSet.Remove(i);
            }
        }
        
        [Benchmark]
        public void Dictionary()
        {
            for (var i = 0; i < ItemsCount; i++)
            {
                _dictionary.Remove(i);
            }
        }
        
        [Benchmark]
        public void LinkedList()
        {
            for (var i = 0; i < ItemsCount; i++)
            {
                _linkedList.Remove(i);
            }
        }
        
        [Benchmark]
        public void ArrayList()
        {
            for (var i = 0; i < ItemsCount; i++)
            {
                _arrayList.Remove(i as object);
            }
        }
    }
}