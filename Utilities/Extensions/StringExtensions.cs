using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string Slugify(this string text, string suffix = null, string sep = null)
        {
            string slug = text.Trim().ToLower();
            slug = slug.Replace("ı", "i")
                       .Replace("ç", "c")
                       .Replace("ş", "s")
                       .Replace("ü", "u")
                       .Replace("ö", "o")
                       .Replace("ğ", "g");
            // https://regexr.com
            slug = Regex.Replace(slug, @"[^\w\d\s]", "");
            slug = Regex.Replace(slug.Trim(), @"\s+", "-");
            if (sep != null) slug += "-" + sep;
            if (suffix != null) slug += "-" + suffix;
            return slug;
        }
    }
}
