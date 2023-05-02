using System.Collections;

namespace cs_labs.lab12;

public class Stack<T> : IEnumerable<T>
{
    private List<T>  arr = new();
    private int p = 0;

    public int Count => p;

    public T Pop()
    {
        if (p == -1)
        {
            throw new IndexOutOfRangeException();
        }

        return arr[--p];
    }

    public T Peek()
    {
        if (p > arr.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return arr[p - 1];
    }

    public void Push(T data)
    {
        if (p >= arr.Count)
        {
            arr.Add(data);
            p++;
        }
        else
        {
            arr[p++] = data;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = p - 1; i >= 0; i--)
        {
            yield return arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class OrderedStack<T, U>: IEnumerable<T>  
    where U : IComparer<T>
{
    private Stack<T> stack;
    private Stack<T> orderedStack;
    private U Comparator;
    public int Count => stack.Count;

    public OrderedStack(U comparer)
    {
        stack = new Stack<T>();
        orderedStack = new Stack<T>();
        Comparator = comparer;
    }

    public void Push(T item)
    {
        stack.Push(item);

        if (orderedStack.Count == 0 || Comparator.Compare(item, orderedStack.Peek()) >= 0)
        {
            orderedStack.Push(item);
        }
    }

    public T Pop()
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        T item = stack.Pop();

        if (Comparator.Compare(item, orderedStack.Peek()) == 0)
        {
            orderedStack.Pop();
        }

        return item;
    }

    public T Max()
    {
        if (orderedStack.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return orderedStack.Peek();
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return stack.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}