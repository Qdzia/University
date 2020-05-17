using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod5
{
    class Shannon
    {
        public Dictionary<string, char> Dic = new Dictionary<string, char>();

        public string Code(string txt)
        {
            string last = "0";
            string result = "";
            Dictionary<char, int> words = new Dictionary<char, int>();
            for (int i = 0; i < txt.Length; i++)
            {
                if (words.ContainsKey(txt[i])) words[txt[i]]++;
                else words.Add(txt[i], 1);
            }

            List<KeyValuePair<char, int>> sortedWords = words.ToList();
            sortedWords.Sort
            (
                (x, y) => 
                -x.Value.CompareTo(y.Value)
            );
            for (int i = 0; i < sortedWords.Count - 1; i++)
            {
                Dic.Add(last, sortedWords[i].Key);
                last = 1 + last;
            }

            Dic.Add(last.Substring(0, last.Length) + "1", sortedWords.Last().Key);
            foreach (char chr in txt) result += Dic.First(x => x.Value == chr).Key;
            return result;
        }

        public string Decode(string input)
        {
            string result = "";
            int len = 1;

            for (int i = 0; i < input.Length - 1;)
            {
                while (true)
                {
                    if (Dic.TryGetValue(new string(input.Skip(i).Take(len).ToArray()), out char w))
                    { result += w; i += len; len = 1; break; }
                    len++;
                }
            }
            return result;
        }
    }
}

