using System;

namespace ex1
{
    struct PointStruct
    {
        public int X;
        public int Y;
    }

    class PointClass
    {
        public int X;
        public int Y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            PointStruct ps1 = new PointStruct { X = 10, Y = 20 };
            PointStruct ps2 = ps1; 
            ps2.X = 100; 

            Console.WriteLine("Struct Example:");
            Console.WriteLine($"ps1: X = {ps1.X}, Y = {ps1.Y}"); 
            Console.WriteLine($"ps2: X = {ps2.X}, Y = {ps2.Y}"); 

            PointClass pc1 = new PointClass { X = 10, Y = 20 };
            PointClass pc2 = pc1;
            pc2.X = 100; 

            Console.WriteLine("\nClass Example:");
            Console.WriteLine($"pc1: X = {pc1.X}, Y = {pc1.Y}");
            Console.WriteLine($"pc2: X = {pc2.X}, Y = {pc2.Y}");
        }
    }
}
