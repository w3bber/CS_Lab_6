using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SIZE = 15;
            int[] arr_1 = new int[SIZE] { 10, 9, 9, 8, 7, 6, 4, 3, 3, 2, 2, 2, 1, 1, 0 };
            int[] arr_2 = new int[SIZE] { 10, 10, 9, 9, 7, 6, 6, 4, 3, 3, 3, 2, 2, 0, 0 };
            Array.Reverse(arr_1);
            Array.Reverse(arr_2);
            int[] result_arr = FindIntersection(arr_1, arr_2);
            print(result_arr);
        }
        static int[] FindIntersection(int[] arr_1, int[] arr_2)
        {
            int[] result_arr = new int[arr_1.Length + arr_2.Length];
            int intersectionIndex = 0;

            int index_1 = 0;
            int index_2 = 0;

            while(index_1 < arr_1.Length && index_2 < arr_2.Length)
            {
                if (arr_1[index_1] < arr_2[index_2])
                {
                    index_1++;
                }
                else if (arr_1[index_1] > arr_2[index_2])
                {
                    index_2++;
                }
                else
                {
                    result_arr[intersectionIndex] = arr_1[index_1];
                    intersectionIndex++;

                    index_1++;
                    index_2++;
                }
            }

            Array.Resize(ref result_arr, intersectionIndex);
            return result_arr;
        }

        static void print(int[] array)
        {
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
        }
        static int[] arrayInput(int SIZE)
        {
            int[] array = new int[SIZE];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введите {i + 1}-й элемент массива: ");
                if (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                    i--; // Повторяем запрос для данного элемента
                }
            }
            return array;
        }


    }
}
