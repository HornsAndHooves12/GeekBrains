using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.L3;

internal class Fraction
{
    public int Numerator
    {
        get => _numerator;
        set
        {
            _numerator = value;
            Simplify();
        }
    }

    private int _numerator;
    public int Denomenator
    {
        get => _denomenator;
        set
        {
            if (value == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            Numerator *= Math.Sign(value);
            _denomenator = Math.Abs(value);
            Simplify();
        }
    }
    private int _denomenator;

    public Fraction(int numerator, int denomenatorm)
    {
        Denomenator = denomenatorm;
        Numerator = numerator;
    }

    public double Decimal { get => (double)Numerator / (double)Denomenator; }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            var d = a % b;
            a = b;
            b = d;
        }
        return Math.Abs(a);
    }

    private static int Lcm(int a, int b)
    {
        return a * b / Gcd(a, b);
    }

    private void Simplify()
    {
        if (Numerator == 0) return;
        var gcd = Gcd(Numerator, Denomenator);
        _numerator /= gcd;
        _denomenator /= gcd;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        var gcd = Gcd(a.Denomenator, b.Denomenator);
        var den = a.Denomenator * b.Denomenator / gcd;
        var num = a.Numerator * b.Denomenator / gcd + b.Numerator * a.Denomenator / gcd;
        return new(num, den);
    }
    public static Fraction operator -(Fraction a, Fraction b)
    {
        var gcd = Gcd(a.Denomenator, b.Denomenator);
        var den = a.Denomenator * b.Denomenator / gcd;
        var num = a.Numerator * b.Denomenator / gcd - b.Numerator * a.Denomenator / gcd;
        return new(num, den);
    }

    public static Fraction operator *(Fraction a, Fraction b) => new(a.Numerator * b.Numerator, a.Denomenator * b.Denomenator);

    public static Fraction operator /(Fraction a, Fraction b) => new(a.Numerator * b.Denomenator, a.Denomenator * b.Numerator);

    //public override string ToString() => $"{nameof(Fraction)} {nameof(Numerator)} - {Numerator} {nameof(Denomenator)} - {Denomenator}";
    public override string ToString() => $"{Numerator}/{Denomenator}";
}
