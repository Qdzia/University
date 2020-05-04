using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod5
{
    class Shannon
    {
        public Dictionary<string, char> MyDictionary = new Dictionary<string, char>();

        public string Code(string txt)
        {

            Dictionary<char, int> words = new Dictionary<char, int>();
            string last = "0";
            string result = "";

            for (int i = 0; i < txt.Length; i++)
            {
                if (words.ContainsKey(txt[i]))
                    words[txt[i]]++;

                else
                    words.Add(txt[i], 1);
            }

            List<KeyValuePair<char, int>> sortedWords = words.ToList();
            sortedWords.Sort((x, y) => -x.Value.CompareTo(y.Value));


            for (int i = 0; i < sortedWords.Count - 1; i++)
            {
                MyDictionary.Add(last, sortedWords[i].Key);
                last = 1 + last;
            }

            MyDictionary.Add(last.Substring(0, last.Length) + "1", sortedWords.Last().Key);


            foreach (char chr in txt)
            {
                result += MyDictionary.First(x => x.Value == chr).Key;
            }
            return result;
        }

        public string Decode(string input)
        {
            string outcome = "";
            int lenght = 1;

            for (int i = 0; i < input.Length - 1;)
            {
                while (true)
                {
                    if (MyDictionary.TryGetValue(new string(input.Skip(i).Take(lenght).ToArray()), out char w))
                    {
                        outcome += w;
                        i += lenght;
                        lenght = 1;
                        break;
                    }
                    lenght++;
                }
            }
            return outcome;
        }
    }
}

