using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._4
{
    internal class Program
    {
        const int ROWS = 6;
        const int COLS = 6;
        static void Main(string[] args)
        {
            int n = ROWS; int m = COLS;
            int count = n * m;
            int[,] matrix = new int[n, m];

            // начало змейки
            int x = 0;
            int y = 0;
            // "скорость" то есть приращение к следующему элемеенту
            int deltaX = 1;
            int deltaY = 0;
            matrix[0, 0] = 1;// первый элемент задан вручную.
            for (int i = 1; i < count; i++)
            {
                //движение по направлению
                x = x + deltaX;
                y = y + deltaY;
                matrix[x, y] = i + 1;
                //всевозможные смены направления
                if (y == 0 && deltaX == 1 && deltaY == -1 && x != n - 1)
                {
                    deltaX = 1;
                    deltaY = 0;
                    continue;
                }
                if (x == 0 && deltaX == -1 && deltaY == 1 && y != m - 1)
                {
                    deltaX = 0;
                    deltaY = 1;
                    continue;
                }
                if (y == m - 1 && deltaX == -1 && deltaY == 1)
                {
                    deltaX = 1;
                    deltaY = 0;
                    continue;
                }
                if (x == n - 1 && deltaX == 1 && deltaY == -1)
                {
                    deltaX = 0;
                    deltaY = 1;
                    continue;
                }

                if ((x == n - 1 && deltaX == 0) || (y == 0 && deltaY == 0))
                {
                    deltaX = -1;
                    deltaY = 1;
                    continue;
                }
                if ((y == m - 1 && deltaY == 0) || (x == 0 && deltaX == 0))
                {
                    deltaX = 1;
                    deltaY = -1;
                    continue;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for(int i =0; i < ROWS; i++)
            {
                for(int j = 0; j < COLS; j++)
                {
                    if (matrix[i,j] % 2 == 0)
                    {
                        int sum = SumOfOriginalNeighbors(matrix, i, j);
                        matrix[i,j] = sum;
                    }
                }
            }
            printArray(matrix);

            Console.ReadKey();
        }

        static int SumOfOriginalNeighbors(int[,] arr, int row, int col)
        {
            int sum = 0;

            // Проверяем четыре направления внутри исходной матрицы "змейкой"
            if (row > 0)
                sum += arr[row - 1, col]; // верхний сосед
            if (row < ROWS - 1)
                sum += arr[row + 1, col]; // нижний сосед
            if (col > 0)
                sum += arr[row, col - 1]; // левый сосед
            if (col < COLS - 1)
                sum += arr[row, col + 1]; // правый сосед

            return sum;
        }
        /*
        static int SumOfNeighbors(int[,] arr, int row, int col)
        {
            int sum = 0;
            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            for (int k = 0; k < 4; k++)
            {
                int newRow = row + dx[k];
                int newCol = col + dy[k];

                if (newRow >= 0 && newRow < ROWS && newCol >= 0 && newCol < COLS)
                {
                    sum += arr[newRow, newCol];
                }
            }

            return sum;
        } 
       */
        static void printArray(int[,] array)
        {
            for(int i = 0; i < ROWS; i++)
            {
                for(int j = 0; j < COLS; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
