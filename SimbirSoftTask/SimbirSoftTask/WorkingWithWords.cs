using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirSoftTask
{
    public static class WorkingWithWords
    {
        private static string FindWord(string str, int counter)
        {
            char tmpC = str[counter];
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(tmpC);

            if (counter + 1 < str.Length)
            {
                while (str[counter + 1] != ' ')
                {
                    counter++;
                    tmpC = str[counter];
                    stringBuilder.Append(tmpC);
                    if (counter + 1 >= str.Length)
                        break;

                }
            }

            var tmpStr = stringBuilder.ToString();
            return tmpStr;
        }

        public static List<string> MakeListOfWords(string str)
        {
            int counter = 0;
            int AmountOfWords = 0;
            List<string> words = new List<string>();

            while (counter < str.Length)
            {
                words.Add(FindWord(str, counter));
                counter += words[AmountOfWords].Length + 1;
                AmountOfWords++;
            }
            return words;
        }

        public static List<UnicWord> MakeListOfUnicWords(List<string> words)
        {
            List<UnicWord> unicWords = new List<UnicWord>();

            for (int i = 0; i < words.Count; i++)
            {
                int amountOfAppearence = 1;
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (words[i] == " ")
                        break;
                    if (words[i] == words[j])
                    {
                        amountOfAppearence++;
                        words[j] = " ";
                    }

                }
                if (words[i] != " ")
                {
                    unicWords.Add(new UnicWord(words[i], amountOfAppearence));
                }
            }
            return unicWords;
        }
    }
}
