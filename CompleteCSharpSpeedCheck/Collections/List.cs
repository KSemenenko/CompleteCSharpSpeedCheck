using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CompleteCSharpSpeedCheck.Collections
{
    public class DataSet
    {
        public List<T> GenerateList<T>(int count, T item)
        {
            var collection = new List<T>();

            for (int i = 0; i < count; i++)
            {
                collection.Add(item);
            }

            return collection;
        }
        
        public List<T> GenerateListWithCapacity<T>(int count, T item)
        {
            var collection = new List<T>(count);

            for (int i = 0; i < count; i++)
            {
                collection.Add(item);
            }

            return collection;
        }
        
        public Queue<T> GenerateQueue<T>(int count, T item)
        {
            var collection = new Queue<T>();

            for (int i = 0; i < count; i++)
            {
                collection.Enqueue(item);
            }

            return collection;
        }
        
        public Queue<T> GenerateQueueWithCapacity<T>(int count, T item)
        {
            var collection = new Queue<T>(count);

            for (int i = 0; i < count; i++)
            {
                collection.Enqueue(item);
            }

            return collection;
        }
        
        public T[] GenerateArray<T>(int count, T item)
        {
            var collection = new T[count];

            for (int i = 0; i < count; i++)
            {
                collection[i] = item;
            }

            return collection;
        }
    }
}