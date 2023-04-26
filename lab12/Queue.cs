namespace cs_labs.lab12;

public class Queue<T>
{
    private Node<T> front;
    private Node<T> rear;
    private int size;
    public int Size => size;
    
    private class Node<T>
    {
        public T item;
        public Node<T> next;

        public Node(T item)
        {
            this.item = item;
            this.next = null;
        }
    }

    public Queue()
    {
        front = null;
        rear = null;
        size = 0;
    }
    

    public void Enqueue(T item)
    {
        Node<T> newNode = new Node<T>(item);

        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.next = newNode;
            rear = newNode;
        }

        size++;
    }

    public T Dequeue()
    {
        if (front == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = front.item;

        if (front == rear)
        {
            front = null;
            rear = null;
        }
        else
        {
            front = front.next;
        }

        size--;

        return item;
    }

    public T Peek()
    {
        if (front == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return front.item;
    }

    public bool IsEmpty()
    {
        return front == null;
    }
    
}
