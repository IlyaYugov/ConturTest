using System;
using System.Collections.Generic;
using System.Linq;

namespace ConturTest
{
   /* Задача:

    Даны два целых неотрицательных числа, записанных следующим образом. Каждая цифра записывается её 
    английским названием, первая буква цифры большая, остальные - маленькие.

    Например, число 1293 записывается как "OneTwoNineThree", число 135 как "OneThreeFive", число 0 
    как "Zero". Ведущие нули в записи отсутствуют (за исключением самого числа 0).

    Нужно сравнить эти два числа (сравнивать их нужно как числа) и вернуть:
    -1, если первое число меньше, 
    0, если значения чисел совпадают, 
    1, если первое число больше.

    Пример использования:
    var result = new NumberStringsComparer().Compare("OneTwoNineThree", "OneThreeFive");
 
    Для проверки решения необходимо запустить тесты.

    Подсказка:
    При использовании класса System.Numerics.BigInteger не пройдут тесты TestBig (числа из 200 тысяч цифр).
    */

    public class NumberStringsComparer
    {
        private static readonly string[] digits =
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
        };

        private static readonly char[] bigLetters =
                    {
            'Z',
            'O',
            'T',
            'F',
            'S',
            'E',
            'N',
        };

        public int Compare(string first, string second)
        {
            var firstDigits = ConvertToDigits(first);
            var secondDigits = ConvertToDigits(second);
            return CompareListsOfDigits(firstDigits, secondDigits);
        }

        private List<int> ConvertToDigits(string s)
        {
            var numbers = new List<string>();
            var bigLetterIndexes = new List<int>();
            
            for (int i = 0; i < s.Length; i++)
            {
                if (bigLetters.Contains(s[i]))
                    bigLetterIndexes.Add(i);
            }
            for (int i = 0; i < bigLetterIndexes.Count; i++)
            {
                if(i+1 <= bigLetterIndexes.Count - 1)
                {
                    var startIndex = bigLetterIndexes[i];
                    var finishIndex = bigLetterIndexes[i+1];
                    var length = finishIndex - startIndex;
                    
                    var number = s.Substring(startIndex, length);
                    numbers.Add(number);
                }
                else
                {
                    var startIndex = bigLetterIndexes[i];
                    var finishIndex = s.Length;
                    var length = finishIndex - startIndex;
                    
                    var number = s.Substring(startIndex, length);
                    numbers.Add(number);
                }
                         
            }
            
            var res = numbers.Select(num => Array.IndexOf(digits, num)).ToList();
            
            return res;
        }

        private int CompareListsOfDigits(List<int> first, List<int> second)
        {
            if (first.Count < second.Count)
                return -1;
            else if (first.Count > second.Count)
                return 1;
            
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] < second[i])
                    return -1;
                else if (first[i] > second[i])
                    return 1;
            }

            return 0;
        }
    }
}