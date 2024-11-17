using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Static
{
    public static class NORMALIZE
    {
        public static string NormalizeCity(string city)
        {
            return city.Normalize(NormalizationForm.FormD)
                       .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                       .Aggregate("", (current, c) => current + c);
        }
    }
}
