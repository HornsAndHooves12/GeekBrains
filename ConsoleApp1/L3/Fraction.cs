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
        }
    }

    private int _numerator;
    public int Denomenator
    {
        get => _denomenator; 
        set
        {
            if (value == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            _denomenator = value;
        }
    }
    private int _denomenator;

    public Fraction(int numerator, int denomenatorm)
    {
        Numerator = numerator;
        Denomenator = denomenatorm;
    }

    public static Fraction operator +(Fraction a, Fraction b) => new(a.Numerator + b.Numerator, a.Denomenator + b.Denomenator);

    public static Fraction operator -(Fraction a, Fraction b) => new(a.Numerator - b.Numerator, a.Denomenator - b.Denomenator);

    public static Fraction operator *(Fraction a, Fraction b) => new(a.Numerator * b.Numerator - a.Denomenator * b.Denomenator, a.Numerator * b.Denomenator + b.Numerator * a.Denomenator);

    public static Fraction operator /(Fraction a, Fraction b) => new(a.Numerator * b.Numerator - a.Denomenator * b.Denomenator, a.Numerator * b.Denomenator + b.Numerator * a.Denomenator);

    public override string ToString() => $"{nameof(Fraction)} {nameof(Numerator)} - {Numerator} {nameof(Denomenator)} - {Denomenator}";
}
