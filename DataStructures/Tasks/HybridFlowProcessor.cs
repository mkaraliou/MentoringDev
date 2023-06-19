using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> _collection;

        public HybridFlowProcessor()
        {
            _collection = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (_collection.Length == 0)
            {
                throw new InvalidOperationException("Collection is empty");
            }

            return _collection.ElementAt(0);
        }

        public void Enqueue(T item)
        {
            Push(item);
        }

        public T Pop()
        {
            if (_collection.Length == 0)
            {
                throw new InvalidOperationException("Collection is empty");
            }

            return _collection.ElementAt(_collection.Length - 1);
        }

        public void Push(T item)
        {
            _collection.Add(item);
        }
    }
}
