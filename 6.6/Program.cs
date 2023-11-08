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

            int columns = arr.GetLength(1);

            for(int col = 0; col < columns; col++)
            {
                bool hasTwoNegatives = isColumnWithTwoNegativeNumber(arr, col);
                if(hasTwoNegatives)
                {
                    moveColumnToEnd(arr, col);
                }
            }
            Console.WriteLine("Измененный массив: ");
            printArray(arr);
            
            Console.ReadKey();
        }

        static void moveColumnToEnd(int[,]array, int columnIndex)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            if(columnIndex != -1 && columnIndex != cols -1)
            {
                int[] tempColumn = new int[rows];
                for(int i = 0; i < rows; i++)
                {
                    tempColumn[i] = array[i, columnIndex];
                }
                for(int i = columnIndex; i < cols - 1; i++)
                {
                    for(int j = 0; j < rows; j++)
                    {
                        array[j, i] = array[j, i + 1];
                    }
                }
                for(int i = 0; i < rows; i++)
                {
                    array[i, cols - 1] = tempColumn[i];
                }
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
