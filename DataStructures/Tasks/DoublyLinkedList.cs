using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> NodeHead;
        private Node<T> NodeTail;

        public int Length { get; private set; }

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);

            if (NodeTail == null)
            {
                NodeHead = newNode;
            }
            else
            {
                newNode.Previous = NodeTail;
                NodeTail.Next = newNode;
            }

            NodeTail = newNode;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException($"Index = {index}. Length = ({Length})");
            }

            if (index == Length)
            {
                Add(e);
                return;
            }

            var newNode = new Node<T>(e);

            if (index == 0)
            {
                newNode.Next = NodeHead;
                NodeHead = newNode;
            }

            var previousNode = NodeAt(index - 1);
            var nextNode = previousNode.Next;

            previousNode.Next = newNode;
            newNode.Previous = previousNode;

            nextNode.Previous = newNode;
            newNode.Next = nextNode;
        }

        public T ElementAt(int index)
        {
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException($"Index = {index}. Length = ({Length})");
            }

            var currentNode = NodeAt(index);

            return currentNode.Data;
        }  

        public void Remove(T item)
        {
            var currentNode = NodeHead;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    // End of the collection
                    if (currentNode.Next == null)
                    {
                        NodeTail = currentNode.Previous;
                    }
                    else
                    {
                        currentNode.Next.Previous = currentNode.Previous;
                    }

                    // Start of the collection
                    if (currentNode.Previous == null)
                    {
                        NodeHead = currentNode.Next;
                    }
                    else
                    {
                        currentNode.Previous.Next = currentNode.Next;
                    }

                    currentNode = null;
                    Length--;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException($"Index = {index}. Length = ({Length})");
            }

            if (index == 0)
            {
                var element = NodeHead.Data;
                NodeHead = NodeHead.Next;
                NodeHead.Previous = null;
                Length--;
                return element;
            }
            
            if (index == Length - 1)
            {
                var element = NodeTail.Data;

                NodeTail = NodeTail.Previous;
                NodeTail.Next = null;
                Length--;
                return element;
            }

            var currentNode = NodeAt(index);

            currentNode.Previous.Next = currentNode.Next;
            currentNode.Next.Previous = currentNode.Previous;

            Length--;

            return currentNode.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorMy<T>(NodeHead);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> NodeAt(int index)
        {
            Node<T> currentNode = NodeHead;

            for (int i = index; i > 0; i--)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
