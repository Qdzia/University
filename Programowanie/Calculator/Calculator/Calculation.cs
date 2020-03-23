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
        Regex wholeNum;
        Regex zeroDot;

        public Calculation() {
            chain = new List<char>();
            num1 = 0;
            num2 = 0;
            result = 0;
            wholeNum = new Regex(@"^(-?([1-9]\d*)(,\d*)?)$");
            zeroDot = new Regex(@"^(-?0(,\d*)?)$");
            signChange = true;
        }
        public string AddNumber(char c)
        {
            if (num2 == result && num2 != 0) chain.Clear();
            if(chain.Count == 0 && c ==',') chain.Add('0');
            chain.Add(c);
            if(chain.Count == 2)
                if(chain[0] == '0' && chain[1] != ',') chain.RemoveAt(0);

            string str = string.Join("", chain);
            Match wholeNumMatch = wholeNum.Match(str);
            Match zeroDotMatch = zeroDot.Match(str);

            if (wholeNumMatch.Success || zeroDotMatch.Success)
                num2 = Convert.ToDouble(str);
            else
            {
                chain.RemoveAt(chain.Count - 1);
                str = string.Join("", chain);  
            }
            return str; 
        }

        public void Action(char sg)
        {
            if ((chain.Count > 0 || num2 != 0) && signChange == true)
            {
                num1 = num2;
                num2 = 0;
                chain.Clear();
                signChange = false;
            }
            if (sign != sg)
                sign = sg;
        }

        public string Equals()
        {
            if (chain.Count > 0 )
            {
                if (sign == '+') result = num1 + num2;
                else if (sign == '-') result = num1 - num2;
                else if (sign == '*') result = num1 * num2;
                else if (sign == '/') result = num1 / num2;
                
                string strResult = Convert.ToString(result);
                num2 = result;
                num1 = 0;
                chain.Clear();
                signChange = true;
                return strResult;
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
                num2 = 0;
                return "0";
            }
            
            return "0";
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
            signChange = true;
            return "0";
        }

        public string ChangeSign()
        {
            if (chain.Count > 0)
            {
                if (!(chain.Count < 3 && chain[0] == '0'))
                {
                    if (chain[0] == '-') chain.RemoveAt(0);
                    else chain.Insert(0, '-');
                    string str = string.Join("", chain);
                    num2 = Convert.ToDouble(str);
                    return str;
                }
            }
            return "0";
        }

    }
}
