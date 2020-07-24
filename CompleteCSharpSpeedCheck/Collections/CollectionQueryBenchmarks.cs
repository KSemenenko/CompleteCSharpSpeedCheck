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

/*

|                  Method | ItemsCount |        Mean |        Error |       StdDev |      Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |----------- |------------:|-------------:|-------------:|------------:|------:|------:|------:|----------:|
|            ListCountFor |          1 |  1,286.9 ns |  2,147.48 ns |  1,277.93 ns |    583.5 ns |     - |     - |     - |      48 B |
|        ListCountForEach |          1 |    337.3 ns |    566.52 ns |    337.13 ns |    218.0 ns |     - |     - |     - |      48 B |
|           ListCountLinq |          1 |  3,612.1 ns |  6,554.15 ns |  3,900.27 ns |  1,745.5 ns |     - |     - |     - |      88 B |
|           ListSelectFor |          1 |  5,938.5 ns | 11,440.73 ns |  6,808.20 ns |  3,016.0 ns |     - |     - |     - |     120 B |
|       ListSelectForEach |          1 |  2,186.9 ns |  1,142.93 ns |    680.14 ns |  1,985.5 ns |     - |     - |     - |     120 B |
|          ListSelectLinq |          1 |  2,805.5 ns |  1,355.04 ns |    806.36 ns |  2,581.5 ns |     - |     - |     - |     192 B |
|           ArrayCountFor |          1 |    686.7 ns |  1,742.24 ns |  1,036.78 ns |    273.0 ns |     - |     - |     - |      48 B |
|       ArrayCountForEach |          1 |    667.1 ns |  1,971.03 ns |  1,172.93 ns |    247.5 ns |     - |     - |     - |      48 B |
|          ArrayCountLinq |          1 |  2,010.5 ns |  1,150.44 ns |    684.61 ns |  1,693.0 ns |     - |     - |     - |      80 B |
|          ArraySelectFor |          1 |  3,368.1 ns |  5,757.19 ns |  3,426.01 ns |  2,053.5 ns |     - |     - |     - |     120 B |
|      ArraySelectForEach |          1 |  1,793.6 ns |  1,021.73 ns |    608.01 ns |  1,569.0 ns |     - |     - |     - |     120 B |
|         ArraySelectLinq |          1 |  2,897.1 ns |  1,257.56 ns |    748.35 ns |  2,524.5 ns |     - |     - |     - |     168 B |
|      DictionaryCountFor |          1 |  1,236.3 ns |  3,693.53 ns |  2,197.96 ns |    358.0 ns |     - |     - |     - |      48 B |
|  DictionaryCountForEach |          1 |    414.9 ns |  1,199.95 ns |    714.07 ns |    167.0 ns |     - |     - |     - |      48 B |
|     DictionaryCountLinq |          1 |  1,890.9 ns |    658.62 ns |    391.93 ns |  1,843.0 ns |     - |     - |     - |      96 B |
|     DictionarySelectFor |          1 |  2,069.6 ns |  1,131.36 ns |    673.25 ns |  1,883.0 ns |     - |     - |     - |     120 B |
| DictionarySelectForEach |          1 |  7,686.9 ns | 18,908.84 ns | 11,252.35 ns |  2,079.5 ns |     - |     - |     - |     120 B |
|    DictionarySelectLinq |          1 | 10,123.0 ns | 22,404.46 ns | 13,332.54 ns |  6,121.0 ns |     - |     - |     - |     288 B |
|           QueueCountFor |          1 |  1,692.2 ns |  3,545.62 ns |  2,109.94 ns |    426.5 ns |     - |     - |     - |      96 B |
|       QueueCountForEach |          1 |    221.2 ns |    377.55 ns |    224.68 ns |    141.0 ns |     - |     - |     - |      48 B |
|          QueueCountLinq |          1 |  1,849.1 ns |    280.98 ns |    167.21 ns |  1,850.0 ns |     - |     - |     - |      88 B |
|          QueueSelectFor |          1 |  1,443.8 ns |    344.38 ns |    204.94 ns |  1,406.0 ns |     - |     - |     - |     120 B |
|      QueueSelectForEach |          1 |  2,045.0 ns |  1,885.29 ns |  1,121.90 ns |  1,567.5 ns |     - |     - |     - |     120 B |
|         QueueSelectLinq |          1 |  3,481.6 ns |    604.62 ns |    359.80 ns |  3,395.0 ns |     - |     - |     - |     216 B |
|           StackCountFor |          1 |    183.1 ns |     86.05 ns |     51.21 ns |    199.5 ns |     - |     - |     - |      48 B |
|       StackCountForEach |          1 |    340.6 ns |    587.22 ns |    349.45 ns |    178.5 ns |     - |     - |     - |      48 B |
|          StackCountLinq |          1 |  2,291.9 ns |  1,716.23 ns |  1,021.30 ns |  1,975.0 ns |     - |     - |     - |      88 B |
|          StackSelectFor |          1 |  1,535.8 ns |    530.16 ns |    315.49 ns |  1,460.5 ns |     - |     - |     - |     120 B |
|      StackSelectForEach |          1 |  1,403.6 ns |    225.77 ns |    134.35 ns |  1,352.0 ns |     - |     - |     - |     168 B |
|         StackSelectLinq |          1 |  6,217.2 ns |  6,743.93 ns |  4,013.20 ns |  4,029.5 ns |     - |     - |     - |     216 B |
|     HashSetCountForEach |          1 |    147.1 ns |     83.64 ns |     49.78 ns |    132.0 ns |     - |     - |     - |      48 B |
|        HashSetCountLinq |          1 |  2,363.5 ns |  1,217.36 ns |    724.43 ns |  2,198.5 ns |     - |     - |     - |      88 B |
|    HashSetSelectForEach |          1 |  1,839.4 ns |  1,117.37 ns |    664.93 ns |  1,665.5 ns |     - |     - |     - |     120 B |
|       HashSetSelectLinq |          1 |  3,585.2 ns |  1,144.87 ns |    681.29 ns |  3,563.5 ns |     - |     - |     - |     216 B |
|  LinkedListCountForEach |          1 |    168.3 ns |     77.03 ns |     45.84 ns |    157.0 ns |     - |     - |     - |      48 B |
|     LinkedListCountLinq |          1 |  1,607.2 ns |    853.82 ns |    508.10 ns |  1,438.5 ns |     - |     - |     - |      96 B |
| LinkedListSelectForEach |          1 |  2,097.4 ns |  2,483.02 ns |  1,477.60 ns |  1,619.5 ns |     - |     - |     - |     120 B |
|    LinkedListSelectLinq |          1 |  3,588.4 ns |  2,408.10 ns |  1,433.02 ns |  3,112.5 ns |     - |     - |     - |     224 B |
|       ArrayListCountFor |          1 |    201.8 ns |    273.63 ns |    162.83 ns |    147.5 ns |     - |     - |     - |      48 B |
|   ArrayListCountForEach |          1 |  1,611.0 ns |    232.24 ns |    138.20 ns |  1,616.0 ns |     - |     - |     - |      96 B |
|      ArrayListSelectFor |          1 |  1,375.9 ns |    262.55 ns |    156.24 ns |  1,379.5 ns |     - |     - |     - |     120 B |
|  ArrayListSelectForEach |          1 |  2,227.1 ns |  1,124.75 ns |    669.32 ns |  2,098.5 ns |     - |     - |     - |     168 B |
|            ListCountFor |        128 |    563.4 ns |    175.88 ns |    104.66 ns |    554.0 ns |     - |     - |     - |      48 B |
|        ListCountForEach |        128 |    949.3 ns |     59.61 ns |     35.47 ns |    942.5 ns |     - |     - |     - |      48 B |
|           ListCountLinq |        128 |  3,371.0 ns |    203.65 ns |    121.19 ns |  3,368.0 ns |     - |     - |     - |      88 B |
|           ListSelectFor |        128 |  2,579.6 ns |  2,252.52 ns |  1,340.44 ns |  1,939.0 ns |     - |     - |     - |     264 B |
|       ListSelectForEach |        128 |  2,547.9 ns |    712.80 ns |    424.18 ns |  2,371.0 ns |     - |     - |     - |     264 B |
|          ListSelectLinq |        128 |  3,644.2 ns |    656.21 ns |    390.50 ns |  3,576.0 ns |     - |     - |     - |     336 B |
|           ArrayCountFor |        128 |    517.4 ns |    104.40 ns |     62.12 ns |    490.5 ns |     - |     - |     - |      48 B |
|       ArrayCountForEach |        128 |    464.4 ns |     92.72 ns |     55.18 ns |    451.0 ns |     - |     - |     - |      48 B |
|          ArrayCountLinq |        128 |  2,929.4 ns |    380.24 ns |    226.28 ns |  2,954.0 ns |     - |     - |     - |      80 B |
|          ArraySelectFor |        128 |  3,489.9 ns |  3,375.26 ns |  2,008.56 ns |  2,656.5 ns |     - |     - |     - |     264 B |
|      ArraySelectForEach |        128 |  2,066.3 ns |    378.13 ns |    225.02 ns |  2,144.5 ns |     - |     - |     - |     264 B |
|         ArraySelectLinq |        128 |  3,461.6 ns |  1,374.84 ns |    818.15 ns |  3,275.5 ns |     - |     - |     - |     312 B |
|      DictionaryCountFor |        128 |  1,841.5 ns |    269.44 ns |    160.34 ns |  1,794.5 ns |     - |     - |     - |      48 B |
|  DictionaryCountForEach |        128 |  1,809.1 ns |    500.71 ns |    297.96 ns |  1,677.0 ns |     - |     - |     - |      48 B |
|     DictionaryCountLinq |        128 |  5,598.3 ns |  7,951.87 ns |  4,732.03 ns |  4,048.5 ns |     - |     - |     - |      96 B |
|     DictionarySelectFor |        128 |  6,410.4 ns | 13,489.23 ns |  8,027.22 ns |  3,551.0 ns |     - |     - |     - |     264 B |
| DictionarySelectForEach |        128 |  3,448.7 ns |    855.12 ns |    508.87 ns |  3,234.0 ns |     - |     - |     - |     264 B |
|    DictionarySelectLinq |        128 |  7,192.1 ns |  5,814.91 ns |  3,460.36 ns |  6,071.5 ns |     - |     - |     - |     432 B |
|           QueueCountFor |        128 |  1,215.9 ns |    858.96 ns |    511.15 ns |    943.0 ns |     - |     - |     - |      48 B |
|       QueueCountForEach |        128 |  2,198.4 ns |    178.31 ns |    106.11 ns |  2,218.5 ns |     - |     - |     - |      48 B |
|          QueueCountLinq |        128 |  5,328.3 ns |    801.67 ns |    477.06 ns |  5,159.5 ns |     - |     - |     - |      88 B |
|          QueueSelectFor |        128 |  2,413.8 ns |    259.49 ns |    154.42 ns |  2,349.0 ns |     - |     - |     - |     176 B |
|      QueueSelectForEach |        128 |  5,500.5 ns |  3,941.08 ns |  2,345.27 ns |  4,177.0 ns |     - |     - |     - |     264 B |
|         QueueSelectLinq |        128 |  8,166.6 ns |  4,215.51 ns |  2,508.58 ns |  7,677.0 ns |     - |     - |     - |     360 B |
|           StackCountFor |        128 |    831.4 ns |     62.47 ns |     37.18 ns |    844.0 ns |     - |     - |     - |      48 B |
|       StackCountForEach |        128 |  1,486.2 ns |    293.18 ns |    174.46 ns |  1,471.0 ns |     - |     - |     - |      48 B |
|          StackCountLinq |        128 |  4,034.9 ns |    410.10 ns |    244.05 ns |  4,054.5 ns |     - |     - |     - |      88 B |
|          StackSelectFor |        128 |  2,859.4 ns |    816.80 ns |    486.07 ns |  2,999.0 ns |     - |     - |     - |     176 B |
|      StackSelectForEach |        128 |  3,030.9 ns |    323.06 ns |    192.25 ns |  2,978.0 ns |     - |     - |     - |     264 B |
|         StackSelectLinq |        128 |  6,371.6 ns |  1,989.93 ns |  1,184.18 ns |  5,940.5 ns |     - |     - |     - |     360 B |
|     HashSetCountForEach |        128 |    981.6 ns |    257.09 ns |    152.99 ns |    947.5 ns |     - |     - |     - |      48 B |
|        HashSetCountLinq |        128 |  3,505.8 ns |    575.74 ns |    342.61 ns |  3,409.0 ns |     - |     - |     - |      88 B |
|    HashSetSelectForEach |        128 |  2,110.8 ns |    322.58 ns |    191.96 ns |  2,092.5 ns |     - |     - |     - |     264 B |
|       HashSetSelectLinq |        128 |  6,071.9 ns |  3,021.02 ns |  1,797.76 ns |  5,610.5 ns |     - |     - |     - |     360 B |
|  LinkedListCountForEach |        128 |  1,889.9 ns |  1,584.41 ns |    942.86 ns |  1,408.0 ns |     - |     - |     - |      48 B |
|     LinkedListCountLinq |        128 |  6,350.8 ns |  2,374.93 ns |  1,413.29 ns |  5,813.0 ns |     - |     - |     - |      96 B |
| LinkedListSelectForEach |        128 |  3,399.3 ns |    826.12 ns |    491.61 ns |  3,430.5 ns |     - |     - |     - |     264 B |
|    LinkedListSelectLinq |        128 |  5,705.4 ns |  1,380.02 ns |    821.23 ns |  5,545.5 ns |     - |     - |     - |     368 B |
|       ArrayListCountFor |        128 |  1,028.4 ns |    185.33 ns |    110.29 ns |    988.5 ns |     - |     - |     - |      48 B |
|   ArrayListCountForEach |        128 |  7,326.7 ns | 11,289.46 ns |  6,718.18 ns |  4,037.5 ns |     - |     - |     - |      96 B |
|      ArrayListSelectFor |        128 |  5,245.6 ns |  6,964.61 ns |  4,144.53 ns |  2,919.5 ns |     - |     - |     - |     264 B |
|  ArrayListSelectForEach |        128 |  3,983.6 ns |  1,039.06 ns |    618.33 ns |  3,892.5 ns |     - |     - |     - |     312 B |
|            ListCountFor |       1050 |  3,905.5 ns |    765.05 ns |    455.27 ns |  3,800.5 ns |     - |     - |     - |      48 B |
|        ListCountForEach |       1050 |  7,060.4 ns |  1,873.74 ns |  1,115.03 ns |  6,527.5 ns |     - |     - |     - |      48 B |
|           ListCountLinq |       1050 | 24,997.2 ns |  2,170.60 ns |  1,291.69 ns | 25,076.0 ns |     - |     - |     - |      88 B |
|           ListSelectFor |       1050 |  7,989.6 ns |  4,276.97 ns |  2,545.15 ns |  7,085.5 ns |     - |     - |     - |    1232 B |
|       ListSelectForEach |       1050 | 11,978.3 ns | 14,387.13 ns |  8,561.55 ns |  9,011.5 ns |     - |     - |     - |    1232 B |
|          ListSelectLinq |       1050 | 13,209.1 ns |  5,208.41 ns |  3,099.44 ns | 12,684.5 ns |     - |     - |     - |    1304 B |
|           ArrayCountFor |       1050 |  4,132.1 ns |  2,954.88 ns |  1,758.40 ns |  3,728.0 ns |     - |     - |     - |      48 B |
|       ArrayCountForEach |       1050 |  3,147.6 ns |  1,863.95 ns |  1,109.21 ns |  2,883.5 ns |     - |     - |     - |      48 B |
|          ArrayCountLinq |       1050 | 15,244.1 ns |  6,017.00 ns |  3,580.62 ns | 13,255.0 ns |     - |     - |     - |      80 B |
|          ArraySelectFor |       1050 |  9,840.0 ns | 12,599.99 ns |  7,498.05 ns |  6,877.0 ns |     - |     - |     - |    1232 B |
|      ArraySelectForEach |       1050 |  8,329.3 ns | 13,730.66 ns |  8,170.90 ns |  5,008.0 ns |     - |     - |     - |    1232 B |
|         ArraySelectLinq |       1050 | 17,795.2 ns | 19,025.86 ns | 11,321.98 ns | 12,536.0 ns |     - |     - |     - |    1280 B |
|      DictionaryCountFor |       1050 | 14,561.4 ns |  1,974.85 ns |  1,175.20 ns | 14,965.0 ns |     - |     - |     - |      48 B |
|  DictionaryCountForEach |       1050 | 19,340.6 ns | 34,746.59 ns | 20,677.14 ns | 12,152.5 ns |     - |     - |     - |      48 B |
|     DictionaryCountLinq |       1050 | 24,102.4 ns |  2,792.05 ns |  1,661.50 ns | 23,907.5 ns |     - |     - |     - |      96 B |
|     DictionarySelectFor |       1050 | 30,485.8 ns | 48,773.49 ns | 29,024.32 ns | 17,707.5 ns |     - |     - |     - |    1232 B |
| DictionarySelectForEach |       1050 | 23,948.3 ns | 32,703.96 ns | 19,461.60 ns | 14,674.0 ns |     - |     - |     - |    1232 B |
|    DictionarySelectLinq |       1050 | 42,549.4 ns | 37,278.31 ns | 22,183.72 ns | 39,938.5 ns |     - |     - |     - |    1400 B |
|           QueueCountFor |       1050 |  5,818.7 ns |  1,416.61 ns |    843.00 ns |  5,587.0 ns |     - |     - |     - |      48 B |
|       QueueCountForEach |       1050 | 18,190.8 ns |  2,368.52 ns |  1,409.47 ns | 18,522.5 ns |     - |     - |     - |      48 B |
|          QueueCountLinq |       1050 | 29,145.1 ns |  2,294.05 ns |  1,365.15 ns | 29,054.0 ns |     - |     - |     - |      88 B |
|          QueueSelectFor |       1050 |  8,366.0 ns |  4,234.27 ns |  2,519.74 ns |  7,455.5 ns |     - |     - |     - |     696 B |
|      QueueSelectForEach |       1050 | 19,322.2 ns |  2,353.95 ns |  1,400.80 ns | 19,139.0 ns |     - |     - |     - |    1232 B |
|         QueueSelectLinq |       1050 | 49,428.9 ns | 44,504.99 ns | 26,484.21 ns | 35,770.5 ns |     - |     - |     - |    1328 B |
|           StackCountFor |       1050 |  4,545.4 ns |    603.71 ns |    359.26 ns |  4,286.0 ns |     - |     - |     - |      48 B |
|       StackCountForEach |       1050 |  9,710.4 ns |  1,183.73 ns |    704.42 ns |  9,330.0 ns |     - |     - |     - |      48 B |
|          StackCountLinq |       1050 | 24,425.1 ns | 16,037.38 ns |  9,543.59 ns | 22,244.5 ns |     - |     - |     - |      88 B |
|          StackSelectFor |       1050 |  6,880.2 ns |  4,967.88 ns |  2,956.30 ns |  5,883.0 ns |     - |     - |     - |     696 B |
|      StackSelectForEach |       1050 | 11,196.3 ns |    921.94 ns |    548.63 ns | 11,096.5 ns |     - |     - |     - |    1232 B |
|         StackSelectLinq |       1050 | 32,393.8 ns | 41,849.15 ns | 24,903.76 ns | 23,912.5 ns |     - |     - |     - |    1328 B |
|     HashSetCountForEach |       1050 | 12,378.8 ns | 21,784.94 ns | 12,963.87 ns |  7,553.5 ns |     - |     - |     - |      48 B |
|        HashSetCountLinq |       1050 | 22,406.8 ns | 17,596.06 ns | 10,471.13 ns | 20,025.5 ns |     - |     - |     - |      88 B |
|    HashSetSelectForEach |       1050 | 13,115.5 ns | 17,248.31 ns | 10,264.19 ns |  8,757.5 ns |     - |     - |     - |    1232 B |
|       HashSetSelectLinq |       1050 | 28,140.4 ns | 40,068.73 ns | 23,844.26 ns | 20,259.0 ns |     - |     - |     - |    1328 B |
|  LinkedListCountForEach |       1050 |  9,375.4 ns |  2,599.74 ns |  1,547.06 ns |  8,590.0 ns |     - |     - |     - |      48 B |
|     LinkedListCountLinq |       1050 | 20,082.6 ns |  2,141.68 ns |  1,274.48 ns | 19,350.0 ns |     - |     - |     - |      96 B |
| LinkedListSelectForEach |       1050 | 10,854.1 ns |  1,817.79 ns |  1,081.74 ns | 10,707.0 ns |     - |     - |     - |    1232 B |
|    LinkedListSelectLinq |       1050 | 36,679.3 ns | 56,016.02 ns | 33,334.24 ns | 24,999.5 ns |     - |     - |     - |    1336 B |
|       ArrayListCountFor |       1050 |  6,779.6 ns |  1,415.45 ns |    842.31 ns |  6,469.0 ns |     - |     - |     - |      48 B |
|   ArrayListCountForEach |       1050 | 13,492.7 ns |  1,286.63 ns |    765.65 ns | 13,361.5 ns |     - |     - |     - |      96 B |
|      ArrayListSelectFor |       1050 |  8,619.0 ns |  1,202.06 ns |    715.33 ns |  8,334.0 ns |     - |     - |     - |    1232 B |
|  ArrayListSelectForEach |       1050 | 18,081.7 ns | 19,942.21 ns | 11,867.29 ns | 14,456.0 ns |     - |     - |     - |    1280 B |
|            ListCountFor |       2048 | 10,846.1 ns |  9,839.12 ns |  5,855.10 ns |  7,839.0 ns |     - |     - |     - |      48 B |
|        ListCountForEach |       2048 | 14,941.1 ns |  7,808.59 ns |  4,646.77 ns | 13,859.5 ns |     - |     - |     - |      48 B |
|           ListCountLinq |       2048 | 37,562.6 ns |  4,954.72 ns |  2,948.47 ns | 36,803.0 ns |     - |     - |     - |      88 B |
|           ListSelectFor |       2048 | 16,915.8 ns | 16,032.52 ns |  9,540.69 ns | 11,568.0 ns |     - |     - |     - |    2280 B |
|       ListSelectForEach |       2048 | 16,110.4 ns |  7,757.21 ns |  4,616.19 ns | 14,101.5 ns |     - |     - |     - |    2280 B |
|          ListSelectLinq |       2048 | 26,952.1 ns | 16,062.15 ns |  9,558.33 ns | 22,704.5 ns |     - |     - |     - |    2352 B |
|           ArrayCountFor |       2048 |  5,978.1 ns |  2,986.84 ns |  1,777.42 ns |  4,891.5 ns |     - |     - |     - |      48 B |
|       ArrayCountForEach |       2048 |  7,276.6 ns |  9,853.88 ns |  5,863.89 ns |  5,618.5 ns |     - |     - |     - |      48 B |
|          ArrayCountLinq |       2048 | 27,982.3 ns | 11,654.88 ns |  6,935.63 ns | 24,873.0 ns |     - |     - |     - |      80 B |
|          ArraySelectFor |       2048 |  8,488.6 ns |  3,222.85 ns |  1,917.87 ns |  7,928.0 ns |     - |     - |     - |    2280 B |
|      ArraySelectForEach |       2048 | 14,016.6 ns | 12,847.05 ns |  7,645.07 ns | 12,041.5 ns |     - |     - |     - |    2280 B |
|         ArraySelectLinq |       2048 | 26,262.8 ns | 24,419.56 ns | 14,531.69 ns | 20,105.0 ns |     - |     - |     - |    2328 B |
|      DictionaryCountFor |       2048 | 34,929.0 ns | 21,805.31 ns | 12,975.99 ns | 30,855.5 ns |     - |     - |     - |      48 B |
|  DictionaryCountForEach |       2048 | 32,739.5 ns | 11,953.71 ns |  7,113.46 ns | 30,137.5 ns |     - |     - |     - |      48 B |
|     DictionaryCountLinq |       2048 | 46,935.3 ns |  7,534.46 ns |  4,483.64 ns | 44,089.5 ns |     - |     - |     - |      96 B |
|     DictionarySelectFor |       2048 | 36,545.1 ns | 16,602.69 ns |  9,879.99 ns | 33,078.5 ns |     - |     - |     - |    2280 B |
| DictionarySelectForEach |       2048 | 35,494.6 ns | 30,950.57 ns | 18,418.19 ns | 30,545.5 ns |     - |     - |     - |    2280 B |
|    DictionarySelectLinq |       2048 | 56,457.3 ns |  4,093.08 ns |  2,435.72 ns | 56,252.0 ns |     - |     - |     - |    2448 B |
|           QueueCountFor |       2048 | 13,078.2 ns |  3,265.72 ns |  1,943.38 ns | 12,465.0 ns |     - |     - |     - |      48 B |
|       QueueCountForEach |       2048 | 34,785.4 ns | 10,155.70 ns |  6,043.49 ns | 31,566.5 ns |     - |     - |     - |      48 B |
|          QueueCountLinq |       2048 | 62,052.1 ns | 29,163.82 ns | 17,354.92 ns | 54,068.0 ns |     - |     - |     - |      88 B |
|          QueueSelectFor |       2048 | 11,913.2 ns |    478.36 ns |    284.66 ns | 11,945.0 ns |     - |     - |     - |    1232 B |
|      QueueSelectForEach |       2048 | 41,376.5 ns | 23,519.14 ns | 13,995.86 ns | 35,353.0 ns |     - |     - |     - |    2280 B |
|         QueueSelectLinq |       2048 | 65,211.3 ns |  8,956.06 ns |  5,329.60 ns | 64,607.0 ns |     - |     - |     - |    2376 B |
|           StackCountFor |       2048 | 10,269.7 ns |  2,679.76 ns |  1,594.68 ns | 10,100.0 ns |     - |     - |     - |      48 B |
|       StackCountForEach |       2048 | 19,536.9 ns |  1,205.01 ns |    717.08 ns | 19,695.5 ns |     - |     - |     - |      48 B |
|          StackCountLinq |       2048 | 43,080.9 ns | 16,174.40 ns |  9,625.13 ns | 41,772.0 ns |     - |     - |     - |      88 B |
|          StackSelectFor |       2048 | 11,531.9 ns |  4,873.92 ns |  2,900.39 ns | 10,062.5 ns |     - |     - |     - |    1232 B |
|      StackSelectForEach |       2048 | 25,328.7 ns | 11,538.01 ns |  6,866.09 ns | 21,079.5 ns |     - |     - |     - |    2280 B |
|         StackSelectLinq |       2048 | 47,711.4 ns | 21,137.06 ns | 12,578.32 ns | 42,924.5 ns |     - |     - |     - |    2376 B |
|     HashSetCountForEach |       2048 | 24,371.1 ns | 31,563.16 ns | 18,782.73 ns | 15,842.0 ns |     - |     - |     - |      48 B |
|        HashSetCountLinq |       2048 | 36,461.6 ns |  5,148.64 ns |  3,063.87 ns | 37,688.0 ns |     - |     - |     - |      88 B |
|    HashSetSelectForEach |       2048 | 23,990.6 ns | 33,623.16 ns | 20,008.60 ns | 15,874.5 ns |     - |     - |     - |    2280 B |
|       HashSetSelectLinq |       2048 | 58,204.3 ns | 78,868.52 ns | 46,933.39 ns | 40,991.5 ns |     - |     - |     - |    2376 B |
|  LinkedListCountForEach |       2048 | 16,913.3 ns |  2,320.73 ns |  1,381.03 ns | 16,314.5 ns |     - |     - |     - |      48 B |
|     LinkedListCountLinq |       2048 | 50,747.7 ns | 43,148.16 ns | 25,676.78 ns | 45,070.5 ns |     - |     - |     - |      96 B |
| LinkedListSelectForEach |       2048 | 37,349.3 ns | 68,318.53 ns | 40,655.26 ns | 21,601.5 ns |     - |     - |     - |    2280 B |
|    LinkedListSelectLinq |       2048 | 53,622.4 ns | 47,636.98 ns | 28,348.00 ns | 44,033.0 ns |     - |     - |     - |    2384 B |
|       ArrayListCountFor |       2048 | 13,858.3 ns |  4,472.53 ns |  2,661.53 ns | 13,132.0 ns |     - |     - |     - |      48 B |
|   ArrayListCountForEach |       2048 | 39,165.1 ns | 33,724.21 ns | 20,068.74 ns | 28,510.5 ns |     - |     - |     - |      96 B |
|      ArrayListSelectFor |       2048 | 16,722.3 ns |  4,257.80 ns |  2,533.75 ns | 17,255.5 ns |     - |     - |     - |    2280 B |
|  ArrayListSelectForEach |       2048 | 32,218.2 ns |  6,793.82 ns |  4,042.89 ns | 32,563.0 ns |     - |     - |     - |    2328 B |
