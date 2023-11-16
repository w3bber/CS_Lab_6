using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = init();

            printArray(arr);

            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            for (int col = 0; col < columns; col++)
            {
                Console.WriteLine($"\nПроверка столбца {col + 1}: ");
                bool hasTwoNegatives = isColumnWithTwoNegativeNumber(arr, col);
                if (hasTwoNegatives)
                {
                    Console.WriteLine($"Столбец {col + 1} содержит ровно два отрицательных элемента.");

                    // Переставляем столбец
                    int newCol = col;
                    while (newCol < columns - 1)
                    {
                        Console.WriteLine($"Перестановка столбцов {newCol + 1} и {newCol + 2}: ");
                        for (int i = 0; i < rows; i++)
                        {
                            int temp = arr[i, newCol];
                            arr[i, newCol] = arr[i, newCol + 1];
                            arr[i, newCol + 1] = temp;
                        }
                        newCol++;
                    }
                }
            }

            Console.WriteLine("Измененный массив: ");
            printArray(arr);
            
            Console.ReadKey();
        }

        static void moveColumnToEnd(int[,] array, int columnIndex)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            while(columnIndex < cols - 1)
            {
                for(int i =0; i < rows; i++)
                {
                    int temp = array[i, columnIndex];
                    array[i, columnIndex] = array[i, columnIndex + 1];
                    array[i, columnIndex + 1] = temp;
                }
                columnIndex++;
            }

            //int[] tempColumn = new int[rows];
            //for (int i = 0; i < rows; i++)
            //{
            //    tempColumn[i] = array[i, columnIndex];
            //}
            //for (int i = columnIndex; i < cols - 1; i++)
            //{
            //    for (int j = 0; j < rows; j++)
            //    {
            //        array[j, i] = array[j, i + 1];
            //    }
            //}
            //for (int i = 0; i < rows; i++)
            //{
            //    array[i, cols - 1] = tempColumn[i];
            //}

        }
        static void printArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static int[,] init()
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine()); 
                int[,] arr = new int[n, m];
                Random r = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        arr[i, j] = r.Next(-50, 151);
                    }
                }
                return arr;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }  
        }

        static bool isColumnWithTwoNegativeNumber(int[,] arr, int columnIndex) 
        {
            int negative = 0;

            for(int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, columnIndex] < 0)
                {
                    negative++;
                }
            }
            if (negative == 2)
            {
                return true;
            }
            return false;
        }
    }
}
