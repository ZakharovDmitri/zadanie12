using System;
using System.Diagnostics;

namespace zadanie12
{
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();
        static object res1;
        static object res2;
        static int count = 0;
        public static void ArrSort(int[] name)
        {
            count = 0;
            int b = 0;
            int left = 0;//Левая граница
            int right = name.Length - 1;//Правая граница
            stopwatch.Start();
            while (left < right)
            {
                for (int i = left; i < right; i++)//Слева направо...
                {
                    if (name[i] > name[i + 1])
                    {
                        b = name[i];
                        count++;
                        name[i] = name[i + 1];
                        count++;
                        name[i + 1] = b;
                        count++;
                        b = i;
                        count++;
                    }
                }
                right = b;//Сохраним последнюю перестановку как границу
                if (left >= right) break;//Если границы сошлись выходим
                for (int i = right; i > left; i--)//Справа налево...
                {
                    if (name[i - 1] > name[i])
                    {
                        b = name[i];
                        count++;
                        name[i] = name[i - 1];
                        count++;
                        name[i - 1] = b;
                        count++;
                        b = i;
                        count++;
                    }
                }
                left = b;//Сохраним последнюю перестановку как границу
            }
            stopwatch.Stop();
            res1 = stopwatch.Elapsed;
        }
        public static void SelectionSort(int[] arr)
        {
            int min, temp;
            int length = arr.Length;
            count = 0;
            stopwatch.Start();
            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                        count++;
                    }
                }
                    
                if (min != i)
                {
                    temp = arr[i];
                    count++;
                    arr[i] = arr[min];
                    count++;
                    arr[min] = temp;
                    count++;
                }
            }
            stopwatch.Stop();            
            res2 = stopwatch.Elapsed;
        }


        static void Main(string[] args)
        {
            int[] mass = { 1, 2, 3, 4, 5, 6, 7 };
            int[] mass2 = { 7,6,5,4,3,2,1 };
            int[] mass3 = { 2, 1, 3, 4, 7, 6, 5 };

            ArrSort(mass);
            Console.WriteLine($"Результат работы сортировки упорядоченного массива по возрастанию методом перемешивания = {res1}, количество перестановок = {count}");
            SelectionSort(mass);
            Console.WriteLine($"Результат работы сортировки упорядоченного массива по возрастанию методом простого выбора = {res2}, количество перестановок = {count}");
            Console.WriteLine();

            ArrSort(mass2);
            Console.WriteLine($"Результат работы сортировки упорядоченного массива по убыванию методом перемешивания = {res1}, количество перестановок = {count}");
            SelectionSort(mass2);
            Console.WriteLine($"Результат работы сортировки упорядоченного массива по убыванию методом простого выбора = {res2}, количество перестановок = {count}");
            Console.WriteLine();

            ArrSort(mass3);
            Console.WriteLine($"Результат работы сортировки неупорядоченного массива методом перемешивания = {res1}, количество перестановок = {count}");
            SelectionSort(mass3);
            Console.WriteLine($"Результат работы сортировки неупорядоченного массива методом простого выбора = {res2}, количество перестановок = {count}");
            Console.WriteLine();

        }
    }
}
