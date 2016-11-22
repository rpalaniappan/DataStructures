namespace DataStructures
{
    public class SinglyLinkedListNode<T>
    {
        public T Data;
        public SinglyLinkedListNode<T> Next;
    }

    public class SinglyLinkedList<T>
    {
        public int Count;
        public SinglyLinkedListNode<T> Head;

        public SinglyLinkedListNode<T> Last
        {
            get
            {
                SinglyLinkedListNode<T> current = Head;
                if (current == null) return null;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                return current;
            }
        }

        public SinglyLinkedList()
        {
            Count = 0;
            Head = null;
        }

        public void AddAtEnd(T data)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T> {Data = data, Next = null};
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Last.Next = node;
            }
            Count++;
        }

        public void AddAtBeginning(T data)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T> {Data = data, Next = null};
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            Count++;
        }

        public void DeleteAtBeginning()
        {
            Head = Head?.Next;
            Count--;
        }

        public void DeleteAtEnd()
        {
            if (Last == null)
                return;
            SinglyLinkedListNode<T> current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
            Count--;
        }
    }
}