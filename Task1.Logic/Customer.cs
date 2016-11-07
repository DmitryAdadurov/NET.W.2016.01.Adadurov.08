using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{

    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }


        /// <summary>
        /// Object to string
        /// </summary>
        /// <returns>Returns string representation of object</returns>
        public override string ToString()
        {
            return ToString(null, CultureInfo.CurrentCulture);
        }


        /// <summary>
        /// Returns formatted string
        /// </summary>
        /// <param name="format">Format string</param>
        /// <returns>Returns string representation of object using format string</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }


        /// <summary>
        /// Returns string representation of object using format string and format provider
        /// N - Name
        /// C - ContactPhone
        /// R - Revenue
        /// </summary>
        /// <param name="format">Format string</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>Formatted string</returns>
        /// <exception cref="FormatException"></exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                return "Customer record: " + Name + " " + Revenue.ToString() + " " + ContactPhone;

            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;



            StringBuilder resultStr = new StringBuilder("Customer record:", 32);

            format = format.ToUpperInvariant();

            for (int i = 0; i < format.Length; i++)
            {
                char c = format[i];
                switch (c)
                {
                    case 'N':
                        resultStr.Append(" ");
                        resultStr.Append(Name);
                        break;
                    case 'C':
                        resultStr.Append(" ");
                        resultStr.Append(ContactPhone);
                        break;
                    case 'R':
                        resultStr.Append(" ");
                        if (format[i + 1] == ':')
                        {
                                resultStr.AppendFormat(formatProvider, "{0:" + format[i + 2].ToString() + "}", Revenue);
                            
                            i += 2;
                        }
                        else
                        {
                            resultStr.Append(Revenue);
                        }
                        break;

                    default:
                        throw new FormatException();
                }
            }

            return resultStr.ToString().TrimEnd(' ');
        }
    }
}
