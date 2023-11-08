using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int sum = 0;
            string numbers = "";
            int value = 0;
            List<int> ints = new List<int>();
            if (str[str.Length - 1] == '-')
            {
                str.Remove(str.Length - 1);
            }
            foreach (char c in str)
            {
                if(char.IsDigit(c) || c == '-')
                {
                    numbers += c;
                }
                else
                {
                    if(!int.TryParse(numbers, out value))
                    {
                        continue;
                    }
                    else
                    {
                        value = int.Parse(numbers);
                        ints.Add(value);
                        numbers = "";
                    }                   
                }
            }
            if (char.IsDigit(str[str.Length -1]))
            {
                value = int.Parse(numbers);
                ints.Add(value);
                numbers = "";
            }
            
            foreach(var el in  ints)
            {
                sum += el;
            }
            Console.WriteLine("Сумма чисел равна: " + sum);
            Console.ReadKey();
        }
    }
}
