using System;

namespace question02_05
{
    public class ArrayProcessor
    {
        public delegate void UnaryAction(double a);

        public static void ProcessArray(double[] array, UnaryAction processor)
        {
            foreach (double value in array)
            {
                processor(value);
            }
        }
    }

    public class SumCalculator
    {
        public double Sum { get; private set; } = 0;

        public void AddToSum(double value)
        {
            Sum += value;
        }
    }

    public class MaxCalculator
    {
        public double Max { get; private set; } = double.MinValue;

        public void CheckMax(double value)
        {
            if (value > Max)
            {
                Max = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double[] array = new double[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.NextDouble() * 100;
            }

            SumCalculator sumCalc = new SumCalculator();
            ArrayProcessor.ProcessArray(array, sumCalc.AddToSum);

            MaxCalculator maxCalc = new MaxCalculator();
            ArrayProcessor.ProcessArray(array, maxCalc.CheckMax);

            Console.WriteLine("Array values:");
            foreach (double value in array)
            {
                Console.WriteLine(value);

            }

            Console.WriteLine($"Sum: {sumCalc.Sum}");
            Console.WriteLine($"Max: {maxCalc.Max}");


            // שאלה 5
            double sum = 0;
            ArrayProcessor.ProcessArray(array, x => sum += x);

            double max = double.MinValue;
            ArrayProcessor.ProcessArray(array, x =>
            {
                if (x > max)
                    max = x;
            });

            Console.WriteLine($"Lambda Sum: {sum}");
            Console.WriteLine($"Lambda Max: {max}");
        }
    }
}
