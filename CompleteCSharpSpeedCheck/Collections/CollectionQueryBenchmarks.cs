using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CompleteCSharpSpeedCheck.Collections
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 3, warmupCount: 3, targetCount: 3)]
    public class CollectionStatementsBenchmarks
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
        public void ListFor()
        {
            int match = 0;
            for (var i = 0; i < ItemsCount; i++)
            {
                if (_list[i] % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void ListForEach()
        {
            int match = 0;
            foreach (var item in _list)
            {
                if (item % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void ListLinq()
        {
            int match = _list.Count(c => (c % 10 == 0));
        }
        
        
    }
}