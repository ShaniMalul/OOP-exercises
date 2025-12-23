using System;

namespace question06
{
    public class OperationTable
    {
        public delegate int BinaryIntOperation(int a, int b);

        private int rowStart;
        private int rowEnd;
        private int colStart;
        private int colEnd;
        private BinaryIntOperation operation;

        public OperationTable(
            int rowStart, int rowEnd,
            int colStart, int colEnd,
            BinaryIntOperation op)
        {
            this.rowStart = rowStart;
            this.rowEnd = rowEnd;
            this.colStart = colStart;
            this.colEnd = colEnd;
            this.operation = op;
        }

        public void Print()
        {
            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = colStart; j <= colEnd; j++)
                {
                    int result = operation(i, j);
                    Console.Write(result + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
