﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Homework5WorkerService
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
    }
    public class Queue<T> : IQueue<T> where T : class
    {
        private readonly ConcurrentQueue<T> _items = new ConcurrentQueue<T>();
        public T Dequeue()
        {
            var success = _items.TryDequeue(out var Item);
            return success ? Item : null;
        }

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Enqueue(item);
        }
    }
}
