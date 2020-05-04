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
        private List<Node> nodes = new List<Node>();
        public Node Root { get; set; }
        public Dictionary<char, int> SymbolFrequency = new Dictionary<char, int>();

        public void BuildTree(string text)
        {
            //Create Dictionary 
            for (int i = 0; i < text.Length; i++)
            {
                //Add new symbol
                if (!SymbolFrequency.ContainsKey(text[i]))
                    SymbolFrequency.Add(text[i], 0);

                SymbolFrequency[text[i]]++;
            }

            //Add nodes with value
            foreach (KeyValuePair<char, int> symbol in SymbolFrequency)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, ValueFreq = symbol.Value });
            }

            while (nodes.Count >= 2)
            {
                //Sort by Value
                List<Node> sortedNodes = nodes.OrderBy(node => node.ValueFreq).ToList<Node>();

                if (sortedNodes.Count >= 2)
                {
                    //Take 2 items 
                    List<Node> take = sortedNodes.Take(2).ToList<Node>();

                    //Create parent with sum Value 
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        ValueFreq = take[0].ValueFreq + take[1].ValueFreq,
                        Left = take[0],
                        Right = take[1]
                    };

                    //Remove child and add parents
                    nodes.Remove(take[0]);
                    nodes.Remove(take[1]);
                    nodes.Add(parent);

                }
            }

            this.Root = nodes.FirstOrDefault();
        }

        public BitArray Code(string text)
        {
            List<bool> encodeText = new List<bool>();

            for (int i = 0; i < text.Length; i++)
            {
                List<bool> encodeSymbol = this.Root.Tree(text[i], new List<bool>());

                encodeText.AddRange(encodeSymbol);

                Console.Write($"Symbol : {text[i]}  Encoded : ");

                foreach (bool bit in new BitArray(encodeSymbol.ToArray()))
                {
                    Console.Write(bit);
                }
                Console.WriteLine();
            }

            BitArray bits = new BitArray(encodeText.ToArray());

            return bits;
        }

        public string Decode(BitArray bits)
        {
            string decode = "";
            Node curr = this.Root;


            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (curr.Right != null)
                        curr = curr.Right;
                }
                else
                {
                    if (curr.Left != null)
                        curr = curr.Left;
                }

                if (Leaf(curr))
                {
                    decode += curr.Symbol;
                    curr = this.Root;
                }

            }
            return decode;
        }

        public bool Leaf(Node node)
        {

            return (node.Left == null && node.Right == null);
        }
    }
}

