using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI
{
    class FuzzyLogic
    {
        List<FuzzyRule> rules;
        List<double> results;
        List<double> resultOfRules;
        int numOfEntry;


        public FuzzyLogic()
        {
            rules = new List<FuzzyRule>();
            results = new List<double>();
            resultOfRules = new List<double>();
            numOfEntry = 0;
        }
        public void LoadData(double[,] data) 
        {
            numOfEntry = data.Length;
            for (int i = 0; i < numOfEntry; i++)
            {
                for (int j = 0; j < rules.Count; j++)
                {
                    rules[j].AddElement(data[i,j]);
                }
            }
        }

        void CalculateResults() 
        {
            for (int i = 0; i < numOfEntry; i++)
            {
                double product = 1;
                for (int j = 0; j < rules.Count; j++)
                {
                    product *= rules[j].GetElOfIndx(i);
                }
                results.Add(product);
            }
        }

        void AddAvrgValue(double[] avrg) 
        {
            foreach (double value in avrg)
                resultOfRules.Add(value);
        }

        void Desicion() 
        {
            double decision = 0;
            for (int i = 0; i < resultOfRules.Count; i++)
                decision += results[i] * resultOfRules[i];
            
            double tmp = 0;
            for (int i = 0; i < results.Count; i++)
                tmp += results[i];
            
            double result = decision / tmp;
        }
        
        double prod(params double[] numbers)
        {
            double results = 1;
            for (int i = 0; i < numbers.Length; i++)
                results *= numbers[i];

            return results;
        }
       double min(double a, double b)
        {
            if (a < b) return a;
            else return b;
        }
        public void AddRule(double a, double b, double c)
        {
            rules.Add(new FuzzyRule(a, b, c));
        }
        public void AddRule(double a, double b, double c, double d)
        {
            rules.Add(new FuzzyRule(a, b, c, d));
        }
    }
}
