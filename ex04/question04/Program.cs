using System;
namespace question04
{
    public class Fraction
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero");

        Numerator = numerator;
        Denominator = denominator;
        Reduce();
    }

    private static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private void Reduce()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;

        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(
            a.Numerator * b.Denominator + b.Numerator * a.Denominator,
            a.Denominator * b.Denominator
        );
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(
            a.Numerator * b.Denominator - b.Numerator * a.Denominator,
            a.Denominator * b.Denominator
        );
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(
            a.Numerator * b.Numerator,
            a.Denominator * b.Denominator
        );
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException();

        return new Fraction(
            a.Numerator * b.Denominator,
            a.Denominator * b.Numerator
        );
    }

    public static bool operator >(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.Numerator == b.Numerator &&
               a.Denominator == b.Denominator;
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Fraction other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}
    class Program
    {
        static void Main()
        {
            Fraction f1 = new Fraction(8, 12);   // will be reduced to 2/3
            Fraction f2 = new Fraction(3, 4);

            Console.WriteLine(f1);
            Console.WriteLine(f2);
            Console.WriteLine(f1 + f2);
            Console.WriteLine(f1 - f2);
            Console.WriteLine(f1 * f2);
            Console.WriteLine(f1 / f2);
            Console.WriteLine(f1 > f2);
            Console.WriteLine(f1 < f2);
            Console.WriteLine(f1 == f2);
        }
    }
}

