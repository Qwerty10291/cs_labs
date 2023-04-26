namespace cs_labs.lab12;

public class Task
{
    
    
    public static void Task2()
    {
        Dictionary<char, char> pairs = new()
        {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };
        var sampleTrue = "((s)[test])";
        var sampleFalse = "()[]}";
        Console.WriteLine(ValidateBrackets(pairs, sampleTrue));
        Console.WriteLine(ValidateBrackets(pairs, sampleFalse));
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
                    return index;
                }
            }
        }

        if (stack.Count != 0)
        {
            return stack.Pop().Item1;
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