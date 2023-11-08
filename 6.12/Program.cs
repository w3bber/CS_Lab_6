using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение");
            string str = Console.ReadLine();
            char[] symbols = { ' ', ',', '\n', '!', '?' };
            string[] splitted = str.Split(symbols);
            Console.WriteLine("Введите символ");
            char symbolToDelete;
            if (!char.TryParse(Console.ReadLine(), out symbolToDelete))
            {
                Console.WriteLine("Символ должен быть один!");
                Console.ReadKey();
                return;
            }
            symbolToDelete.ToString().ToLower();
            if(!str.Contains(symbolToDelete))
            {
                Console.WriteLine("Символа " + symbolToDelete + " нет в строке");
                Console.ReadKey();
                return;
            }
            
            StringBuilder newStr = new StringBuilder();
            foreach (string word in splitted)
            {
                if(!word.ToLower().Contains(symbolToDelete))
                {
                    newStr.Append(word).Append(" ");
                }
            }
            string newString = newStr.ToString().Trim();
            Console.WriteLine(newString);

            string[] splitted_2 = newString.Split(symbols);

            // Подсчет повторений слов
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in splitted_2)
            {
                if (word.Length >= 3)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount[word] = 1;
                    }
                }
            }

            // Вывод слов, встречающихся не менее трех раз, по убыванию длины
            Console.WriteLine("Слова, которые встречаются не менее трех раз:");

            var wordsToShow = wordCount.Where(pair => pair.Value >= 3)
                                       .OrderByDescending(pair => pair.Key.Length)
                                       .Select(pair => pair.Key);

            foreach (string word in wordsToShow)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
        }
    }
}
