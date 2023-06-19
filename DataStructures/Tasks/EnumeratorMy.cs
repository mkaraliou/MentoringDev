using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class EnumeratorMy<T> : IEnumerator<T>
    {
        private Node<T> Node; 

        public EnumeratorMy(Node<T> node)
        {
            Node = node;
        }

        //public object Current => Node.Data;
        public object Current => GetData();

        //T IEnumerator<T>.Current => Node.Data;
        T IEnumerator<T>.Current => GetData();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (Node != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            while(Node.Previous != null)
            {
                Node = Node.Previous;
            }
        }

        private T GetData()
        {
            var data = Node.Data;

            Node = Node.Next;

            return data;
        }
    }
}
