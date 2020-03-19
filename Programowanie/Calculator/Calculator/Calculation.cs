using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Calculator
{
    class Calculation
    {
        List<char> chain;
        double num1;
        double num2;
        char sign = 'x';
        bool signChange;
        double result;
        Regex regex;

        public Calculation() {
            chain = new List<char>();
            num1 = 0;
            num2 = 0;
            result = 0;
            regex = new Regex(@"^(-?([1-9]\d*|0)(.\d*)?)$");
            signChange = true;
        }
        public string AddNumber(char c)
        {
            chain.Add(c);
            string str = string.Join("", chain);
            Match match = regex.Match(str);

            if (match.Success && str != "00")
            {
                num2 = Convert.ToDouble(str);
            }
            else
            {
                chain.RemoveAt(chain.Count - 1);
                str = string.Join("", chain);  
            }
            return str; 
        }

        public void Action(char sg)
        {
            if (chain.Count > 0 && signChange == true)
            {
                num1 = num2;
                num2 = 0;
                chain.Clear();
                signChange = false;
            }
            if (sign != sg)
                sign = sg;
            if (num1 == -1)
            {
                num1 = num2;
                num2 = 0;
            }
        }

        public string Equals()
        {
            if (chain.Count > 0)
            {
                if (sign == '+') result = num1 + num2;
                else if (sign == '-') result = num1 - num2;
                else if (sign == '*') result = num1 * num2;
                else if (sign == '/') result = num1 / num2;
                num2 = result;
                num1 = -1;
                chain.Clear();
                signChange = true;
                return Convert.ToString(result);
            }
            return Convert.ToString(result);
        }

        public string DeleteNum()
        {
            string str;
            if (chain.Count > 1)
            {
                chain.RemoveAt(chain.Count - 1);
                str = string.Join("", chain);
                num2 = Convert.ToDouble(str);
                return str;
            }
            else if (chain.Count == 1)
            {
                chain.Clear();
                return "0";
            }
            
            return "0";
        }

        public string Clear()
        {
            chain.Clear();
            num2 = 0;
            signChange = true;
            return "0";
        }

        public string ClearAll()
        {
            chain.Clear();
            num2 = 0;
            num1 = 0;
            result = 0;
            signChange = true;
            return "0";
        }

        public string ChangeSign()
        {
            if (chain.Count > 0)
            {
                if (chain[0] == '-') chain.RemoveAt(0);
                else chain.Insert(0, '-');
                string str = string.Join("", chain);
                num2 = Convert.ToDouble(str);
                return str;
            }
            return "0";
        }

    }
}
