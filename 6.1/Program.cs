using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = arrayInput();

            reversedArr(array);
                
            print(array);

            Console.ReadKey();
        }

        static void print(int[] array)
        {
            foreach(int value in array)
            {
                Console.Write(value + " ");
            }
        }

        static int[] arrayInput()
        {
            int[] array = new int[10];

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

        static void reversedArr(int[] array)
        {
            int maxIndex = 0;
            int minIndex = 0;
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i;
                }

                if (array[i] <= min)
                {
                    min = array[i];
                    minIndex = i - 1;
                }
            }

            if (minIndex > maxIndex)
            {
                int temp;
                for (int i = maxIndex + 1; i <= minIndex; i++, minIndex--)
                {
                    temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
            else
            {
                int temp;
                for (int i = minIndex + 1; i < maxIndex; i++, maxIndex--)
                {
                    temp = array[i];
                    array[i] = array[maxIndex];
                    array[maxIndex] = temp;
                }
            }
        }
        
    }
}
