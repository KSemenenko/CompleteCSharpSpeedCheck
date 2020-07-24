using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text;
using BenchmarkDotNet.Attributes;
using Microsoft.VisualBasic;

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
            Random rnd = new Random(ItemsCount);
            _array = new int[ItemsCount];
            _dictionary = new Dictionary<int, int>();
            
            for (int i = 0; i < ItemsCount; i++)
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
        public void ListCountFor()
        {
            int match = 0;
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i] % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void ListCountForEach()
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
        public void ListCountLinq()
        {
            int match = _list.Count(c => (c % 10 == 0));
        }
        
        [Benchmark]
        public void ListSelectFor()
        {
            List<int> match = new List<int>();
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i] % 10 == 0)
                {
                    match.Add(_list[i]);
                }
            }
        }
        
        [Benchmark]
        public void ListSelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _list)
            {
                if (item % 10 == 0)
                {
                    match.Add(item);
                }
            }
        }
        
        [Benchmark]
        public void ListSelectLinq()
        {
            var match = _list.Where(c => (c % 10 == 0)).ToList();
        }
        
        
        //
        
        [Benchmark]
        public void ArrayCountFor()
        {
            int match = 0;
            for (var i = 0; i < _array.Length; i++)
            {
                if (_array[i] % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void ArrayCountForEach()
        {
            int match = 0;
            foreach (var item in _array)
            {
                if (item % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void ArrayCountLinq()
        {
            int match = _array.Count(c => (c % 10 == 0));
        }
        
        [Benchmark]
        public void ArraySelectFor()
        {
            List<int> match = new List<int>();
            for (var i = 0; i < _array.Length; i++)
            {
                if (_array[i] % 10 == 0)
                {
                    match.Add(_array[i]);
                }
            }
        }
        
        [Benchmark]
        public void ArraySelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _array)
            {
                if (item % 10 == 0)
                {
                    match.Add(item);
                }
            }
        }
        
        [Benchmark]
        public void ArraySelectLinq()
        {
            var match = _array.Where(c => (c % 10 == 0)).ToList();
        }
        
        //
        
        [Benchmark]
        public void DictionaryCountFor()
        {
            int match = 0;
            for (var i = 0; i < _dictionary.Count; i++)
            {
                if (_dictionary[i] % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void DictionaryCountForEach()
        {
            int match = 0;
            foreach (var item in _dictionary)
            {
                if (item.Value % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void DictionaryCountLinq()
        {
            int match = _dictionary.Count(c => (c.Value % 10 == 0));
        }
        
        [Benchmark]
        public void DictionarySelectFor()
        {
            List<int> match = new List<int>();
            for (var i = 0; i < _dictionary.Count; i++)
            {
                if (_dictionary[i] % 10 == 0)
                {
                    match.Add(_dictionary[i]);
                }
            }
        }
        
        [Benchmark]
        public void DictionarySelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _dictionary)
            {
                if (item.Value % 10 == 0)
                {
                    match.Add(item.Value);
                }
            }
        }
        
        [Benchmark]
        public void DictionarySelectLinq()
        {
            List<int> match = _dictionary.Where(c => (c.Value % 10 == 0)).Select(s=>s.Value).ToList();
        }
        
        //
        
        [Benchmark]
        public void QueueCountFor()
        {
            int match = 0;
            for (var i = 0; i < _queue.Count; i++)
            {
                var q = _queue.Dequeue();
                if (q % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void QueueCountForEach()
        {
            int match = 0;
            foreach (var item in _queue)
            {
                if (item % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void QueueCountLinq()
        {
            int match = _queue.Count(c => (c % 10 == 0));
        }
        
        [Benchmark]
        public void QueueSelectFor()
        {
            List<int> match = new List<int>();
            for (var i = 0; i < _queue.Count; i++)
            {
                var q = _queue.Dequeue();
                if (q % 10 == 0)
                {
                    match.Add(q);
                }
            }
        }
        
        [Benchmark]
        public void QueueSelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _queue)
            {
                if (item % 10 == 0)
                {
                    match.Add(item);
                }
            }
        }
        
        [Benchmark]
        public void QueueSelectLinq()
        {
            var match = _queue.Where(c => (c % 10 == 0)).ToList();
        }
        
        //
        
        [Benchmark]
        public void StackCountFor()
        {
            int match = 0;
            for (var i = 0; i < _stack.Count; i++)
            {
                if (_stack.Pop() % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void StackCountForEach()
        {
            int match = 0;
            foreach (var item in _stack)
            {
                if (item % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void StackCountLinq()
        {
            int match = _stack.Count(c => (c % 10 == 0));
        }
        
        [Benchmark]
        public void StackSelectFor()
        {
            List<int> match = new List<int>();
            for (var i = 0; i < _stack.Count; i++)
            {
                var item = _stack.Pop();
                if (item % 10 == 0)
                {
                    match.Add(item);
                }
            }
        }
        
        [Benchmark]
        public void StackSelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _stack)
            {
                if (item % 10 == 0)
                {
                    match.Add(item);
                }
            }
        }
        
        [Benchmark]
        public void StackSelectLinq()
        {
            var match = _stack.Where(c => (c % 10 == 0)).ToList();
        }
        
        //
        
        [Benchmark]
        public void HashSetCountForEach()
        {
            int match = 0;
            foreach (var item in _hashSet)
            {
                if (item % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void HashSetCountLinq()
        {
            int match = _hashSet.Count(c => (c % 10 == 0));
        }

        [Benchmark]
        public void HashSetSelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _hashSet)
            {
                if (item % 10 == 0)
                {
                    match.Add(item);
                }
            }
        }
        
        [Benchmark]
        public void HashSetSelectLinq()
        {
            var match = _hashSet.Where(c => (c % 10 == 0)).ToList();
        }
        
        //

        [Benchmark]
        public void LinkedListCountForEach()
        {
            int match = 0;
            foreach (var item in _linkedList)
            {
                if (item % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void LinkedListCountLinq()
        {
            int match = _linkedList.Count(c => (c % 10 == 0));
        }
        
        [Benchmark]
        public void LinkedListSelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _linkedList)
            {
                if (item % 10 == 0)
                {
                    match.Add(item);
                }
            }
        }
        
        [Benchmark]
        public void LinkedListSelectLinq()
        {
            var match = _linkedList.Where(c => (c % 10 == 0)).ToList();
        }
        
        //
        
        [Benchmark]
        public void ArrayListCountFor()
        {
            int match = 0;
            for (var i = 0; i < _arrayList.Count; i++)
            {
                if ((int)_arrayList[i] % 10 == 0)
                {
                    match++;
                }
            }
        }
        
        [Benchmark]
        public void ArrayListCountForEach()
        {
            int match = 0;
            foreach (int item in _arrayList)
            {
                if (item % 10 == 0)
                {
                    match++;
                }
            }
        }

        [Benchmark]
        public void ArrayListSelectFor()
        {
            List<int> match = new List<int>();
            for (int i = 0; i < _arrayList.Count; i++)
            {
                if ((int)_arrayList[i] % 10 == 0)
                {
                    match.Add((int)_arrayList[i]);
                }
            }
        }
        
        [Benchmark]
        public void ArrayListSelectForEach()
        {
            List<int> match = new List<int>();
            foreach (var item in _arrayList)
            {
                if ((int)item % 10 == 0)
                {
                    match.Add((int)item);
                }
            }
        }

    }
}