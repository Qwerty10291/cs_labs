namespace cs_labs.lab1;
using System;

public class Task8 {
    static void Main() {
        int[] array = new int[70];

        // Заполнение массива случайными числами
        Random random = new Random();
        for (int i = 0; i < array.Length; i++) {
            array[i] = random.Next(-100, 100);
        }

        // Сортировка элементов на четных позициях
        for (int i = 0; i < array.Length; i += 2) {
            int minIndex = i;
            for (int j = i + 2; j < array.Length; j += 2) {
                if (array[j] < array[minIndex]) {
                    minIndex = j;
                }
            }
            if (minIndex != i) {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }

        // Вывод массива на экран
        for (int i = 0; i < array.Length; i++) {
            Console.Write("{0} ", array[i]);
        }
    }
}
