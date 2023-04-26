namespace cs_labs.lab12;

public class Stack<T>
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

        return arr[p];
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
    
}

class MaxStack<T> where T : IComparable<T>
{
    private Stack<T> stack;
    private Stack<T> maxStack;
    public int Count => stack.Count;

    public MaxStack()
    {
        stack = new Stack<T>();
        maxStack = new Stack<T>();
    }

    public void Push(T item)
    {
        stack.Push(item);

        if (maxStack.Count == 0 || item.CompareTo(maxStack.Peek()) >= 0)
        {
            maxStack.Push(item);
        }
    }

    public T Pop()
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        T item = stack.Pop();

        if (item.CompareTo(maxStack.Peek()) == 0)
        {
            maxStack.Pop();
        }

        return item;
    }

    public T Max()
    {
        if (maxStack.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return maxStack.Peek();
    }
    
}
