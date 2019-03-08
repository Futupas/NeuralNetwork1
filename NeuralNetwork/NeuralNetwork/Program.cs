using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.aiportal.ru/articles/neural-networks/back-propagation.html
namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            foreach (int item in ints)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            ref int a = ref ints[2];
            a = 10;
            foreach (int item in ints)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            Console.WriteLine("---");




            NN ntw = new NN(
                layers_count: 1, 
                neurons_count: 4, 
                inputs_count: 2, 
                learning_rate: .1);


            ////double res = ntw.GetResult(new double[] { 0, 0 });
            //Console.WriteLine(ntw.GetResult(new double[] { .1, .1 }));
            //Console.WriteLine(ntw.GetResult(new double[] { .1, .9 }));
            //Console.WriteLine(ntw.GetResult(new double[] { .9, .1 }));
            //Console.WriteLine(ntw.GetResult(new double[] { .9, .9 }));


            Console.WriteLine(ntw.GetResult(new double[] { 0, 0 }));
            Console.WriteLine(ntw.GetResult(new double[] { 0, 1 }));
            Console.WriteLine(ntw.GetResult(new double[] { 1, 0 }));
            Console.WriteLine(ntw.GetResult(new double[] { 1, 1 }));

            //for (int j = 0; j < 100; j++)
            //{
            for (int i = 0; i < 10000; i++)
                {
                ntw.Teach(new double[] { 0, 0 }, 0);
                ntw.Teach(new double[] { 0, 1 }, 1);
                ntw.Teach(new double[] { 1, 0 }, 1);
                ntw.Teach(new double[] { 1, 1 }, 0);
            }
            //    for (int i = 0; i < 100; i++)
            //    {
            //        ntw.Teach(new double[] { 0, 1 }, 1);
            //    }
            //    for (int i = 0; i < 100; i++)
            //    {
            //        ntw.Teach(new double[] { 1, 0 }, 1);
            //    }
            //    for (int i = 0; i < 100; i++)
            //    {
            //        ntw.Teach(new double[] { 1, 1 }, 0);
            //    }
            //}

            Console.WriteLine("--");

            Console.WriteLine(ntw.GetResult(new double[] { 0, 0 }));
            Console.WriteLine(ntw.GetResult(new double[] { 0, 1 }));
            Console.WriteLine(ntw.GetResult(new double[] { 1, 0 }));
            Console.WriteLine(ntw.GetResult(new double[] { 1, 1 }));



            Console.ReadLine();
        }
    }
}
