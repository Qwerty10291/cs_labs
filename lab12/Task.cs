namespace cs_labs.lab12;


public class Task
{
    internal class StringLengthComparer : Comparer<(String, int)>
    {
        public override int Compare((string, int) x, (string, int) y)
        {
            return y.Item1.Length.CompareTo(x.Item1.Length);
        }
    }
    public static void Task1(string path)
    {
        OrderedStack<(string, int), StringLengthComparer> stack = new(new StringLengthComparer());
        var i = 0;
        foreach (var line in File.ReadLines(path))
        {
            stack.Push((line, ++i));
        }
        Console.WriteLine();
        foreach (var (index, line) in stack)
        {
            Console.WriteLine("{0}) {1}", index, line);
        }
        Console.WriteLine("min: {0}. Length={1}, Index={2}", stack.Max().Item1, stack.Max().Item1.Length, stack.Max().Item2);
    }
    public static void Task2(string path)
    {
        Dictionary<char, char> pairs = new()
        {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };
        foreach (var line in File.ReadLines(path))
        {
            var res = ValidateBrackets(pairs, line);
            Console.WriteLine("{0} -> {1}", line, res >= 0 ? res + 1 : "YES");
        }
    }

    public static void Task3()
    {
        var data = Console.ReadLine();
        Queue<char> queue = new();
        foreach (var s in data)
        {
            switch (s)
            {
                case >= 'A' and <= 'Z':
                    queue.Enqueue(s);
                    break;
                case '*':
                    Console.Write(queue.Dequeue());
                    break;
            }
        }
    }
    
    private static int ValidateBrackets(Dictionary<char, char> pairs, string data)
    {
        HashSet<char> open = new(pairs.Values);
        Stack<(char, int)> stack = new();
        for (var i = 0; i < data.Length; i++)
        {
            if (open.Contains(data[i]))
            {
                stack.Push((data[i], i));
            }
            else if ( pairs.ContainsKey(data[i]) )
            {
                if (stack.Count == 0)
                {
                    return i;
                }
                var (openBracket, index) = stack.Pop();
                if (openBracket != pairs[data[i]])
                {
                    return i;
                }
            }
        }

        if (stack.Count != 0)
        {
            return stack.Pop().Item2;
        }
        
        return -1;
    }
    
    private static void ShiftQueueByMax(Queue<string> queue)
    {
        string maxString = null;
        int size = queue.Size;

        // Find the maximum string in the queue
        for (int i = 0; i < size; i++)
        {
            string currentString = queue.Dequeue();
            if (maxString == null || currentString.Length > maxString.Length)
            {
                maxString = currentString;
            }
            queue.Enqueue(currentString);
        }

        // Dequeue all items except the maximum and enqueue them again at the end
        for (int i = 0; i < size - 1; i++)
        {
            string currentString = queue.Dequeue();
            if (currentString != maxString)
            {
                queue.Enqueue(currentString);
            }
        }

        // Enqueue the maximum string at the end
        queue.Enqueue(maxString);
    }
}