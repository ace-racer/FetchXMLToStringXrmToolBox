using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchXmlToStringLogics
{
    // Copied code from here: http://stackoverflow.com/questions/8809354/replace-first-occurrence-of-pattern-in-a-string    
    /// <summary>
    /// Contains extension methods for strings
    /// </summary>
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Replaces the first.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="search">The search.</param>
        /// <param name="replace">The replace.</param>
        /// <returns>The string with first instance of search replaced by replace</returns>
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
