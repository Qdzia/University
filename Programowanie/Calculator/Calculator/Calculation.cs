using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    class Calculation
    {
        List<char> chain;
        double num1;
        double num2;
        char sign = 'x';
        double result;

        public Calculation() {
            chain = new List<char>();
            num1 = 0;
            num2 = 0;
            result = 0;
        }
        public string AddNumber(char c)
        {
            chain.Add(c);
            string str = string.Join("", chain);
            num2 = Convert.ToDouble(str);
            return str;
        }

        public void Action(char sg)
        {
            num1 = num2;
            num2 = 0;
            sign = sg;
            chain.Clear();
        }

        public string Equals()
        {
            if (sign == '+') result = num1 + num2;
            else if (sign == '-') result = num1 - num2;
            else if (sign == '*') result = num1 * num2;
            else if (sign == '/') result = num1 / num2;
            num2 = result;
            return Convert.ToString(result);
        }

        public string DeleteNum()
        {
            chain.RemoveAt(chain.Count - 1); 
            string str = string.Join("", chain);
            num2 = Convert.ToDouble(str);
            return str;
        }

        public string Clear()
        {
            chain.Clear();
            num2 = 0;
            return "0";
        }

        public string ClearAll()
        {
            chain.Clear();
            num2 = 0;
            num1 = 0;
            result = 0;
            return "0";
        }

        public string ChangeSign()
        {
            if (chain[0] == '-') chain.RemoveAt(0);
            else chain.Insert(0, '-');
            string str = string.Join("", chain);
            num2 = Convert.ToDouble(str);
            return str;

        }

    }
}
