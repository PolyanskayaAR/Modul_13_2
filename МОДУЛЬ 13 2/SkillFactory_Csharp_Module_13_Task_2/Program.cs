using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace SkillFactory_Csharp_Module_13_Task_2
{
    internal class Program
    {
        public static Dictionary <string, int> usualDict = new Dictionary<string, int>();
        public static List<int> val = new List<int> ();

        static void Main(string[] args)
        {

            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText("C:\\Users\\schek\\Desktop\\Text1.txt");

            //Убираем знаки пугктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\t', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //Подсчитываем количество встречаемости каждого слова в тексте, сохраняем в словарь Слово - Частота
            for (int i = 0; i < words.Length; i++)
            {
                if (!usualDict.ContainsKey(words[i])) // если слово встречаем 1-ый раз, добавляем в словарь, значение = 1
                {
                    usualDict.Add(words[i], 1); 
                }
                else
                {
                    usualDict[words[i]]++;            //если слово уже встречалось, значение +1
                }
            }


            foreach (KeyValuePair<string, int> p in usualDict)  //Значения сохраняем в список
            {
                val.Add(p.Value);
            }

            val.Sort ();    // Сортируем

            val.Reverse (); //Сортируем по убыванию

            for (int i = 0; i < 10; i++)   //Для 10 первых (наибольших значений встречаемости) выводим слово (ключ)
                                           // из словаря и соответствующее значение
            {
                foreach (KeyValuePair<string, int> p in usualDict)  //Перебираем весь словарь на случай,
                                                                    //когда разные слова имеют одинаковую частоту встречаемости
                {
                    if (p.Value == val[i])
                        Console.WriteLine($"{p.Key} = {p.Value}");
                }

                //var myKey = usualDict.FirstOrDefault(x => x.Value == val[i]).Key; 
                //Console.WriteLine($"{myKey} = {val[i]}");
            }

        }
    }
}