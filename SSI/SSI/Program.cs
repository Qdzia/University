using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadData rd = new ReadData();
            Graphic ghp = new Graphic();
            SoftSet ss = new SoftSet();
            Bayes bay = new Bayes();
            kNN knn = new kNN();

            double[] param = new double[4] { 0.7, 0.4, 0.5, 0.2 };
            //ss.Start();
            rd.ReadFlower();
            knn.kNNClassify(rd.GetData(), param);
            //bay.Classify(param,rd.GetData(),3);
            //rd.PrintData();
            //ghp.FindKeyPoints();
            Console.ReadLine();
        }
    }
}
