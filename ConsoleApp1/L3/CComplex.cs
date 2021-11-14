using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L3;

internal class CComplex
{
    public double Re { get; set; }

    public double Im { get; set; }

    public CComplex(double re, double im)
    {
        Re = re;
        Im = im;
    }

    public static CComplex operator +(CComplex a, CComplex b) => new(a.Re + b.Re, a.Im + b.Im);

    public static CComplex operator -(CComplex a, CComplex b) => new(a.Re - b.Re, a.Im - b.Im);

    public static CComplex operator *(CComplex a, CComplex b) => new(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + b.Re * a.Im);

    public override string ToString() => $"{nameof(CComplex)} {nameof(Re)} - {Re} {nameof(Im)} - {Im}";
}
