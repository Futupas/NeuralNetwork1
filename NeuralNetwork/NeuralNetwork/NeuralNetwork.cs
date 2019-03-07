using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class NN
    {
        public Neuron[][] Network;
        protected readonly int layers_count;
        protected readonly int neurons_count;
        protected readonly int inputs_count;
        protected readonly double learning_rate;
        public NN(int layers_count, int neurons_count, int inputs_count, double learning_rate)
        {
            this.layers_count = layers_count;
            this.neurons_count = neurons_count;
            this.inputs_count = inputs_count;
            this.learning_rate = learning_rate;

            this.Network = new Neuron[layers_count + 2][];
            Network[0] = new Neuron[inputs_count];
            for (int i = 1; i < Network.Length-1; i++)
            {
                Network[i] = new Neuron[neurons_count];
            }
            Network[Network.Length-1] = new Neuron[1];


            for (int j = 0; j < Network[0].Length; j++) //i - layer, j - neuron in layer
            {
                Network[0][j] = new Neuron(false, inputs_count);
            }
            for (int i = 1; i < Network.Length-1; i++)
            {
                Network[i][0] = new Neuron(true, Network[i - 1].Length); //bais neuron (first in all hidden layers
                for (int j = 1; j < Network[i].Length; j++) //i - layer, j - neuron in layer
                {
                    Network[i][j] = new Neuron(false, Network[i-1].Length);
                }
            }
            Network[Network.Length-1][0] = new Neuron(false, Network[Network.Length - 2].Length); //out neuron

        }
        public double GetResult(double[] inputs)
        {
            for (int i = 0; i < Network[0].Length; i++)
            {
                Network[0][i].Value = inputs[i];
            }
            for (int i = 1; i < Network.Length; i++)
            {
                double[] previous_layer_values = new double[Network[i - 1].Length];
                for (int j = 0; j < Network[i-1].Length; j++) //i - layer, j - neuron in layer
                {
                    previous_layer_values[j] = Network[i - 1][j].Value; // setting previous layer's values
                }
                for (int j = 0; j < Network[i].Length; j++) //i - layer, j - neuron in layer
                {
                    Network[i][j].Value = Network[i][j].GetResult(previous_layer_values);
                }
            }

            return Network[Network.Length - 1][0].Value;
        }

        public void Teach(double[] inputs, double expected_output)
        {
            double actual_output = this.GetResult(inputs);
            // output neuron
            Neuron out_neuron = Network[Network.Length - 1][0];
            out_neuron.weights_delta = out_neuron.Value * (1 - out_neuron.Value) * (expected_output - out_neuron.Value);
            for (int i = 0; i < out_neuron.Weights.Length; i++)
            {
                double neuron_out = Network[Network.Length - 2][i].Value;
                out_neuron.Weights[i] += learning_rate * out_neuron.weights_delta * neuron_out;
            }
            // hidden layers
            for (int i = Network.Length-2; i >= 1; i--) // от предпоследнего до второго (первого скрытого)
            {
                for (int j = 0; j < Network[i].Length; j++) // each neuron in layer
                {
                    if (Network[i][j].is_bais) continue;
                    double weights_delta = 0;
                    for (int ej = 0; ej < Network[i+1].Length; ej++) // for each neuron in next layer
                    {
                        weights_delta += (Network[i + 1][ej].weights_delta * Network[i + 1][ej].Weights[j]);
                    }
                    Network[i][j].weights_delta = weights_delta;

                    for (int wj = 0; wj < Network[i][j].Weights.Length; wj++)
                    {
                        Network[i][j].Weights[wj] += learning_rate * weights_delta * Network[i - 1][wj].Value;
                    }
                }
            }

        }
        

        protected static double Derivative(double sigmoid_x) // derivative of sigmoid function
        {
            //double sigmoid_x = 1 / (1 + Math.Exp(x * -1));
            return sigmoid_x * (1 - sigmoid_x);
        }

        //public void Teach(double[] inputs, double expected_output)
        //{
        //    double actual_output = this.GetResult(inputs);
        //    // output neuron
        //    double error = actual_output - expected_output;
        //    Neuron last_neuron = Network[Network.Length - 1][0];
        //    double weights_delta = error * Derivative(last_neuron.Value);
        //    for (int i = 0; i < last_neuron.Weights.Length; i++)
        //    {
        //        double weight_i = last_neuron.Weights[i];
        //        double output_i = Network[Network.Length - 2][i].Value;

        //        Network[Network.Length - 1][0].Weights[i] = weight_i - output_i * weights_delta * learning_rate;
        //    }
        //    //other neurons
        //    for (int i = Network.Length - 2; i >= 0; i--) // for each layer
        //    {
        //        for (int j = 0; j < Network[i].Length; j++) // for each neuron in layer
        //        {
        //            if (Network[i][j].is_bais) continue; // continue if the neuron is bais
        //            error = 0;
        //            for (var j1 = 0; j1 < Network[i + 1].Length; j1++) // for each neuron in next layer
        //            {
        //                double current_weight = Network[i + 1][j1].Weights[j];
        //                error += (weights_delta * current_weight);
        //            }

        //        }
        //    }

        //}

        //public void TeachRecursive(int layer, int neuron)
        //{
        //    if (layer <= 0) return;
        //    Neuron current_neuron = Network[layer][neuron];
        //    if (current_neuron.is_bais) return;

        //    double error = 0;



        //    double weights_delta = error * Derivative(current_neuron.Value);




        //    for (int i = 0; i < last_neuron.Weights.Length; i++)
        //    {
        //        double weight_i = last_neuron.Weights[i];
        //        double output_i = Network[Network.Length - 2][i].Value;

        //        Network[Network.Length - 1][0].Weights[i] = weight_i - output_i * weights_delta * learning_rate;
        //    }
        //}
    }

    class Neuron
    {
        public double[] Weights; //input 
        public double Value;
        public bool is_bais = false;
        public double weights_delta;
        public double GetResult(double[] values)
        {
            if (this.is_bais)
            {
                return 1;
            }
            else
            {
                double x = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    x += (values[i] * this.Weights[i]);
                }
                return this.ActivationFunction(x);
            }
        }

        protected double ActivationFunction (double x) // Sigmoid
        {
            return 1 / (1 + Math.Exp(x * -1));
        }

        public Neuron(bool is_bais, double[] input_weights)
        {
            this.Weights = input_weights;
            this.is_bais = is_bais;
        }
        public Neuron(bool is_bais, int input_weights_count)
        {
            this.Weights = new double[input_weights_count];
            for (int i = 0; i < Weights.Length; i++)
            {
                this.Weights[i] = (new Random().NextDouble()) / 2 + .25;
            }
            this.is_bais = is_bais;
        }
    }
}
