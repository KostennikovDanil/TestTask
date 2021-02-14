using System;
using System.Collections.Generic;

namespace SimbirSoftTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Task();


        }
        static void Task()
        {
            try
            {
                Console.WriteLine("Enter link to site");
                string site = Console.ReadLine();

                string str = Parser.Pars(site);
                str = Parser.HtmlPars(str);
                List<string> words = WorkingWithWords.MakeListOfWords(str);
                List<UnicWord> unicWords = WorkingWithWords.MakeListOfUnicWords(words);
                Console.WriteLine($"Amount of unic words: {unicWords.Count}");
                foreach (var w in unicWords)
                {
                    Console.WriteLine($"{w.Word}: {w.AmountOfAppearence}");
                }
            }
            catch
            {

            }
            
        }
    }

    

}
