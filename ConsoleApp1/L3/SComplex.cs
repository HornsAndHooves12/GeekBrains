using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L3;

internal struct SComplex
{

    public double Re { get; set; }

    public double Im { get; set; }

    public SComplex(double re, double im)
    {
        Re = re;
        Im = im;
    }

    public static SComplex operator +(SComplex a, SComplex b) => new(a.Re + b.Re, a.Im + b.Im);

    public static SComplex operator -(SComplex a, SComplex b) => new(a.Re - b.Re, a.Im - b.Im);

    public override string ToString() => $"{nameof(SComplex)} {nameof(Re)} - {Re} {nameof(Im)} - {Im}";

}
