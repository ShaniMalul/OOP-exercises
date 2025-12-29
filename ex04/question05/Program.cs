using question04;
using question07;
using System;
using System.Collections.Generic;

namespace question05
{
    class Program
    {
        static void Main()
        {
            List<Fraction> fractionsList = new List<Fraction>();
            for (int i = 1; i <= 12; i++)
                fractionsList.Add(new Fraction(i, 12));

            GenericOperationTable<Fraction> table =
                new GenericOperationTable<Fraction>(fractionsList, fractionsList, (a, b) => a + b);

            table.Print();

        }
    }

}
