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

    static void ModifyStruct(PointStruct p)
    {
        p.X = 999;
        p.Y = 999;
        Console.WriteLine("Inside ModifyStruct (normal pass): X = {0}, Y = {1}", p.X, p.Y);
    }
    static void ModifyStructRef(ref PointStruct p)
    {
        p.X = 555;
        p.Y = 555;
        Console.WriteLine("Inside ModifyStructRef (ref pass): X = {0}, Y = {1}", p.X, p.Y);
    }

    static void ModifyClass(PointClass c)
    {
        c.X = 888;
        c.Y = 888;
        Console.WriteLine("Inside ModifyClass: X = {0}, Y = {1}", c.X, c.Y);
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

            PointStruct ps3 = new PointStruct { X = 1, Y = 2 };
            ModifyStruct(ps3);
            Console.WriteLine("Struct ps3 after ModifyStruct: X = {0}, Y = {1}", ps3.X, ps3.Y); 

            ModifyStructRef(ref ps3);
            Console.WriteLine("Struct ps3 after ModifyStructRef: X = {0}, Y = {1}", ps3.X, ps3.Y);

            PointClass pc3 = new PointClass { X = 1, Y = 2 };
            ModifyClass(pc3);
            Console.WriteLine("Class pc3 after ModifyClass: X = {0}, Y = {1}", pc3.X, pc3.Y); 
        }
    }
}
