using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    public static class Extensions
    {
        public static string FormatToString(this List<RationalNumber> rationalNumbers)
        {
            string text = string.Empty;
            rationalNumbers.ForEach(s => text = $"{text}{s}\n");
            return text;
        }
    }
}
