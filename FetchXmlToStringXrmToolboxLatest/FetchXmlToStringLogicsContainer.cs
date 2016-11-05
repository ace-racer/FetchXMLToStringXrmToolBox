using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchXmlToStringXrmToolboxLatest
{
    public class FetchXmlToStringLogicsContainer
    {
        /// <summary>
        /// Converts the fetch XML to string.
        /// </summary>
        /// <param name="fetchXml">The fetch XML.</param>
        /// <returns>The C#/JavaScript string</returns>
        public string ConvertFetchXmlToString(string fetchXml)
        {
            if (!string.IsNullOrWhiteSpace(fetchXml))
            {
                var retStr = string.Empty;
                var tempStr = fetchXml;

                // replace double quotes with single quotes
                tempStr = tempStr.Replace("\"", "\'");

                // split by newlines and append 
                var splitStrs = tempStr.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                for (var itr = 0; itr < splitStrs.Length - 1; itr++)
                {

                    // check the present string is not an empty string before wrapping it in quotes
                    if (splitStrs[itr].Length > 0)
                    {
                        // fix for valid hyphens getting removed - remove only invalid hyphens which occur at the start

                        var valueToAppend = splitStrs[itr];

                        // if hyphen at the very start
                        if (valueToAppend[0] == '-')
                        {

                            // replace the first hyphen only
                            valueToAppend = valueToAppend.ReplaceFirst("-", "");
                        }
                        else
                        {
                            // iterate through the split string searching for hyphen at the start
                            for (var charcount = 1; charcount < valueToAppend.Length; charcount++)
                            {
                                // characters have started
                                if (valueToAppend[charcount - 1] != ' ')
                                {
                                    break;
                                }
                                else
                                {
                                    if (valueToAppend[charcount] == '-')
                                    {

                                        // replace the fisrt occurance of hyphen only
                                        valueToAppend = valueToAppend.ReplaceFirst("-", "");
                                        break;
                                    }
                                }
                            }
                        }

                        retStr += "\"" + valueToAppend + "\"+" + Environment.NewLine;
                    }
                }

                if (splitStrs.Length > 0)
                {
                    if (splitStrs[splitStrs.Length - 1].Length > 0)
                    {
                        retStr += "\"" + splitStrs[splitStrs.Length - 1] + "\";";
                    }
                }

                return retStr;
            }

            return string.Empty;
        }
    }
}
