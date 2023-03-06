namespace cs_labs.lab2_ind;

public class Tasks
{
    public static void Task1()
    {
        // Ввести данные первой фигуры с клавиатуры
        Console.WriteLine("Введите данные для первой фигуры:");
        SphericalSegment figure1 = SphericalSegment.ReadFromConsole();

        // Создать вторую фигуру
        SphericalSegment figure2 = new SphericalSegment("Шаровой сегмент", 2.0, 5);

        // Найти площади поверхности и объемы для обеих фигур
        double surfaceArea1 = figure1.GetSurfaceArea();
        double volume1 = figure1.GetVolume();
        double surfaceArea2 = figure2.GetSurfaceArea();
        double volume2 = figure2.GetVolume();

        // Вывести результаты для обеих фигур
        Console.WriteLine("Площадь поверхности первой фигуры: {0}", surfaceArea1);
        Console.WriteLine("Обьем первой фигуры: {0}", volume1);
        Console.WriteLine("Площадь поверхности второй фигуры: {0}", surfaceArea2);
        Console.WriteLine("Обьем фигуры: {0}", volume2);

        // Найти фигуру с наибольшим объемом
        SphericalSegment figureWithLargestVolume = (volume1 > volume2) ? figure1 : figure2;
        Console.WriteLine("Фигура с наибольшим обьемом: {0}", figureWithLargestVolume.GetName());

        // Найти площадь поверхности, ближайшую к 100
        double diff1 = Math.Abs(surfaceArea1 - 100);
        double diff2 = Math.Abs(surfaceArea2 - 100);
        if (diff1 < diff2)
        {
            Console.WriteLine("Плошадь первой фигуры ближе к 100");
        }
        else if (diff2 < diff1)
        {
            Console.WriteLine("Плошадь второй фигуры ближе к 100");
        }
        else
        {
            Console.WriteLine("Фигуры одинаково близки к 100");
        }
    }
    
    public static void Task2()
    {
        // Запросить у пользователя количество фигур
        Console.Write("Введите количество фигур: ");
        int count = int.Parse(Console.ReadLine());

        // Создать массив для хранения фигур
        SphericalSegment[] figures = new SphericalSegment[count];

        // Ввести данные для всех фигур и поместить их в массив
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Введите данные для фигуры {0}:", i + 1);
            figures[i] = SphericalSegment.ReadFromConsole();
        }

        // Найти фигуру с самой длинной надписью
        SphericalSegment figureWithLongestName = figures[0];
        for (int i = 1; i < count; i++)
        {
            if (figures[i].GetName().Length > figureWithLongestName.GetName().Length)
            {
                figureWithLongestName = figures[i];
            }
        }
        Console.WriteLine("Фигура с самым длинным именем: {0}", figureWithLongestName.ToString());

        // Создать новую фигуру, увеличив линейные размеры последней фигуры в массиве в 2 раза
        SphericalSegment newFigure = figures[count - 1].Resized(2);
        Console.WriteLine("Новая фигура, увеличенная в 2 раза");
        newFigure.PrintInfo();

        // Вычислить площади поверхности всех фигур в массиве
        double[] surfaceAreas = new double[count];
        for (int i = 0; i < count; i++)
        {
            surfaceAreas[i] = figures[i].GetSurfaceArea();
        }

        // Найти фигуру с наименьшей площадью и добавить префикс MIN к ее надписи
        int minIndex = 0;
        for (int i = 1; i < count; i++)
        {
            if (surfaceAreas[i] < surfaceAreas[minIndex])
            {
                minIndex = i;
            }
        }
        figures[minIndex].SetName("MIN " + figures[minIndex].GetName());

        // Посчитать количество фигур с площадью больше
        int countGreaterThan15 = 0;
        double[] volumes = new double[count];
        for (int i = 0; i < count; i++)
        {
            if (surfaceAreas[i] > 15)
            {
                countGreaterThan15++;
                volumes[i] = figures[i].GetVolume();
            }
        }
        Console.WriteLine("Количество фигур площадь которых больше 15: {0}", countGreaterThan15);

        // Вычислить сумму всех объемов фигур в массиве
        double totalVolume = 0;
        for (int i = 0; i < count; i++)
        {
            totalVolume += figures[i].GetVolume();
        }
        Console.WriteLine("Сумма всех площадей фигур: {0}", totalVolume);
    }
}
