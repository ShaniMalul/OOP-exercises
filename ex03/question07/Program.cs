using System;
using System.Collections.Generic;

namespace question07
{
    class GenericOperationTable<T>
    {
        public delegate T Func(T x, T y);

        private List<T> _rows;
        private List<T> _cols;
        private Func _operation;

        // constructor
        public GenericOperationTable(List<T> rows, List<T> cols, Func operation)
        {
            _rows = rows;
            _cols = cols;
            _operation = operation;
        }
        public void Print()
        {
            foreach (T r in _rows)
            {
                foreach (T c in _cols)
                {
                    Console.Write(_operation(r, c) + "\t");
                }
                Console.WriteLine();
            }
        }
    }

}
