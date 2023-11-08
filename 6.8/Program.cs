using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int symbol1count = 0;
            int symbol2count = 0;
            char symbol_1 = Convert.ToChar(Console.ReadLine());
            char symbol_2 = Convert.ToChar(Console.ReadLine());
            foreach (char c in str) 
            {
                if(c == symbol_1)
                {
                    symbol1count++;
                }
                else if(c == symbol_2)
                {
                    symbol2count++;
                }
            }
            if(symbol1count == 0 && symbol2count == 0) 
            {
                Console.WriteLine($"Символов нет в строке");
            }
            else if(symbol1count == 0 || symbol2count == 0)
            {
                Console.WriteLine($"Одного из символов в строке нет");
                Console.ReadKey();
                return;
            }
            if(symbol1count == symbol2count)
            {
                var q = str.Distinct();
                Console.WriteLine($"Различных символов: {q.Count()}");
            }
            else if(symbol1count > symbol2count)
            {
                Console.WriteLine($"Больше символов: {symbol_1} ({symbol1count})");
            }
            else
            {
                Console.WriteLine($"Больше символов: {symbol_2} ({symbol2count})");
            }
            Console.ReadKey();
        }
    }
}
