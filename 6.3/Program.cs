using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            task();          
        }

        static void task()
        {
            try
            {
                Console.Write("Введите размерность массива: ");
                int SIZE = int.Parse(Console.ReadLine());
                int[] arr = new int[SIZE];
                Random r = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = r.Next(-15, 31);
                }
                Console.WriteLine("Исходный массив: ");
                print(arr);
                int minValue = arr.Min();
                int maxValue = arr.Max();
                Console.WriteLine("Максимальный элемент: " + maxValue);
                Console.WriteLine("Минимальный элемент: " + minValue);
                int[] newArr = new int[SIZE + numberOfOccurrences(arr, maxValue)];
                int newIndex = 0;
                bool inserted = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == maxValue && !inserted)
                    {
                        newArr[newIndex] = minValue;
                        newIndex++;
                        inserted = true;
                    }
                    newArr[newIndex] = arr[i];
                    newIndex++;
                }
                
                Console.WriteLine("Изменённый массив");
                print(newArr);

                int uniqueCount = removingDuplicateElements(newArr);
                int[] uniqueArray = new int[uniqueCount];

                Array.Copy(newArr, uniqueArray, uniqueCount);

                Console.WriteLine("Удаление повторяющихся чисел");
                print(uniqueArray);

                Console.ReadKey();
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            

        }
        static int numberOfOccurrences(int[] arr, int value)
        {
            int count = 0;
            foreach(int el in arr)
            {
                if(el == value)
                {
                    count++;
                }
            }
            return count;
        }

        static int removingDuplicateElements(int[] array)
        {
            int uniqueCount = 0;
            for(int i = 0; i < array.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < i; j++)
                {
                    
                    if (array[i] == array[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if(!isDuplicate)
                {
                    array[uniqueCount] = array[i];
                    uniqueCount++;
                }
            }
            return uniqueCount;
        }
        
        static void print(int[] array, int count = -1)
        {
            if(count == -1)
            {
                count = array.Length;
            }
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
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
