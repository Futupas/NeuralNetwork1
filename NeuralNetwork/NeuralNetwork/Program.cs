using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

//http://www.aiportal.ru/articles/neural-networks/back-propagation.html
namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "";
            NN ntw = new NN(
                layers_count: 1, 
                neurons_count: 4, 
                inputs_count: 2, 
                learning_rate: .01);

            double[] vals = new double[4] { 0, 0, 0, 0 };
            double[] oldvals = new double[4];// = vals;

            vals[0] = ntw.GetResult(new double[] { 0, 0 });
            Console.WriteLine(vals[0]);
            vals[1] = ntw.GetResult(new double[] { 0, 1 });
            Console.WriteLine(vals[1]);
            vals[2] = ntw.GetResult(new double[] { 1, 0 });
            Console.WriteLine(vals[2]);
            vals[3] = ntw.GetResult(new double[] { 1, 1 });
            Console.WriteLine(vals[3]);

            oldvals[0] = vals[0];
            oldvals[1] = vals[1];
            oldvals[2] = vals[2];
            oldvals[3] = vals[3];

            for (int i = 0; i < 1000000; i++)
            {
                ntw.Teach(new double[] { 0, 0 }, 0);
                ntw.Teach(new double[] { 0, 1 }, 1);
                ntw.Teach(new double[] { 1, 0 }, 1);
                //ntw.Teach(new double[] { 1, 1 }, 0);

                vals[0] = ntw.GetResult(new double[] { 0, 0 });
                vals[1] = ntw.GetResult(new double[] { 0, 1 });
                vals[2] = ntw.GetResult(new double[] { 1, 0 });
                vals[3] = ntw.GetResult(new double[] { 1, 1 });

                //
                string title = "";
                //title += (vals[0] == oldvals[0] ? "E" : vals[0] < oldvals[0] ? "D" : "U") + "  ";
                //title += (vals[1] == oldvals[1] ? "E" : vals[1] < oldvals[1] ? "D" : "U") + "  ";
                //title += (vals[2] == oldvals[2] ? "E" : vals[2] < oldvals[2] ? "D" : "U") + "  ";
                //title += (vals[3] == oldvals[3] ? "E" : vals[3] < oldvals[3] ? "D" : "U") + "  ";
                title += (vals[0] == oldvals[0] ? "-" : vals[0] < oldvals[0] ? "↓" : "↑") + "  ";
                title += (vals[1] == oldvals[1] ? "-" : vals[1] < oldvals[1] ? "↓" : "↑") + "  ";
                title += (vals[2] == oldvals[2] ? "-" : vals[2] < oldvals[2] ? "↓" : "↑") + "  ";
                title += (vals[3] == oldvals[3] ? "-" : vals[3] < oldvals[3] ? "↓" : "↑") + "  ";
                title += "          ";
                title += Math.Round(vals[0], 3) + "  ";
                title += Math.Round(vals[1], 3) + "  ";
                title += Math.Round(vals[2], 3) + "  ";
                title += Math.Round(vals[3], 3) + "  ";
                Console.Title = title;

                oldvals[0] = vals[0];
                oldvals[1] = vals[1];
                oldvals[2] = vals[2];
                oldvals[3] = vals[3];


                Console.Write(i);
                Console.Write("    ");
                Console.Write(vals[0]);
                Console.Write("    ");
                Console.Write(vals[1]);
                Console.Write("    ");
                Console.Write(vals[2]);
                Console.Write("    ");
                Console.Write(vals[3]);
                Console.WriteLine("");


                //Console.Write("    ");
                //Console.Write(ntw.GetResult(new double[] { 0, 0 }));
                //Console.Write("    ");
                //Console.Write(ntw.GetResult(new double[] { 0, 1 }));
                //Console.Write("    ");
                //Console.Write(ntw.GetResult(new double[] { 1, 0 }));
                //Console.Write("    ");
                //Console.Write(ntw.GetResult(new double[] { 1, 1 }));
                //Console.WriteLine("");
            }

            Console.WriteLine("--");
            


            //Console.WriteLine(ntw.GetResult(new double[] { 0.54, 0.2 }));
            //Console.WriteLine(ntw.GetResult(new double[] { 0, 1 }));
            //Console.WriteLine(ntw.GetResult(new double[] { 1, 0 }));
            //Console.WriteLine(ntw.GetResult(new double[] { 1, 1 }));

            //for (int i = 0; i < 10000; i++)
            //{
            //    ntw.Teach(new double[] { 0, 0 }, 0);
            //    ntw.Teach(new double[] { 0, 1 }, 1);
            //    ntw.Teach(new double[] { 1, 0 }, 1);
            //    ntw.Teach(new double[] { 1, 1 }, 0);
            //}

            //Console.WriteLine("--");

            //Console.WriteLine(ntw.GetResult(new double[] { 0, 0 }));
            //Console.WriteLine(ntw.GetResult(new double[] { 0, 1 }));
            //Console.WriteLine(ntw.GetResult(new double[] { 1, 0 }));
            //Console.WriteLine(ntw.GetResult(new double[] { 1, 1 }));

            Console.ReadLine();
        }
    }
}
