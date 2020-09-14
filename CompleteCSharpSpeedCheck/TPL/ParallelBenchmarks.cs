using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace CompleteCSharpSpeedCheck.TPL
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 3, warmupCount: 3, targetCount: 3)]
    public class ParallelBenchmarks
    {

        class Payload
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }

        [Params(1, 100, 150, 200, 250, 500, 1000)]
        public int ItemsCount;

        private List<Payload> _list;
        private bool _flag;

        private string GenerateString(int i)
        {
            _flag = !_flag;
            return $"{_flag} - some string {i} for {DateTime.Now.Date.Millisecond}";
        }

        [IterationSetup]
        public void Setup()
        {
            Random rnd = new Random(ItemsCount);
            _list = new List<Payload>();
            for (var i = 0; i < ItemsCount; i++)
            {
                _list.Add(new Payload {
                    Key = GenerateString(i),
                    Value = -1
                });
            }
        }
        
        [Benchmark]
        public void ForSimple()
        {
            for (var i = 0; i < _list.Count; i++)
            {
                _list[i].Key = GenerateString(System.DateTime.Now.Second);
                _list[i].Value = _list[i].Key.Length * 2 * 3;
            }
        }
        
        [Benchmark]
        public void ParallelForSimple()
        {
            Parallel.For(0, _list.Count, (i) =>
            {
                _list[i].Key = GenerateString(System.DateTime.Now.Second);
                _list[i].Value = _list[i].Key.Length * 2 * 3;
            });
        }

        [Benchmark]
        public void ForEeachSimple()
        {
            foreach (var item in _list)
            {
                item.Key = GenerateString(System.DateTime.Now.Second);
                item.Value = item.Key.Length * 2 * 3;
            }
        }
        
        [Benchmark]
        public void ParallelForeachSimple()
        {
            Parallel.ForEach(_list, (item) =>
            {
                item.Key = GenerateString(System.DateTime.Now.Second);
                item.Value = item.Key.Length * 2 * 3;
            });
        }

        [Benchmark]
        public void AsParallelSimple()
        {
            _list.AsParallel().ForAll(item =>
            {
                item.Key = GenerateString(System.DateTime.Now.Second);
                item.Value = item.Key.Length * 2 * 3;
            });
        }

        [Benchmark]
        public void TaskSimple()
        {
            var tasks = new List<Task>();

            foreach (var item in _list)
            {
                tasks.Add(Task.Run(() => {
                    item.Key = GenerateString(System.DateTime.Now.Second);
                    item.Value = item.Key.Length * 2 * 3;
                }));
            }

            Task.WhenAll(tasks).Wait();
        }

        [Benchmark]
        public void SearchForSimple()
        {
            int count = 0;
            for (var i = 0; i < _list.Count; i++)
            {
                if(_list[i].Key.StartsWith("true"))
                    count++;
            }
        }

        [Benchmark]
        public void SearchForEachSimple()
        {
            int count = 0;
            foreach (var item in _list)
            {
                if (item.Key.StartsWith("true"))
                    count++;
            }
        }

        [Benchmark]
        public void SearchAsParallelSimple()
        {
            var count = _list.AsParallel().Where(w => w.Key.StartsWith("true")).Count();
        }

        [Benchmark]
        public void For()
        {
            for (var i = 0; i < _list.Count; i++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                _list[i].Key = GenerateString(System.DateTime.Now.Second);
                _list[i].Value = _list[i].Key.Length * 2 * 3;
            }
        }

        [Benchmark]
        public void ParallelFor()
        {
            Parallel.For(0, _list.Count, (i) =>
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                _list[i].Key = GenerateString(System.DateTime.Now.Second);
                _list[i].Value = _list[i].Key.Length * 2 * 3;
            });
        }

        [Benchmark]
        public void ForEeach()
        {
            foreach (var item in _list)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                item.Key = GenerateString(System.DateTime.Now.Second);
                item.Value = item.Key.Length * 2 * 3;
            }
        }

        [Benchmark]
        public void ParallelForeach()
        {
            Parallel.ForEach(_list, (item) =>
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                item.Key = GenerateString(System.DateTime.Now.Second);
                item.Value = item.Key.Length * 2 * 3;
            });
        }

        [Benchmark]
        public void AsParallel()
        {
            _list.AsParallel().ForAll(item =>
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                item.Key = GenerateString(System.DateTime.Now.Second);
                item.Value = item.Key.Length * 2 * 3;
            });
        }

        [Benchmark]
        public void Tasks()
        {
            var tasks = new List<Task>();

            foreach (var item in _list)
            {
                tasks.Add(Task.Run(() => {
                    System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                    item.Key = GenerateString(System.DateTime.Now.Second);
                    item.Value = item.Key.Length * 2 * 3;
                }));
            }

            Task.WhenAll(tasks).Wait();
        }

        [Benchmark]
        public void SearchFor()
        {
            int count = 0;
            for (var i = 0; i < _list.Count; i++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                if(_list[i].Key.StartsWith("true"))
                    count++;
            }
        }

        [Benchmark]
        public void SearchForEach()
        {
            int count = 0;
            foreach (var item in _list)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                if (item.Key.StartsWith("true"))
                    count++;
            }
        }

        [Benchmark]
        public void SearchAsParallel()
        {
            var count = _list.AsParallel().Where(w => {
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(2));
                return w.Key.StartsWith("true");
                }
            ).Count();
        }
    }
}