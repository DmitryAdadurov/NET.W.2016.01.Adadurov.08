using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1.Logic;
using Task1.FormatProvider;
using System.Threading;
using System.Globalization;

namespace Task1.Logic.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        public CustomerTests()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        static object[] c = {
                              new Customer { Name = "Jeffrey Richter", Revenue = 1000000, ContactPhone = "+1 (425) 555-0100" }
                              };

        [Test, TestCaseSource("c")]
        public void ToStringTest(Customer c)
        {
            string expected = "Customer record: Jeffrey Richter 1000000 +1 (425) 555-0100";
            string actual = c.ToString("NRC");
            Assert.AreEqual(expected, actual);
        }

        
        [Test, TestCaseSource("c")]
        public void ToString_CustomProvider(Customer c)
        {
            string expected = "Customer record: Jeffrey Richter 1 000 000.00 +1 (425) 555-0100";
            string actual = c.ToString("NR:DC", new CustomerFormatProvider());
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource("c")]
        public void ToString_CustomProvider_FormatExceptionExpected(Customer c)
        {
            Assert.Throws<FormatException>( () => c.ToString("ABC", new CustomerFormatProvider()) );
        }

        [Test, TestCaseSource("c")]
        public void ToString_CustomProvider_StandartFormatStrings(Customer c)
        {
            string expected = "Customer record: ¤1,000,000.00";

            // R is Revenue property
            // C is standart literal to represent Decimal value as currency
            string actual = c.ToString("R:C");
            Assert.AreEqual(expected, actual);
        }

    }
}
