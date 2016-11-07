using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Extension
{
    public class CustomerDecorator : Customer
    {
        Customer cust;

        public CustomerDecorator(Customer c)
        {
            cust = c;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
