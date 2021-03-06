using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace DZ 5.2{
    class Class2
    {
        static string siteString = "";
        public static void Message(char delWordOnChar)
        {
            Random random = new Random();
            int numCharInWord = random.Next(4, 10);
            getString();
            List<string> words = new List<string>();
            words = WordFixSize(siteString, numCharInWord);
            Console.WriteLine("Слова не более чем " + numCharInWord);
            foreach (string str in words)
            {
                Console.WriteLine(str);
            }
            char charForDel = (char)random.Next('а', 'я');
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i][words[i].Length - 1] == charForDel)
                {
                    words.Remove(words[i]);
                }
            }

            Console.WriteLine("Слова не оканчивающиеся на " + charForDel + "===============================");
            foreach (string str in words)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Самое длинное слово " + maxWord(siteString) + "===============================");
            Console.ReadLine();
        }
        static string maxWord(string stringIn)
        {
            string tempStr = "";
            string[] wordsAll = stringIn.Split(' ');
            tempStr = wordsAll[0];
            foreach (string str in wordsAll)
            {
                if (str.Length > tempStr.Length)
                {
                    tempStr = str;
                }
            }
            return tempStr;
        }
        static void getString()
        {
            string url = @"https://fpgame.ru/news/news_page.html";
            HttpClient client = new HttpClient();
            var req = client.GetStringAsync(url).Result;
            int posStart = req.IndexOf("<body>") + "<body>".Length;
            int posEnd = req.IndexOf("</body>");
            int length = posEnd - posStart;
            siteString = req.Substring(posStart, length);
        }
        static List<string> WordFixSize(string message, int numCharInWord)
        {
            string str = "";
            string[] wordsAll = message.Split(' ');
            List<string> words = new List<string>();
            char[] chDel = { ' ', ',', '.', ';', ':', '<', '>', '/' };
            string[] strDel =
            {
                "\n", "<p", "<div>\n", "<tabl>\n", "<tr>\n","<th","<nav>\n","<ul",
                "<li","<a","</a>\n","</li>\n","</ul>\n","</nav>\n","</th>\n"
            };
            foreach (string st in wordsAll)
            {
                if (st.Length > 0)
                {
                    words.Add(st);
                }
            }
            for (int i = 0; i < words.Count; i++)
            {
                foreach (string stringForDel in strDel)
                {
                    if (words[i] == stringForDel)
                    {
                        words.Remove(stringForDel);
                    }
                }
                if (words[i].Length > numCharInWord)
                {
                    string temp = words[i];
                    words.Remove(temp);
                }
            }

            return words;
        }
    }
}