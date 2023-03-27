using System.Linq;
namespace cs_labs.lab4;

public class DynamicArray<T> where T : IComparable
{
    private T[] arr;
    
    public ArraySegment<T> Data
    {
        get => new ArraySegment<T>(arr, 0, len);
    }
    public int len { get; private set; }
    public int capacity { get; private set; }

    public DynamicArray()
    {
        arr = new T[1];
        len = 0;
        capacity = 1;
    }

    public DynamicArray(T[] data)
    {
        arr = data;
        len = arr.Length;
        capacity = arr.Length;
    }

    public T GetValue(int i)
    {
        if (i >= len)
        {
            throw new IndexOutOfRangeException();
        }

        return arr[i];
    }

    public void SetValue(int i, T val)
    {
        if (i >= len)
        {
            throw new IndexOutOfRangeException();
        }

        arr[i] = val;
    }

    public void Append(T val)
    {
        if (len >= capacity)
        {
            Expand();
        }

        arr[len] = val;
        len++;
    }

    public void Append(T val, int i)
    {
        if (len >= capacity)
        {
            Expand();
        }

        Array.Copy(arr, i, arr, i + 1, len - i);
        len += 1;
        arr[i] = val;

    }

    public void Remove()
    {
        Remove(len - 1);
    }

    public void Remove(int index)
    {
        len -= 1;
        if (index == len)
        {
            return;
        }
        Array.Copy(arr, index + 1, arr, index, len - index);
    }

    public void Remove(T val)
    {
        var status = Array.FindIndex(arr, w => w.CompareTo(val) == 0);
        if (status ==  -1)
        {
            throw new KeyNotFoundException();
        }
        
        Remove(status);
    }

    public int Max()
    {
        return arr.ToList().IndexOf(arr.Max());
    }

    private void Expand()
    {
        capacity *= 2;
        var newArr = new T[capacity];
        Array.Copy(arr, newArr, len);
        arr = newArr;
    }

    public bool IsFull()
    {
        return len == capacity;
    }

    public override string ToString()
    {
        return $"({string.Join(", ", new ArraySegment<T>(arr, 0, len) )})";
    }
}