using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy.Mod5
{
    class Node
    {
        public char Symbol;
        public Node Right;
        public Node Left;
        public int ValueFreq;

        public List<bool> Tree(char symbol, List<bool> data)
        {
            if (Right == null && Left == null)
            {
                if (symbol == this.Symbol)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPathData = new List<bool>();
                    leftPathData.AddRange(data);
                    leftPathData.Add(false);

                    left = Left.Tree(symbol, leftPathData);
                }

                if (Right != null)
                {
                    List<bool> rightPathData = new List<bool>();
                    rightPathData.AddRange(data);
                    rightPathData.Add(true);

                    right = Right.Tree(symbol, rightPathData);
                }
                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }

    }
}
