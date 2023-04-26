namespace cs_labs.lab3_ind;

public class NewVector
{
    private double[] data;

    public double[] Data
    {
        get => data;
        set => data = value;
    }

    public NewVector(int n)
    {
        data = new double[n];
    }

    public NewVector(params double[] data)
    {
        this.data = data;
    }
    
    public NewVector(NewVector other)
    {
        data = (double[])other.data.Clone();
    }

    public static NewVector FromConsoleInput()
    {
        Console.WriteLine("Введите элементы вектора через пробел:");
        var input = Console.ReadLine();
        var data = input.Split().Select(double.Parse).ToArray();
        return new NewVector(data);
    }

    public override string ToString()
    {
        return $"({string.Join(", ", data)})";
    }

    public double Magnitude()
    {
        return Math.Sqrt(data.Select(x => x * x).Sum());
    }

    public double Max()
    {
        return data.Max();
    }

    public int MinIndex()
    {
        return Array.IndexOf(data, data.Min());
    }

    public NewVector PositiveOnly()
    {
        return new NewVector(data.Where(x => x > 0).ToArray());
    }

    public static NewVector Add(NewVector a, NewVector b)
    {
        if (a.data.Length != b.data.Length)
        {
            throw new ArgumentException("Векторы должны иметь одинаковую длину.");
        }

        var result = new NewVector(a.data.Length);
        for (int i = 0; i < result.data.Length; i++)
        {
            result.data[i] = a.data[i] + b.data[i];
        }
        return result;
    }

    public static double Dot(NewVector a, NewVector b)
    {
        if (a.data.Length != b.data.Length)
        {
            throw new ArgumentException("Векторы должны иметь одинаковую длину.");
        }

        return a.data.Zip(b.data, (x, y) => x * y).Sum();
    }

    public bool Equal(NewVector b)
    {
        if (data.Length != b.data.Length)
        {
            return false;
        }

        return data.SequenceEqual(b.data);
    }
    
    public double GetValue(int i)
    {
        return this.data[i];
    }

    public void SetValue(int i, double value)
    {
        this.data[i] = value;
    }
    
    
    public void FillRandom(int a, int b)
    {
        Random rnd = new Random();
        for (int i = 0; i < this.data.Length; i++)
        {
            this.data[i] = rnd.Next(a, b);
        }
    }

    public int Find(double value)
    {
        for (int i = 0; i < this.data.Length; i++)
        {
            if (this.data[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

    public bool IsSorted()
    {
        if (this.data.Length is 0 or 1)
        {
            return true;
        }
        
        for (int i = 1; i < this.data.Length; i++)
        {
            if (this.data[i] < this.data[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    public void TimSort()
    {
        const int run = 32;
        int n = this.data.Length;
    
        // Сортировка вставками
        for (int i = 0; i < n; i += run)
        {
            int end = Math.Min(i + run, n);
            for (int j = i + 1; j < end; j++)
            {
                double key = this.data[j];
                int k = j - 1;
                while (k >= i && this.data[k] > key)
                {
                    this.data[k + 1] = this.data[k];
                    k--;
                }
                this.data[k + 1] = key;
            }
        }
    
        // Сортировка слиянием
        for (int size = run; size < n; size *= 2)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min(left + 2 * size - 1, n - 1);
                TimSortMerge(this.data, left, mid, right);
            }
        }   
    }
    
    private static void TimSortMerge(double[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        double[] l = new double[n1];
        double[] r = new double[n2];
        for (int i = 0; i < n1; i++)
        {
            l[i] = arr[left + i];
        }
        
        for (int j = 0; j < n2; j++)
        {
            r[j] = arr[mid + 1 + j];
        }
        
        int k = left;
        int i1 = 0;
        int i2 = 0;
        while (i1 < n1 && i2 < n2)
        {
            if (l[i1] <= r[i2])
            {
                arr[k] = l[i1];
                i1++;
            }
            else
            {
                arr[k] = r[i2];
                i2++;
            }
            k++;
        }
        while (i1 < n1)
        {
            arr[k] = l[i1];
            i1++;
            k++;
        }
        while (i2 < n2)
        {
            arr[k] = r[i2];
            i2++;
            k++;
        }
    }
    
    public int BinarySearch( double value)
    {
        int left = 0;
        int right = this.data.Length - 1;
    
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (this.data[mid] == value)
            {
                return mid;
            }
            else if (this.data[mid] < value)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
    
        return -1; 
    }
    
    public void HeapSort()
    {
        int n = this.data.Length;
        
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            HeapSortHeapify(this.data, n, i);
        }
    
        
        for (int i = n - 1; i >= 0; i--)
        {
            (this.data[0], this.data[i]) = (this.data[i], this.data[0]);
            HeapSortHeapify(this.data, i, 0);
        }
    }

    private static void HeapSortHeapify(double[] arr, int n, int i)
    {
        int largest = i; 
        int left = 2 * i + 1; 
        int right = 2 * i + 2; 
    
        
        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }
    
        
        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }
    
        
        if (largest != i)
        {
            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            HeapSortHeapify(arr, n, largest);
        }
    }
    
    public  bool HasPrimeNumbers()
    {
        foreach (double num in this.data)
        {
            
            if (num == Math.Floor(num))
            {
                
                int intNum = (int)num;
                if (intNum < 2)
                {
                    continue;
                }
                
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(intNum); i++)
                {
                    if (intNum % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    public  void ShiftArrayLeft(int shiftBy)
    {
        int n = data.Length;
        shiftBy %= n;
        ShiftArrayLeftReverse(this.data, 0, shiftBy - 1);
        ShiftArrayLeftReverse(this.data, shiftBy, n - 1);
        ShiftArrayLeftReverse(this.data, 0, n - 1);
    }

    private static void ShiftArrayLeftReverse(double[] arr, int start, int end)
    {
        while (start < end)
        {
            (arr[start], arr[end]) = (arr[end], arr[start]);
            start++;
            end--;
        }
    }
}