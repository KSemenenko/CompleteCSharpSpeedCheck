using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CompleteCSharpSpeedCheck.Collections
{
    public class Benchmarks
    {
        private DataSet _dataSet;
        
        [Params(1, 150, 1000, 3333)]
        public int ItemsCount;

        [GlobalSetup]
        public void Setup()
        {
            _dataSet = new DataSet();
        }
        
        [Benchmark]
        public void Array()
        {
            _dataSet.GenerateArray<int>(ItemsCount, 1);
        }
        
        [Benchmark]
        public void List()
        {
            _dataSet.GenerateList<int>(ItemsCount, 1);
        }
        
        [Benchmark]
        public void ListWithCapacity()
        {
            _dataSet.GenerateList<int>(ItemsCount, 1);
        }
        
        [Benchmark]
        public void Queue()
        {
            _dataSet.GenerateQueue<int>(ItemsCount, 1);
        }
        
        [Benchmark]
        public void QueueWithCapacity()
        {
            _dataSet.GenerateQueueWithCapacity<int>(ItemsCount, 1);
        }
    }
}
