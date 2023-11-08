using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = init();
            printArray(array);
            int[,] newArray = deleteMinElement(array);
            Console.WriteLine("Изменённый массив");
            printArray(newArray);
            newArray = addZeros(newArray);
            if(newArray == null)
            {
                Console.WriteLine("Массив нечетный");
            }    
            else
            {
                Console.WriteLine("Изменённый массив с добавленными нулями");
                printArray(newArray);
            }
            Console.ReadKey();
        }

        static void printArray(int[,] array, int n = -1, int m = -1)
        {
            if (n == -1 && m == -1)
            {
                int row = array.GetLength(0);
                int col = array.GetLength(1);
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            
        }

        static int[,] deleteMinElement(int[,] array)
        {
            int min = 200;
            int minRowIndex = 0;
            int minColsIndex = 0;
            int[,] temp = new int[array.GetLength(0) - 1, array.GetLength(1) -1];
            int indexRow = 0;
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minRowIndex = i;
                        minColsIndex = j;
                    }
                }
            }
            Console.WriteLine("Min element: " + min);
            
            for(int i = 0; i < array.GetLength(0); i++)
            {
                if(i == minRowIndex)
                {
                    continue;
                }
                else
                {
                    int indexCol = 0;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if(j == minColsIndex)
                        {
                            continue;
                        }
                        temp[indexRow, indexCol] = array[i, j];
                        indexCol++;
                    }
                    indexRow++;
                }
            }

            return temp;
        }

        static int[,] addZeros(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int newRows = array.GetLength(0) + 1;
            int newCols = array.GetLength(1) + 1;
            int[,] temp = new int[newRows, newCols];
            if (rows % 2 == 0 && cols % 2 == 0)
            {
                int midIndexRow = (rows / 2);
                int midIndexCol = (cols / 2);
                for(int i = 0; i < newRows; i++)
                {
                    for(int j = 0; j < newCols; j++)
                    {
                        if(i == midIndexRow)
                        {
                            temp[i, j] = 0;
                        }
                        else if(j == midIndexCol)
                        {
                            temp[i, j] = 0;
                        }
                        else
                        {
                            int sourceRow = i > midIndexRow ? i - 1 : i;
                            int sourceCol = j > midIndexCol ? j - 1 : j;
                            temp[i, j] = array[sourceRow, sourceCol];
                        }
                    }
                }
                return temp;
            }
            else
            {
                return null;
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
