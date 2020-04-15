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
        string[] decisions;


        public FuzzyLogic()
        {
            rules = new List<FuzzyRule>();
            results = new List<double>();
            resultOfRules = new List<double>();
            numOfEntry = 0;
        }

        public void UseFuzzyLogic(double[][] data)
        {
            numOfEntry = data.Length;
            rules.Add(new FuzzyRule(0.1, 0.2, 1, 1));
            rules.Add(new FuzzyRule(0.4, 0.6, 1, 1));
            rules.Add(new FuzzyRule(0.6, 0.7, 1, 1));

            LoadData(data);
            CalculateResults();
            Decision();

        }
        public void LoadData(double[][] data)
        {
            for (int i = 0; i < numOfEntry; i++)
            {
                rules[2].AddElement(data[i][0]);
                rules[1].AddElement(data[i][2]);
                rules[0].AddElement(data[i][3]);
                //Console.WriteLine("N[{1}] VAL: {0:0.000}", data[i][3], i);
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
                    //Console.WriteLine("N[{1}] F: {0:0.000}", rules[j].GetElOfIndx(i), i);
                }
                results.Add(product);
            }
        }
        void Decision()
        {
            decisions = new string[numOfEntry];

            for (int i = 0; i < numOfEntry; i++)
            {
                decisions[i] = Judge(results[i]);
                Console.WriteLine("N[{2}] F: {0:0.00000} - D: {1}", results[i], decisions[i],i);
            }   
        }
        
        double Avrg(params double[] numbers)
        {
            double results = 0;
            for (int i = 0; i < numbers.Length; i++)
                results += numbers[i];

            return results/numbers.Length;
        }
       string Judge(double a)
        {
            if (a > 0.9) return "3. Iris-virginica";
            else if (a > 0) return "2. Iris-versicolor";
            else return "1. Iris-setosa";
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
