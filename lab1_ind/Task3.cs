namespace cs_labs.lab1_ind;

public class Task3
{
    public static void Run(string[] args)
    {
        const int N = 5; 


        int[,] matrix = new int[N, N];
        Random rnd = new Random();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = rnd.Next(-10, 10); 
            }
        }

        
        Console.WriteLine("Матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"{matrix[i, j],3} ");
            }

            Console.WriteLine();
        }

        
        for (int i = 0; i < N; i++)
        {
            bool hasNegative = false;
            double product = 1;
            int count = 0;
            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }

                product *= matrix[i, j];
                count++;
            }

            if (!hasNegative && count > 0)
            {
                double geomMean = Math.Pow(product, 1.0 / count);
                Console.WriteLine($"Среднее геометрическое элементов в строке {i}: {geomMean:F2}");
            }
        }
    }
}