using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.aiportal.ru/articles/neural-networks/back-propagation.html
namespace NeuralNetwork
{
    class NT
    {
        public int A;
        public NT(int a)
        {
            this.A = a;
        }
        public static explicit operator NT(int value)
        {
            return new NT(value);
        }
        public override string ToString()
        {
            return this.A.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NT[] ints = new NT[] { (NT)0, (NT)1, (NT)2, (NT)3, (NT)4, (NT)5, (NT)6, (NT)7 };
            foreach (NT item in ints)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            int a = ints[2].A;
            a = 10;
            ints[3] = (NT)10;
            foreach (NT item in ints)
            {

                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            Console.WriteLine("---");




            NN ntw = new NN(
                layers_count: 2, 
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
                for (int i = 0; i < 100; i++)
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
