    using System.Collections;


namespace _253504_Shukaila_Lab1.Collections

public class MyList<T> : Interfaces.IList<T>, IEnumerable<T>
{
    public class Node
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node Next { get; set; }
    }

    Node head;
    Node curr;
    int size;
    public int Count
    {
        get { return size; }
    }

    public T this[int index]
    {
        get
        {
            curr = head;
            if (index < 0 || index > size - 1)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < index; i++)
            {
                curr = curr.Next;
            }
            return curr.Data;
        }

        set
        {
            curr = head;
            if (index < 0 || index > size - 1)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < index; i++)
            {
                curr = curr.Next;
            }

            curr.Data = value;
        }
    }
    public void Reset()
    {
        if (curr != null)
            throw new Exception();
        curr = head;
    }
    public void Next()
    {
        if (curr.Next != null)
        {
            curr = curr.Next;
        }
        else throw new Exception();
    }
    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
            curr = head;
        }
        else
        {
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = newNode;
        }
        size++;
    }
    public T Current()
    {
        if (curr != null)
            return curr.Data;
        else throw new Exception();
    }

    public void Remove(T item)
    {
        if (head == null)
        {
            return;
        }

        if (head.Data.Equals(item))
        {
            head = head.Next;
            return;
        }

        Node current = head;
        while (current.Next != null && !current.Next.Data.Equals(item))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public T RemoveCurrent()
    {
        if (curr == null)
            throw new Exception();
        T RemovedItem = curr.Data;
        Remove(curr.Data);
        return RemovedItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
}



