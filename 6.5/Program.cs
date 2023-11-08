using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _6._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                int m = n;
                int[,] arr = new int[n, m];
                Random r = new Random();
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        arr[i, j] = r.Next(-50, 151);
                    }
                }
                printArray(arr);
                bool isLogiccSquare = isLogicSquare(arr);
                if(!isLogiccSquare)
                {
                    sortColumnsByMinValues(arr);
                    Console.WriteLine("\nМассив после сортировки столбцов по неубыванию минимальных элементов:");
                    printArray(arr);
                }
                else Console.WriteLine("\nМассив - логический квадрат");
                
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
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

        static bool isLogicSquare(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            int diagonal1Sum = 0;
            int diagonal2Sum = 0;

            for(int i = 0; i <  rows; i++)
            {
                int rowSum = 0;
                int colSum = 0;
                for(int j = 0; j < cols; j++)
                {
                    rowSum += array[i, j];
                    colSum += array[j, i];

                    if(i == j)
                    {
                        diagonal1Sum += array[i, j];
                    }
                    if(i+j == rows - 1)
                    {
                        diagonal2Sum += array[i, j];
                    }
                }
                if (rowSum != colSum) return false;
                
            }
            return diagonal1Sum == diagonal2Sum && diagonal1Sum == rows * (rows * rows + 1) / 2;
        }

        static void sortColumnsByMinValues(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            int[] minValues = new int[cols];

            for(int j = 0; j < cols; j++)
            {
                int min = arr[0, j];
                for(int i = 1; i  < rows; i++)
                {
                    if (arr[i, j] < min) min = arr[i, j];
                }
                minValues[j] = min;
            }
            
            int[] columnIndices = new int[cols];
            for (int i = 0; i < cols; i++)
            {
                columnIndices[i] = i;
            }

            
            Array.Sort(columnIndices, (x, y) => minValues[x].CompareTo(minValues[y]));

            
            int[,] tempArray = new int[rows, cols];

            
            for (int i = 0; i < cols; i++)
            {
                int colIndex = columnIndices[i];
                for (int j = 0; j < rows; j++)
                {
                    tempArray[j, i] = arr[j, colIndex];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = tempArray[i, j];
                }
            }
        }
    }
}
