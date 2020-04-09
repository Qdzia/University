using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI
{
    class kNN
    {
        public void kNNClassify(double[][] data, double[] unknown)
        {
            int numClasses = 3;
            int k = 4;
            FindClassInData(numClasses, ref data);
            
            int predicted = Classify(unknown, data, numClasses, k);

        }

        private void FindClassInData(int numClasses, ref double[][] data)
        {
            var classes = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < numClasses; j++)
                {
                    if (data[i][j+4]==1) data[i][4] = j;
                }
            }
        }

        private int Classify(double[] unknown, double[][] data, int numClasses, int k)
        {
            int n = data.Length;
            IndexAndDistance[] info = new IndexAndDistance[n];
            for (int i = 0; i < n; ++i)
            {
                IndexAndDistance curr = new IndexAndDistance();
                curr.idx = i;
                curr.dist = Distance(unknown, data[i]);
                info[i] = curr;
            }
            Array.Sort(info);
            DisplayPrediction(info,k,data);
            int result = Vote(info, data, numClasses, k);
            return result;

        }

        private void DisplayPrediction(IndexAndDistance[] info, int k, double[][] data)
        {
            Console.WriteLine("Distance        Values              Class");
            for (int i = 0; i < k; ++i)
            {
                string dist = info[i].dist.ToString("F3");

                Console.WriteLine(dist + " || " + FlowerToString(data, info[i].idx, i, info));

            }
        }
        String FlowerToString(double[][] data, int idx, int i, IndexAndDistance[] info)
        {
            return String.Format("{0:0.00} | {1:0.00} | {2:0.00} | {3:0.00} | {4} ",
                    data[idx][0], data[idx][1], data[idx][2], data[idx][3], data[idx][4], info[i].dist);
        
        }
        double Distance(double[] unknown, double[] data)
        {
            double sum = 0.0;
            for (int i = 0; i < unknown.Length; ++i)
                sum += (unknown[i] - data[i]) * (unknown[i] - data[i]);
            return Math.Sqrt(sum);
        }

        int Vote(IndexAndDistance[] info, double[][] trainData, int numClasses, int k)
        {
            int[] votes = new int[numClasses];  
            for (int i = 0; i < k; ++i)
            {       
                int idx = info[i].idx;            
                int c = (int)trainData[idx][4];
                ++votes[c];
            }
            int mostVotes = 0;
            int classWithMostVotes = 0;
            for (int j = 0; j < numClasses; ++j)
            {
                if (votes[j] > mostVotes)
                {
                    mostVotes = votes[j];
                    classWithMostVotes = j;
                }
            }
            return classWithMostVotes;
        }
    }
}
