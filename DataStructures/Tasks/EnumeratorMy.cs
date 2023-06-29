using System.Collections.Generic;

namespace Tasks
{
    public class EnumeratorMy<T> : IEnumerator<T>
    {
        private Node<T> node;
        private T currentElement;
        private DoublyLinkedList<T> doublyLinkedList;
        private int index = 0;

        public EnumeratorMy(DoublyLinkedList<T> list)
        {
            doublyLinkedList = list;
            node = list.NodeHead;
            currentElement = default;
        }

        public EnumeratorMy(Node<T> node)
        {
            this.node = node;
        }

        public object Current => currentElement;

        T IEnumerator<T>.Current => currentElement;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < doublyLinkedList.Length)
            {
                currentElement = node.Data;
                node = node.Next;
                index++;
                return true;
            }

            //if (Node.Next != null)
            //{
            //    Node = Node.Next;
            //    return true;
            //}

            return false;
        }

        public void Reset()
        {
            index = 0;
            node = doublyLinkedList.NodeHead;
            currentElement = default;

            //while(node.Previous != null)
            //{
            //    node = node.Previous;
            //}
        }
    }
}
