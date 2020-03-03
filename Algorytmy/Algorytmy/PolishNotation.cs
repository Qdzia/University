using System;
using System.Collections.Generic;

namespace Algorytmy
{ 
    class PolishNotation
    {
        List<string> eqs = new List<string>();
        List<string> reqs = new List<string>();

        public string ConvertNotation()
        {
            Stack<int> bracket = new Stack<int>();
            List<int> brtInd = new List<int>();

            //string equation = Console.ReadLine();
            string eq = "((a+b*c-d)/(e+f))*(g*h+i)";
            Console.WriteLine("Rówanie: \n" + eq);

            int count = 1;

            while (true)
            {
                string tmp = FindBracket(eq, count);
                if (tmp == eq) break;
                eq = tmp;
                count++;
            }

            for (int i = eqs.Count; i > 0; i--)
            {
                eq = eq.Replace( "" + i, eqs[i-1]);
            }
            Console.WriteLine("\nWynik:\n" + eq);

            return eq;
        }

        string FindBracket(string eq, int num)
        {
            int tmpbrt = -1;
            string tmpeq = ""; 

            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i] == '(') tmpbrt = i;
                else if (eq[i] == ')')
                {
                    tmpeq = eq.Substring(tmpbrt, i - tmpbrt+1);
                    string sec = eq.Substring(tmpbrt + 1, i - tmpbrt - 1);
                    eqs.Add(Section(sec));
                    return eq.Replace(tmpeq, "" + num);
                }
            }
            return Section(eq);
        }

        public string Section(string sec)
        {
            string output = "";
            Stack<char> stack = new Stack<char>();
            stack.Push(' ');
            bool first = false;
            bool second = false;

            foreach (char c in sec)
            {
                if (c == '+' || c == '-') second = true;
                if (c == '*' || c == '/') first = true;

                if ((stack.Peek() == '*' || stack.Peek() == '/') && (first || second))
                {
                    output += stack.Peek();
                    stack.Pop();
                    stack.Push(c);
                }
                else
                {
                    if (second) stack.Push(c);
                    else if (first) stack.Push(c);
                    else output += c;
                }

                first = false;
                second = false;
            }

            while (stack.Peek() != ' ')
            {
                output += stack.Peek();
                stack.Pop();
            }
            return output;

        }

        public string Reverse()
        {
            
            string eq = "abc*d-+ef+/gh*i+*";
            Console.WriteLine("\n\nOdwracam Rówanie: \n" + eq);

            while (true)
            {
                string tmp = RevSection(eq);
                if (tmp == eq) break;
                eq = tmp;
            }

            for (int i = reqs.Count; i > 0; i--)
            { 
                eq = eq.Replace("" + (i-1), "("+reqs[i-1]+")");
            }

            eq = RemoveBracket(eq);
            Console.WriteLine("\nWynik:\n" + eq);
            
            return eq;
        }

        string RevSection(string eq)
        {
            int n = eq.Length;
            for (int i = 0; i < n; i++)
            {
                if (eq[i] == '+' || eq[i] == '-' || eq[i] == '*' || eq[i] == '/')
                {
                    string str = eq.Substring(i - 2, 3);
                    eq = eq.Replace(str, "" + reqs.Count);
                    n -= 2;
                    i--;

                    char c = str[2];
                    str = str.Remove(2);
                    str = str.Insert(1, "" + c);
                    reqs.Add(str);
                }

            }
            return eq;
        }

        string RemoveBracket(string eq)
        {
            Stack<int> stack = new Stack<int>();
            List<int> indx = new List<int>();

            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i] == '(')
                {
                    if (i != 0)
                    {
                        if (eq[i - 1] == '*' || eq[i - 1] == '/') stack.Push('$');
                        else stack.Push(i);
                    }
                    else stack.Push(i);
                }
                else if (eq[i] == ')')
                {
                    if (stack.Peek() == '$') stack.Pop();
                    else if (i != eq.Length - 1)
                    {
                        if (eq[i + 1] == '*' || eq[i + 1] == '/')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            indx.Add(i);
                            indx.Add(stack.Peek());
                            stack.Pop();
                        }
                    }
                    else
                    {
                        indx.Add(i);
                        indx.Add(stack.Peek());
                        stack.Pop();
                    }
                } 
            }

            indx.Sort();
            indx.Reverse();
            foreach(int n in indx)
            {
                eq = eq.Remove(n,1);
            }

            return eq;
        }
    }
}