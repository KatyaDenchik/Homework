using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers;

public class RationalNumber
{
    public int Numerator;
    public int Denominator;

    public void Swip()
    { 
        int temp = Numerator;
        this.Numerator = this.Denominator;
        this.Denominator = temp;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

}
