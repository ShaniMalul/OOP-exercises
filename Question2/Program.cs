using System;

namespace Question6
{
    public struct MyStruct
    {
        public int A;
        public double B;
    }

    public class MyClass
    {
        public int A;
        public double B;
    }

    class Program
    {
        public static void MemoryAllocation()
        {
            long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

            int[] intArray = new int[10000];
            long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

            double[] doubleArray = new double[10000];
            long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

            string[] stringArray = new string[10000];
            long afterStringArray = GC.GetAllocatedBytesForCurrentThread();

            // ב.  structs
            MyStruct[] structArray = new MyStruct[10000];
            long afterStructArray = GC.GetAllocatedBytesForCurrentThread();

            // ג.  references 
            MyClass[] classArray = new MyClass[10000];
            for (int i = 0; i < classArray.Length; i++)
            {
                classArray[i] = new MyClass();
            }
            long afterClassArray = GC.GetAllocatedBytesForCurrentThread();

            Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");
            Console.WriteLine($"Int Array Allocation: {afterIntArray - baselineMemory} bytes");
            Console.WriteLine($"Double Array Allocation: {afterDoubleArray - afterIntArray} bytes");
            Console.WriteLine($"String Array Allocation: {afterStringArray - afterDoubleArray} bytes");
            Console.WriteLine($"Struct Array Allocation: {afterStructArray - afterStringArray} bytes");
            Console.WriteLine($"Class Array Allocation: {afterClassArray - afterStructArray} bytes");
        }
        static void Main(string[] args)
        {
            MemoryAllocation();
        }
    }
}

