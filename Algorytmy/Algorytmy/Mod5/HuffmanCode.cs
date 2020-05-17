using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod5
{
    class HuffmanCode
    {
        public Node Root { get; set; }
        public Dictionary<char, int> FrequencyOfSym = new Dictionary<char, int>();
        private List<Node> nodes = new List<Node>();

        public void TestFun(string massage)
        {
            BuildTree(massage);
            var m = Code(massage);
            string decodeMassage = Decode(m);
            Console.WriteLine(decodeMassage);
        }
        public bool Leaf(Node node) => (node.Left == null && node.Right == null);
        public void BuildTree(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!FrequencyOfSym.ContainsKey(str[i])) FrequencyOfSym.Add(str[i], 0);
                FrequencyOfSym[str[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in FrequencyOfSym)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, ValueFreq = symbol.Value });
            }

            while (nodes.Count >= 2)
            {
                List<Node> sorted = nodes.OrderBy(node => node.ValueFreq).ToList<Node>();

                if (sorted.Count >= 2)
                {
                    List<Node> curr = sorted.Take(2).ToList<Node>();
                    Node parent = new Node() { Symbol = '*', ValueFreq = curr[0].ValueFreq + curr[1].ValueFreq, Left = curr[0], Right = curr[1]};

                    nodes.Remove(curr[0]);
                    nodes.Remove(curr[1]);
                    nodes.Add(parent);
                }
            }
            this.Root = nodes.FirstOrDefault();
        }

        public List<bool> Code(string str)
        {
            List<bool> codded = new List<bool>();

            for (int i = 0; i < str.Length; i++)
            {
                List<bool> coddedSymb = this.Root.Tree(str[i], new List<bool>());
                codded.AddRange(coddedSymb);

                Console.Write($"LITERA -> {str[i]}  KOD: ");
                foreach (bool value in coddedSymb)
                {
                    if(value) Console.Write("1");
                    else Console.Write("0");
                }
                Console.WriteLine();
            }
            return codded;
        }

        public string Decode(List<bool> massage)
        {
            string output = "";
            Node curr = this.Root;
            foreach (bool value in massage)
            {
                if (value) { if (curr.Right != null) curr = curr.Right; }
                else { if (curr.Left != null) curr = curr.Left; }
                if (Leaf(curr)) { output += curr.Symbol; curr = this.Root;}
            }
            return output;
        }
    }
}

