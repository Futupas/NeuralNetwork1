using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            NN ntw = new NN(
                layers_count: 1, 
                neurons_count: 4, 
                inputs_count: 2, 
                learning_rate: .8);

            //ntw.Teach(new double[] { 0, 0 }, 0);
            //ntw.Teach(new double[] { 0, 0 }, 0);
            //ntw.Teach(new double[] { 0, 1 }, 1);
            //ntw.Teach(new double[] { 0, 1 }, 1);
            //ntw.Teach(new double[] { 1, 0 }, 1);
            //ntw.Teach(new double[] { 1, 0 }, 1);
            //ntw.Teach(new double[] { 1, 1 }, 0);
            //ntw.Teach(new double[] { 1, 1 }, 0);

            ////double res = ntw.GetResult(new double[] { 0, 0 });
            //Console.WriteLine(ntw.GetResult(new double[] { .1, .1 }));
            //Console.WriteLine(ntw.GetResult(new double[] { .1, .9 }));
            //Console.WriteLine(ntw.GetResult(new double[] { .9, .1 }));
            //Console.WriteLine(ntw.GetResult(new double[] { .9, .9 }));


            Console.WriteLine(ntw.GetResult(new double[] { .55, .1 }));
            for (int i = 0; i < 100; i++)
            {
                ntw.Teach(new double[] { .55, .1 }, .4);
                Console.WriteLine(ntw.GetResult(new double[] { .55, .1 }));
            }
            Console.ReadLine();
        }
    }
}
