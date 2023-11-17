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
                bool hasTwoNegatives = isColumnWithTwoNegativeNumber(arr, col);
                if (hasTwoNegatives)
                {
                    int newCol = col;
                    int newColumns = arr.GetLength(1);
                    while (newCol < newColumns - 1)
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            int temp = arr[i, newCol];
                            arr[i, newCol] = arr[i, newCol + 1];
                            arr[i, newCol + 1] = temp;
                        }
                        newCol++;
                    }                   
                    columns--;

                    col = -1;
                }
                else
                {
                    continue;                
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
