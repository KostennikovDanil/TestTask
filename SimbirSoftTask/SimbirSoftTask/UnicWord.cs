using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirSoftTask
{
    public class UnicWord
    {
        public string Word { get; set; }
        public int AmountOfAppearence { get; set; }
        public UnicWord(string word, int amountOfAppearence)
        {
            Word = word;
            AmountOfAppearence = amountOfAppearence;
        }
    }
}
